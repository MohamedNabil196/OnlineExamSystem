using Exam.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
	public class StudentAnswer :ForAllModels
	{
		public int QuestionId { get; set; }

		public int StudentId { get; set; }

		 public virtual Question Question { get; set; } 

		  public virtual Student Student { get; set; }
		public bool answerTF { get; set; }
		public string answerContent { get; set; }
		public bool Correct { get; set; }


	}
}
