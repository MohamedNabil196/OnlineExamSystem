using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Models;

namespace Exam.Domain.Entities
{
    public class Examination : ForAllModels
	{
		public int SubjectId { get; set; }
		public virtual Subject? Subject { get; set; }
		public virtual ICollection<Question> Questions { get; set; }

	}
}
