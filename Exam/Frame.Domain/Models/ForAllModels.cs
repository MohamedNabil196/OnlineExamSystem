using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Models
{
    public class ForAllModels
    {
        public int Id { get; set; }
      
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedDateInLocal { get; set; }
        public string? CreatedBy { get; set; }
        public string? CancelBy { get; set; }
        public bool? IsCanceled { get; set; } = false;
        public DateTime? CancelDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ModifyBy { get; set; }
        public int? Modifycount { get; set; }
        public string? Details { get; set; }
        public string? Path { get; set; }

    }
}
