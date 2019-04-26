using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPD01_WebApi_Core.Domain
{
    [Table("Attachments")]
    public class AttachmentModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string FK_Table { get; set; }
        public int FK_Id { get; set; }
        [MaxLength(255)]
        public string Uri { get; set; }
        public DateTime UploadDate { get; set; }
        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        [Display(Name = "Filename")]
        [MaxLength(255)]
        public string FileName { get; set; }
        [Display(Name = "File Type")]
        [MaxLength(255)]
        public string FileType { get; set; }
        [MaxLength(100)]
        [Required]
        public string AddBy { get; set; }
        public DateTime? AddWhen { get; set; }
        [MaxLength(100)]
        public string ModBy { get; set; }
        public DateTime? ModWhen { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<DocumentModel> Documents { get; set; }
        [NotMapped]
        public int grantRedirectId { get; set; }
        [NotMapped]
        public int categoryId { get; set; }

        public AttachmentModel()
        {
            Documents = new List<DocumentModel>();
        }
    }
}
