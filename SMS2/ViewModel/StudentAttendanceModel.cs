using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS2.Models;

namespace SMS2.ViewModel
{
    public class StudentAttendanceModel
    {
        public StudentAttendanceModel()
        {
            student = new Student();
            AttendanceList = new List<Attendance>();
        }
        public Student student { get; set; }
        public List<Attendance> AttendanceList { get; set; }

    }
}