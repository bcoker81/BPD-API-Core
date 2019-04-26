using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BPD01_WebApi_Core.Domain
{
      [Table("Grants")]
      [DataContract]
    public class GrantModel
    {
        public GrantModel()
        {
            tempComment = new CommentModel();
            ReportDates = new List<ReportDateModel>();
            Comments = new List<CommentModel>();
            ExtensionDates = new List<GrantExtensionModel>();
            Categories = new List<CategoryModel>();
            LdprProjectNumbers = new List<LdprModel>();
            ganModel = new GANModel();
            GanList = new List<GANModel>();
            tempAttachment = new AttachmentModel();
            Attachments = new List<AttachmentModel>();
        }

        /*[NotMapped]
        public GrantModel Grant { get; set; }*/
        [NotMapped]
        public string UserDivision { get; set; }
        [NotMapped]
        public GANModel ganModel { get; set; }
        [NotMapped]
        public List<PickListModel> PickList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GranterList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [NotMapped]
        public List<ReportDateModel> tempReportList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GrantTypeList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> GrantStatusList { get; set; }
        [NotMapped]
        public List<string> granterTextList = new List<string>();
        [NotMapped] 
        public List<String> grantTypeListText = new List<String>();
        [NotMapped]
        public List<String> statusList = new List<String>();
        [NotMapped]
        public List<String> appStatusList = new List<String>();
        [NotMapped]
        public IEnumerable<SelectListItem> adjustmentsList { get; set; }
        // [NotMapped]
        [DataMember]
        public virtual List<CategoryModel> Categories { get; set; }
        [NotMapped]
        public List<ReportDateModel> finReportDateList { get; set; }
        [NotMapped]
        public List<ReportDateModel> ProgReportDateList { get; set; }
         [DataMember]
        public Nullable<bool> IsNew { get; set; }
        [MaxLength(255)]
         [DataMember]
        public String Division { get; set; }
        [MaxLength(32)]
         [DataMember]
        public string NickName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Financial Report Due Date")]
         [DataMember]
        public DateTime? FinancialReportDueDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Program Report Due Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public DateTime? ProgrammingReportDueDate { get; set; }
        [Display(Name ="Import Date")]
         [DataMember]
        public Nullable<DateTime> ImportDate { get; set; }
        [Display(Name = "Remaining Balance")]
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
         [DataMember]
        public Decimal RemainingBal { get; set; }
        [Key]
         [DataMember]
        public int Id { get; set; }
        [MaxLength(10)]
        [Display(Name = "Grant Number")]
         [DataMember]
        public string MshpGrantNumber { get; set; }
        public int Status { get; set; }
        [MaxLength(255)]
        [Display(Name = "Grant Name")]
         [DataMember]
        public string GrantName { get; set; }
        [Display(Name = "CFDA Number")]
        [MaxLength(32)]
         [DataMember]
        public string CfdaNumber { get; set; }
        [MaxLength(10)]
         [DataMember]
        public string Component { get; set; }
        [Display(Name = "Project Director")]
        [MaxLength(255)]
         [DataMember]
        public string ProjectDirector { get; set; }
        [MaxLength(127)]
         [DataMember]
        public string Accountant { get; set; }
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Display(Name = "Application Amount")]
         [DataMember]
        public Nullable<double> ApplicationAmount { get; set; }
        [NotMapped]
        [Display(Name = "Percent Of Funds Spent")]
         [DataMember]
        public double percentOfFundsSpent { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public CommentModel tempComment { get; set; }
        [NotMapped] 
        public ReportDateModel newProgDate { get; set; }
        [NotMapped] 
        public ReportDateModel newFinDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Project Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public DateTime? ProjectStartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Project End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public DateTime? ProjectEndDate { get; set; }
        //Collection of date extensions
        [Display(Name = "GAN Status")]
         [DataMember]
        public virtual List<GANModel> GanList { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Extended Project Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public Nullable<DateTime> ExtendedProjectDate { get; set; }
        [Display(Name = "Award Amount")]
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
         [DataMember]
        public decimal AwardAmount { get; set; }
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
         [DataMember]
        public decimal Expenditures { get; set; }
        //public decimal RemainingBalance { get; set; }
        [Display(Name = "Award Contract Number")]                                                                                  
        [MaxLength(255)]
         [DataMember]
        public string AwardContractNumber { get; set; }
        [MaxLength(32)]
        [Display(Name = "Match %")]
         [DataMember]
        public string Match { get; set; }
         [DataMember]
        public int Grantor { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Application Due Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public virtual Nullable<DateTime> ApplicationDueDate { get; set; }

        [Display(Name ="Application Status")]
         [DataMember]
        public int ApplicationStatus { get; set; }

        [Display(Name ="Grant Category")]
         [DataMember]
        public int GrantCategory { get; set; }

        [Display(Name ="Forecast")]
         [DataMember]
        public Forecast Forecast { get; set; }

        [MaxLength(35)]
        [Display(Name = "Adjustments")]
         [DataMember]
        public string Adjustments { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Award Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
         [DataMember]
        public DateTime? AwardDate { get; set; }

        [Display(Name ="Grant Type")]
         [DataMember]
        public int GrantType { get; set; }
        [NotMapped]
        [DataType(DataType.Currency)]
         [DataMember]
        public decimal totalAllocation { get; set; }

        [Display(Name = "Report Dates")]
         [DataMember]
        public virtual List<ReportDateModel> ReportDates { get; set; }

        [Display(Name = "Extension Dates")]
         [DataMember]
        public virtual List<GrantExtensionModel> ExtensionDates { get; set; }
        [Display(Name = "LDPR Project Number")]
         [DataMember]
        public virtual List<LdprModel> LdprProjectNumbers { get; set; }
         [DataMember]
        public virtual List<CommentModel> Comments { get; set; }
        [NotMapped] 
        public LdprModel tempLDPR { get; set; }
         [DataMember]
        public bool IsDeleted { get; set; }
         [DataMember]
        [MaxLength(100)]
        public string CreateBy { get; set; }
         [DataMember]
        public DateTime? CreateDate { get; set; }
        [MaxLength(100)]
         [DataMember]
        public string ModBy { get; set; }
         [DataMember]
        public DateTime? ModDate { get; set; }
        
        [NotMapped]
        public AttachmentModel tempAttachment { get; set; }
        
        [NotMapped]
        public List<AttachmentModel> Attachments { get; set; }
    }
}
