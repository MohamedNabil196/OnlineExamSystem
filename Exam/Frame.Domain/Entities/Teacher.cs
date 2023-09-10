using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Models;

namespace Exam.Domain.Entities
{
    public class Teacher : ForAllModels
	{
		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
		public virtual ICollection<Subject> Subjects { get; set; }
		public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }


	}
}
