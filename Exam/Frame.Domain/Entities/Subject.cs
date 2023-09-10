using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Models;

namespace Exam.Domain.Entities
{
    public class Subject :ForAllModels
	{
		public virtual ICollection<Teacher> Teachers { get; set; }
		public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
		public virtual ICollection<Examination> Examinations { get; set; }
	}
}
