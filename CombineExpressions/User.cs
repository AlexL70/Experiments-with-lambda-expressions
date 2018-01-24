using System;


namespace CombineExpressions
{
    public class User
    {
        public long Id { get; set; } // bigint
        public string Login { get; set; } // nvarchar(32)
        public string FirstName { get; set; } // nvarchar(240)
        public string LastName { get; set; } // nvarchar(240)
        public string MiddleName { get; set; } // nvarchar(240)
        public string Title { get; set; } // nvarchar(240)
        public byte AutomaticLogOffInterval { get; set; } // tinyint
        public int Kind { get; set; } // int
        public byte[] Password { get; set; } // varbinary(8000)
        public int Status { get; set; } // int
        public bool ResetPassword { get; set; } // bit
        public long CreatorId { get; set; } // bigint
        public DateTime Created { get; set; } // datetime2(7)
        public long ChangerId { get; set; } // bigint
        public DateTime Changed { get; set; } // datetime2(7)
        public string TimeZoneId { get; set; } // nvarchar(240)
        public bool ResetChallengeQuestion { get; set; } // bit
        public bool BypassIdentetyVerification { get; set; } // bit
        public bool BypassEmailVerification { get; set; } // bit
        public int PwdComplexityFailedAttempts { get; set; } // int
        public DateTime? LastLoginDate { get; set; } // datetime2(7)
        public bool PreDefined { get; set; } // bit
        public long LastAccessUserId { get; set; } // bigint
        public DateTime LastAccessDateTime { get; set; } // datetime2(7)
        public string ArchivedLogin { get; set; } // nvarchar(32)
        public string StrId { get; set; } // varchar(32)
        public string UserFullName { get; set; } // nvarchar(481)
        public bool? Approved { get; set; } // bit
        public string UserName { get; set; } // nvarchar(32)
        public DateTime? ArchivedDate { get; set; } // datetime2(7)
        public int? StatusBeforeLock { get; set; } // int
    }
}
