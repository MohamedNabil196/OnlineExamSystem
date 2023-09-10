using AutoMapper;
using Exam.Application.DTOs;
using Exam.Application.DTOs.Paggination;
using Exam.Application.DTOs.ViewModelDTO;
using Exam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<QuestionViewModel, Question>();
			CreateMap<QuestionViewModelTF, Question>();
			CreateMap<QuestionViewModelTF, QuestionViewModel>();
			CreateMap<QuestionViewModelEssay, Question>();
			CreateMap<QuestionViewModelEssay, QuestionViewModel>();
			CreateMap<QuestionViewModelMulti, Question>();
            CreateMap<QuestionViewModelMulti, QuestionViewModel>();
            CreateMap<Question, QuestionViewModel>();

            CreateMap<Question,QuestionViewModelTF>();
            CreateMap< Question, QuestionViewModelEssay>();
            CreateMap<Question, QuestionViewModelMulti>();
        }
	}
}
