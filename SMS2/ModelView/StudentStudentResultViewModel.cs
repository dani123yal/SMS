using SMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS2.ModelView
{
    public class StudentStudentResultViewModel
    {
        public StudentResult studentResultview { get; set; }
        public List<Student> studentsview { get; set; }

        public StudentStudentResultViewModel()
        {
            studentResultview = new StudentResult();
            studentsview = new List<Student>();


        }
    }
}