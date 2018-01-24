using System;
using System.Linq.Expressions;

namespace CombineExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<User, string>> expr = (User u) => u.FirstName;
            var searchStr = "John";
            var combined = StringFieldPredicate(expr, AdvSearchOperators.Equals, searchStr);
            Console.WriteLine(combined.ToString());
            combined = StringFieldPredicate(expr, AdvSearchOperators.NotEqual, searchStr);
            Console.WriteLine(combined.ToString());
            combined = StringFieldPredicate(expr, AdvSearchOperators.Contains, searchStr);
            Console.WriteLine(combined);
            combined = StringFieldPredicate(expr, AdvSearchOperators.NotContain, searchStr);
            Console.WriteLine(combined);
            Console.ReadKey();
        }

        public static Expression<Func<User, bool>> StringFieldPredicate(Expression<Func<User, string>> fieldExpr, AdvSearchOperators op,
            string str)
        {
            var strExpr = Expression.Constant(str, typeof(string));
            Expression<Func<User, bool>> predicate;

            switch (op)
            {
                case AdvSearchOperators.Equals:
                    predicate = Expression.Lambda<Func<User, bool>>(
                        Expression.Equal(
                            fieldExpr.Body, strExpr
                        ), fieldExpr.Parameters);
                    break;

                case AdvSearchOperators.NotEqual:
                    predicate = Expression.Lambda<Func<User, bool>>(
                        Expression.NotEqual(
                            fieldExpr.Body, strExpr
                            ), fieldExpr.Parameters);
                    break;

                case AdvSearchOperators.Contains:
                case AdvSearchOperators.NotContain:
                    predicate = Expression.Lambda<Func<User, bool>>(
                        Expression.Call(fieldExpr.Body,
                            typeof(String).GetMethod("Contains", new Type[] { typeof(string) }),
                            strExpr
                        ),
                        fieldExpr.Parameters
                    );
                    if (AdvSearchOperators.NotContain == op)
                    {
                        predicate = Expression.Lambda<Func<User, bool>>(
                            Expression.Not(predicate.Body), predicate.Parameters
                            );
                    }
                    break;

                default:
                    predicate = u => true;
                    break;
            }

            return predicate;
        }
    }
}
