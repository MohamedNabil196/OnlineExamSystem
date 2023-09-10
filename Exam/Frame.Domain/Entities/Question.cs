using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Models;

namespace Exam.Domain.Entities
{
    public class Question :ForAllModels
	{
		public int? ExaminationId { get; set; }
		public virtual Examination? Examination { get; set; }
		public virtual ICollection<Student> Students { get; set; }
		public string? QContent { get; set; }
		public TypeOfQuestion? TypeOfQuestion { get; set; }
		public bool? answerTF { get; set; }
		public string? answerContent { get; set; }
		public string? Option1 { get; set; }
		public string? Option2 { get; set; }
		public string? Option3 { get; set; }
		public string? Option4 { get; set; }
		public double? points { get; set; }
	}
}
