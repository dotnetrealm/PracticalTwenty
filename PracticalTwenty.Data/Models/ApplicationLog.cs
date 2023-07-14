using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTwenty.Data.Models
{
    public class ApplicationLog
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? Area { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ControllerName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string ActionName { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string? RoleId { get; set; }
        [Column(TypeName = "varchar(2)")]
        public string? LangId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? IpAddress { get; set; }

        [Column(TypeName = "char(1)")]
        public char? IsFirstLogin { get; set; }
        public DateTime LoggedInAt { get; set; }
        public DateTime LoggedOutAt { get; set; }
        [Column(TypeName = "char(1)")]
        public char? LoginStatus { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? PageAccessed { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? SessionId { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? UrlReferrer { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? UserId { get; set; }
    }
}
