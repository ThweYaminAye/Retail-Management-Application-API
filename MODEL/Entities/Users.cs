using System;
using System.ComponentModel.DataAnnotations;
using MODEL.CommonConfig;


namespace MODEL.Entities
{
    public class Users : Common
    {
        public int ID { get; set; }

        public string ProfileID { get; set; }

        public string? FullName { get; set; }

        public string? Password { get; set; }

        public string? Gender { get; set; }

        public string Email { get; set; }

        public DateTime? JoinDate { get; set; }

        public string? ProfilePic { get; set; }

        public string? Thumbnail { get; set; }

        public bool? ActiveFlag { get; set; }

        public string? UserType { get; set; }

        public string? Compare { get; set; }

        public byte[]? SaltHash { get; set; }

        public byte[]? SaltAes { get; set; }

        public string? PinCode { get; set; }

        public int? TotalSuccessful { get; set; }

        public int? DailyAverage { get; set; }

        public DateTime? DailyAverageDate { get; set; }

        public string? Positions { get; set; }

        public int? RoleID { get; set; }

        public int? UserRole { get; set; }

        public bool? ForceReset { get; set; }

        public bool? LockStatus { get; set; }

        public Guid? CompanyId { get; set; }

        public Guid? MemberID { get; set; }

        public DateTime? PasswordUpdateDate { get; set; }

        public int? GoalMinutes { get; set; }

        public string? CreateBy { get; set; } = "Admin";

        public string? UpdateBy { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public bool? IsEnable { get; set; }

        public string? DeviceID { get; set; }

        public bool Lock { get; set; }

        public bool Noti { get; set; }

        public bool? Finger_Face { get; set; }

        public string UserName { get; set; }

        public bool? PolicyTypeM { get; set; }

        public bool? PolicyTypeW { get; set; }

        public bool? EmailCheck { get; set; }

        public string? Language { get; set; }

        public string? LanguageUserView { get; set; }

        public int? DepartmentId { get; set; }

        public string? LineUserID { get; set; }

        public string? EmailLanguage { get; set; }
    }
}
