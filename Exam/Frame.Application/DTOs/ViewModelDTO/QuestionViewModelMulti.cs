using Exam.Domain.Entities;
using Exam.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.ViewModelDTO
{
    public class QuestionViewModelMulti
    {
        public int ExaminationId { get; set; }
        [Required(ErrorMessage = "Please enter Question Content")]
        public string QContent { get; set; }
        [Required(ErrorMessage = "Please enter TypeOfQuestion")]
        public TypeOfQuestion TypeOfQuestion { get; set; }

        [Required(ErrorMessage = "Please enter Option1")]
        public string Option1 { get; set; }
        [Required(ErrorMessage = "Please enter Option2")]

        public string Option2 { get; set; }
        [Required(ErrorMessage = "Please enter Option3")]

        public string Option3 { get; set; }
        [Required(ErrorMessage = "Please enter Option4")]

        public string Option4 { get; set; }
        public string answerContent { get; set; }

        public double points { get; set; }

    }
}
