using Exam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
	public class TeacherSubject:ForAllModels
	{
		public int TeacherId { get; set; }
		public virtual Teacher Teacher { get; set; }
		public int SubjectId { get; set; }
		public virtual Subject Subject { get; set; }
	}
}
