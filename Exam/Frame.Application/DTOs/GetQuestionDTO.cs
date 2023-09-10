using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs
{
	public class GetQuestionDTO
	{
		public int Id { get; set; } 
		public string NameAr { get; set; } = null!;

		public string NameEn { get; set; } = null!;

		public bool IsActive { get; set; }

		
	}
}
