using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramwork
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Fees { get; set; }
        public DateTime ClassStartDate { get; set; }
        //public List<Students> EnrolledCourse { get; set; }//One to many relation ar jonno.
        public List<Topic> Topics { get; set; }//One to many relation
        public List<CourseStudent> EnrolledStudents { get; set; }
    }
}
