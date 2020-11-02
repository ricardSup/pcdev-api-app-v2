using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserLoginId { get; set; }
        public int AccessFailedCount { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool IsLockoutEnabled { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? LockoutEnd { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public bool? IsPhoneNumberConfirmed { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [JsonIgnore]
        [StringLength(100)]
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }


        [StringLength(50)]
        public string UsrCrt { get; set; }
        [StringLength(50)]
        public string UsrUpd { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? DtmCrt { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? DtmUpd { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
