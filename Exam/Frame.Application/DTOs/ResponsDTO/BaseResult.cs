using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.ResponsDTO
{
	public class BaseResult
	{
		public bool Success { set; get; }
		public List<string>? ErrorMessage { set; get; }

		public object? Data { get; set; }
	}

}
