using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BPD01_WebApi_Core.Domain
{
    [DataContract]
    [Table("Comments")]
    public class CommentModel
    {
         [Key]
        [Display(Name = "Comment ID")]
        [DataMember]
        public int CommentId { get; set; }
        [MaxLength(2000)]
        [DataMember]

        public string Comment { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Comment Date")]
        [DataMember]

        public DateTime CommentDate { get; set; }
        [DataMember]

        public DateTime? ModWhen { get; set; }
        [MaxLength(100)]
        [DataMember]

        public string ModBy { get; set; }
        [MaxLength(100)]
        [DataMember]

        public string AddBy { get; set; }
        [DataMember]

        public int FK_Grant_Id { get; set; }
        [ForeignKey("FK_Grant_Id")]
        public GrantModel Grant { get; set; }
    }
}