using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BPD01_WebApi_Core.Domain
{
     [Table("Reports")]
     [DataContract]
    public class ReportDateModel
    {
         public ReportDateModel()
        {
            tempAttachment = new AttachmentModel();
            Attachments = new List<AttachmentModel>();
        }
        [Key]
        [Display(Name = "Report ID")]
         [DataMember]
        public int ReportId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Report Date")]
         [DataMember]
        public DateTime ReportDate { get; set; }
        [Display(Name = "Report Type")]
        [MaxLength(1)]
        public string ReportType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Create Date")]
         [DataMember]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Modify Date")]
         [DataMember]
        public Nullable<DateTime> ModifyDate { get; set; }
        [MaxLength(100)]
         [DataMember]
        public string AddBy { get; set; }
        [MaxLength(100)]
         [DataMember]
        public string ModBy { get; set; }
         [DataMember]
        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        [InverseProperty("ReportDates")]
        public GrantModel Grant { get; set; }
         [DataMember]
        public bool IsDeleted { get; set; }
         [DataMember]
        public string FinancialReportingPeriod { get; set; }
         [DataMember]
        public string ProgrammingReportingPeriod { get; set; }
        [NotMapped]
        public string grantName { get; set; }
        [NotMapped]
        public AttachmentModel tempAttachment { get; set; }
        [NotMapped]
        public List<AttachmentModel> Attachments { get; set; }
        [NotMapped]
        public bool hasAttachment { get; set; }
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? finReportPerStartDate { get; set; }
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? finReportPerEndDate { get; set; }
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? progReportPerStartDate { get; set; }
        [NotMapped]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? progReportPerEndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateSubmittedToGrantor { get; set; }
    }
}