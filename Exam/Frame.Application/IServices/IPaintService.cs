using Exam.Application.DTOs.ViewModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.IServices
{
	public interface IQuestionService
	{
		object GetAll(int page, int limit);
		object Get(int id);
		object Update(int id);
		object Create(QuestionViewModel QuestionViewModel);
		object Delete(int id);
	}
}
