using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPD01_WebApi_Core.Domain
{
    [Table("Extensions")]
    public class GrantExtensionModel
    {
         [Key]
        [Display(Name = "Grant Extension ID")]
        public int GrantExtensionId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Extension Date")]
        public DateTime ExtensionDate { get; set; }
        public DateTime? ModWhen { get; set; }
        public DateTime? AddWhen { get; set; }
        [MaxLength(100)]
        public string ModBy { get; set; }
        [MaxLength(100)]
        public string AddBy { get; set; }
        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        public GrantModel Grant { get; set; }
    }
}