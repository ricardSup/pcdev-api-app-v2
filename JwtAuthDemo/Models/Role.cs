using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthDemo.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
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
