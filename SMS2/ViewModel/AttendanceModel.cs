using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SMS2.Models;

namespace SMS2.ViewModel
{
    public class AttendanceModel
    {
        public AttendanceModel()
        {
            attendance = new Attendance();
            studentList = new Student();
            attendanceList = new List<AttendanceModel>();
        }
        public Attendance attendance { get; set; }

        public Student studentList { get; set; }

        public bool attStatus { get; set; }

        public int classId { get; set; }

        public List<AttendanceModel> attendanceList { get; set; }
    }
}