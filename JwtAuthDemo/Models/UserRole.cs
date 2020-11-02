using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserRoleId { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
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
