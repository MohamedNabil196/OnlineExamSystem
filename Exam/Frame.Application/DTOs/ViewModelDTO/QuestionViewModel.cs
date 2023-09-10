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
    public class QuestionViewModel
    {
        public int ExaminationId { get; set; }
        [Required(ErrorMessage = "Please enter Question Content")]
        public string QContent { get; set; }
        [Required(ErrorMessage = "Please enter TypeOfQuestion")]
        public TypeOfQuestion TypeOfQuestion { get; set; }
        public bool answerTF { get; set; }
        public string answerContent { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public double points { get; set; }

    }
}
