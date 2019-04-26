using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPD01_WebApi_Core.Domain
{
     [Table("Documents")]
    public class DocumentModel
    {
         [Key]
        public int DocumentId { get; set; }
        public string DocumentData { get; set; }
        public DateTime AddedDate { get; set; }
        public int FK_Attachment_Id { get; set; }
        [ForeignKey("FK_Attachment_Id")]
        public AttachmentModel Attachments { get; set; }

        public DocumentModel()
        {
            
        }
    }
}