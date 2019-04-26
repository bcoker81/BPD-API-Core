using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPD01_WebApi_Core.Domain
{
     [Table("Expenditures")]
    public class ExpenditureModel
    {
        [Key]
        public int ExpenditureId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> ExpenditureDate { get; set; }
        [MaxLength(100)]
        public string DocumentNumber { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> Amount { get; set; }
        [MaxLength(2000)]
        public string Notes { get; set; }
        public Nullable<bool> DivStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> BpdDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal BpdAmount { get; set; }
        [MaxLength(100)]
        public string SamDocNumber { get; set; }
        [MaxLength(50)]
        public string Vendor { get; set; }
        [MaxLength(2000)]
        public string BpdNotes { get; set; }
        [MaxLength(100)]
        public string AddBy { get; set; }
        public DateTime? AddWhen { get; set; }
        [MaxLength(100)]
        public string ModBy { get; set; }
        public DateTime? ModWhen { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCredit { get; set; }
        public int FK_Category_Id { get; set; }
        [ForeignKey("FK_Category_Id")]
        public CategoryModel Category { get; set; }
        [NotMapped]
        public List<AttachmentModel> Attachments { get; set; }
    }
}
