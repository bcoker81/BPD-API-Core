using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BPD01_WebApi_Core.Domain
{
     [Table("Categories")]
     [DataContract]
    public class CategoryModel
    {
       [Key]
        [DataMember]

        public int CatId { get; set; }
        [DataMember]

        public int Agency { get; set; }
        [NotMapped]
        public string MSHPDivisionClaim { get; set; }
        [MaxLength(10)]
        [DataMember]

        public string ReportingCategory { get; set; }
        [Display(Name = "Budget Category")]
        [DataMember]

        public int CategoryClassification { get; set; }
        [MaxLength(255)]
        [DataMember]

        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [DataMember]

        public Nullable<decimal> Allocation { get; set; }
        [DataType(DataType.Currency)]
        [DataMember]

        public Nullable<decimal> Expenses { get; set; }
        [DataType(DataType.Currency)]
        [DataMember]

        public Nullable<decimal> Remaining { get; set; }
        [MaxLength(2000)]
        [DataMember]

        public string Notes { get; set; }
        [MaxLength(100)]
        [DataMember]

        public string AddBy { get; set; }
        [DataMember]

        public DateTime? AddWhen { get; set; }
        [MaxLength(100)]
        [DataMember]
        public string ModBy { get; set; }
        [Required]
        [DataMember]
        public int Division { get; set; }
        [DataMember]
        public DateTime? ModWhen { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public List<ExpenditureModel> ExpenditureList { get; set; }
        [DataMember]
        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        public virtual GrantModel Grant { get; set; }
        [NotMapped]
        [DataType(DataType.Currency)]
        public decimal BPDamount { get; set; }
        [NotMapped]
        [DataType(DataType.Currency)]
        public decimal BPDbalance { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> DivisionList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> AgencyList { get; set; }

        [NotMapped]
        public int CategorySelection { get; set; }

        public CategoryModel()
        {
            ExpenditureList = new List<ExpenditureModel>();
        }
    }
    public enum ReportingAgency
    {
        [Display(Name = "Missouri State Highway Patrol")]
        MSHP,
        [Display(Name = "Missouri Office of Prosecution Services")]
        MOPS,
        [Display(Name = "Missouri Office Of State Courts Administration")]
        OSCA,
        [Display(Name = "Missouri Department of Corrections")]
        DOC,
        [Display(Name = "Missouri Police Chiefs Association")]
        MOPCA
    }

    public enum BudgetCategory
    {
        [Display(Name = "Regular Salary & Fringe")]
        RegularSalaryFringe,
        [Display(Name = "Overtime")]
        Overtime,
        [Display(Name = "Travel")]
        Travel,
        [Display(Name = "Contractual")]
        Contractual,
        [Display(Name = "Supplies")]
        Supplies,
        [Display(Name = "Equipment")]
        Equipment,
        [Display(Name = "Other")]
        Other,
        [Display(Name = "Subaward Regular Salary & Fringe")]
        SubawardRegularSalaryFringe,
        [Display(Name = "Subaward Overtime")]
        SubawardOvertime,
        [Display(Name = "Subaward Travel")]
        SubawardTravel,
        [Display(Name = "Subaward Contractual")]
        SubawardContractual,
        [Display(Name = "Subaward Supplies")]
        SubawardSupplies,
        [Display(Name = "Subaward Equipment")]
        SubawardEquipment,
        [Display(Name = "Subaward Other")]
        SubawardOther
    }

    public enum Forecast
    {   
        [Display(Name =" ")]
        unknown,
        [Display(Name ="January")]
        january,
        [Display(Name = "February")]

        february,
        [Display(Name ="March")]
        march,
        [Display(Name ="April")]
        april,
        [Display(Name ="May")]
        may,
        [Display(Name ="June")]
        june,
        [Display(Name ="July")]
        july,
        [Display(Name ="August")]
        august,
        [Display(Name ="September")]
        september,
        [Display(Name ="October")]
        october,
        [Display(Name ="November")]
        november,
        [Display(Name ="December")]
        december
    }
}
