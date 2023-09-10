using Exam.Application.IRepository;
using Exam.Domain.Entities;

namespace Exam.Infrastructure.Repository
{
	public class FirstClassRepo : IFirstClassRepo
	{

		List<FirstClass> IFirstClassRepo.GetAll()
		{

			return new List<FirstClass>() {
				new FirstClass { id=1,Name="Mohamed",MyProperty="Hello !"},
				new FirstClass { id = 2, Name = "Ahmed", MyProperty = "Hello Again !" }
			};
		}
	}
}
