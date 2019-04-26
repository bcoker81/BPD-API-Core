using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BPD01_WebApi_Core.Domain
{
    [Table("PickLists")]
    public class PickListModel
    {
        [Key]
        public int PickListId { get; set; }
        public int Index { get; set; }
        [MaxLength(32)]
        public string PickList { get; set; }
        [MaxLength(50)]
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        [MaxLength(100)]
        public string AddBy { get; set; }
        public DateTime AddWhen { get; set; }
        [MaxLength(100)]
        public string ModBy { get; set; }
        public Nullable<DateTime> ModWhen { get; set; }
        [NotMapped]
        public List<String> pickListText { get; set; }

        [NotMapped]
        public string pickListCurrentText { get; set; }

        [NotMapped]
        public SelectList selItem { get; set; }
    }
}
