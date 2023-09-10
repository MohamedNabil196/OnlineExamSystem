using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.IRepository
{
	public interface IFirstClassRepo
	{
		List<FirstClass> GetAll ();
	}
}
