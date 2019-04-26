using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BPD01_WebApi_Core.Domain
{
    [Table("GANs")]
    [DataContract]
    public class GANModel
    {
          public GANModel()
        {
            Attachments = new List<AttachmentModel>();
            TempAttachment = new AttachmentModel();
        }
        [Key]
        [DataMember]
        public int GANId { get; set; }
        [DataMember]
        public int GrantAdjustments { get; set; }
        [DataMember]

        public int GANStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Submission Date")]
        [DataMember]

        public DateTime? SubmissionDate { get; set;}
        [MaxLength(10)]
        [Display(Name ="Submission Initials")]
        [DataMember]

        public string SubmissionInitials { get; set; }
        [MaxLength(500)]
        [DataMember]

        public string GAN_Notes { get; set; }
        [DataMember]

        public int FK_Grant_Id { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> StatusList { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> AdjustmentsList { get; set; }
        [ForeignKey("FK_Grant_Id")]
        [InverseProperty("GanList")]
        public GrantModel Grant { get; set; }
        [DataMember]

        public bool IsDeleted { get; set; }
        [DataMember]

        public DateTime? AddWhen { get; set; }
        [DataMember]

        [MaxLength(100)]
        public string AddBy { get; set; }
        [DataMember]

        public DateTime? ModWhen { get; set; }
        [DataMember]

        [MaxLength(100)]
        public string ModBy { get; set; }
        [DataMember]

        [NotMapped]
        public List<AttachmentModel> Attachments { get; set; }
        [NotMapped]
        public AttachmentModel TempAttachment { get; set; }
    }
}
