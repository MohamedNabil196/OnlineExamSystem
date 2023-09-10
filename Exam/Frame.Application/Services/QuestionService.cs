using AutoMapper;
using Exam.Application.DTOs;
using Exam.Application.DTOs.Paggination;
using Exam.Application.DTOs.ViewModelDTO;
using Exam.Application.IRepository;
using Exam.Application.IServices;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Services
{
	public class QuestionService : IQuestionService
	{
		private readonly IRepository<Question> _questionRepo;
		private readonly IMapper _mapper;
		public QuestionService(IRepository<Question> questionRepo, IMapper mapper)
		{
            _questionRepo = questionRepo;
			_mapper = mapper;
		}

        public object Create( QuestionViewModel model)
        {
            Question question = _mapper.Map<QuestionViewModel, Question>(model);
            question.IsActive = true;
            _questionRepo.Insert(question);
            _questionRepo.Save();
			return question;
        }

        public object Delete(int id)
        {
            throw new NotImplementedException();
        }

        public object Get(int id)
        {
            throw new NotImplementedException();
        }

        public object GetAll(int page, int limit)
		{
			List<Question> Questions = new List<Question>
			{
				new Question{ Id=1,NameAr="Mohamed",IsActive=true },
				new Question{Id=2,NameAr="Mahmoud",IsActive=true},
				new Question{Id=3,NameAr="Ahmed",IsActive=true}
			};

			PagedList<GetQuestionDTO> QuestionList = Questions.AsQueryable()
				.Select(x => new GetQuestionDTO
				{
					Id = x.Id,
					NameAr = x.NameAr,
				})
				.ToPagedList(page, limit);

			//PagedList<GetPaintDTO> Paints = _PaintRepo.Get(v => v.IsActive == true).AsQueryable()
			//	.Select(x => new GetPaintDTO
			//	{
			//		Id = x.Id,
			//		NameAr = x.NameAr,
			//	})
			//	.ToPagedList(page, limit);

			return QuestionList;
		}

        public object Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
