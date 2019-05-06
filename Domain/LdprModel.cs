using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPD01_WebApi_Core.Domain
{
    [Table("Ldpr")]
    public class LdprModel
    {
        [Key]
        public int LdprId { get; set; }
        [Display(Name = "LDPR Numbers")]
        [MaxLength(10)]
        public string LdprNumber { get; set; }
        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        public GrantModel Grant { get; set; }
        public DateTime? AddWhen { get; set; }
        public DateTime? ModWhen { get; set; }
        [MaxLength(100)]
        public string AddBy { get; set; }
        [MaxLength(100)]
        public string ModBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
