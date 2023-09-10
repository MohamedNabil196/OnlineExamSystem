using Exam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
	public class Admin :ForAllModels
	{
		public string UserId { get; set; }
		public virtual ApplicationUser User { get; set; }
	}
}
