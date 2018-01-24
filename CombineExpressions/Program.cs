using System;
using System.Linq.Expressions;

namespace CombineExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<User, string>> expr = (User u) => u.FirstName;
            var combined = Combiner(expr, AdvSearchOperators.Contains, "John");
            Console.WriteLine(combined.ToString());
        }

        public static Expression<Func<User, bool>> Combiner(Expression<Func<User, string>> fieldExpr, AdvSearchOperators op,
            string str)
        {
            Expression<Func<User, bool>> predicate;

            switch (op)
            {
                    case AdvSearchOperators.Equals:
                        predicate = Expression.Lambda<Func<User, bool>>(
                            Expression.Equal(
                                fieldExpr.Body,
                                Expression.Constant(str, typeof(string))
                            ), fieldExpr.Parameters);
                    break;

                case AdvSearchOperators.Contains:
                    predicate = Expression.Lambda<Func<User, bool>>(
                        Expression.Call(fieldExpr.Body,
                            typeof(String).GetMethod("Contains", new Type[] { typeof(string) }), 
                            Expression.Constant(str, typeof(string))
                        ),
                        fieldExpr.Parameters
                    );
                    break;

                    default:
                        predicate = u => true;
                    break;
            }

            return predicate;
        } 
    }
}
