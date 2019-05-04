using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BPD01_WebApi_Core.Domain
{
    [DataContract]
    [Table("PickLists")]
    public class PickListModel
    {
        [Key]
        [DataMember]
        public int PickListId { get; set; }
        [DataMember]
        public int Index { get; set; }
        [MaxLength(32)]
        [DataMember]
        public string PickList { get; set; }
        [MaxLength(50)]
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        [MaxLength(100)]
        public string AddBy { get; set; }
        [DataMember]
        public DateTime AddWhen { get; set; }
        [MaxLength(100)]
        [DataMember]
        public string ModBy { get; set; }
        [DataMember]
        public Nullable<DateTime> ModWhen { get; set; }
        [NotMapped]
        public List<String> pickListText { get; set; }

        [NotMapped]
        public string pickListCurrentText { get; set; }

        [NotMapped]
        public SelectList selItem { get; set; }
    }
}
