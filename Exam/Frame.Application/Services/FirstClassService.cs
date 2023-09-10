using Exam.Application.IRepository;
using Exam.Application.IServices;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Services
{
	public class FirstClassService :IFirstClassService
	{
		public IFirstClassRepo _firstClassRepo;
		public FirstClassService(IFirstClassRepo firstClassRepo) 
		{
			_firstClassRepo = firstClassRepo;
		}

		public List<FirstClass> GetAll()
		{
			return _firstClassRepo.GetAll();
		}
	}
}
