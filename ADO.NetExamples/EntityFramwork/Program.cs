using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new StudentDbContext();
            #region--One to one relationship       
            //Insert Data
            var students = new Students();
            students.Name = "Mahbubul Alom";
            students.Address = "Dhaka";
            students.DateOfBirth = DateTime.Parse("12/08/1992");


            context.Students.Add(students);
            context.SaveChanges();

            //Update Data
            var id = 1;
            var findstudent = context.Students.Find(id);
            findstudent.Name = "Ajmery Jerin";
            context.SaveChanges();


            var findstudent1 = context.Students.Where(x => x.Name == "Ajmery Jerin").FirstOrDefault();
            findstudent1.Name = "Umma Ajmery Jerin";
            context.SaveChanges();

            //Delete Data
            var deleteData = context.Students.Find(2);
            context.Students.Remove(deleteData);
            context.SaveChanges();

            //Relational Database
            var newstudent = new Students();
            newstudent.Name = "Md. Mahbubul Alom";
            newstudent.Address = "Savar";
            newstudent.DateOfBirth = DateTime.Parse("02/02/2012");

            var course = new Course();
            course.Title = "C#";
            course.Fees = 8000;
            course.ClassStartDate = DateTime.Parse("02/03/2021");
            //course.EnrolledCourse = new List<Students>();
            //course.EnrolledCourse.Add(newstudent);
            context.Courses.Add(course);
            context.SaveChanges();

            var getCourse = context.Courses.Where(x => x.Title == "C#").Include("EnrolledCourse").FirstOrDefault();//Data tule anlam
            #endregion
            #region --Many to Many relation
            //Many to Many relation
            //Adding Single Data both Course and Student
           // var newstudent = new Students();
            newstudent.Name = "Md. Shohanur Rahman";
            newstudent.Address = "Mirpur";
            newstudent.DateOfBirth = DateTime.Parse("02/02/2012");

            var courseEnrollment = new CourseStudent();
            courseEnrollment.Student = newstudent;
            courseEnrollment.EnrollmentDate = DateTime.Now;

            //var course = new Course();
            course.Title = "Javascript";
            course.Fees = 8000;
            course.ClassStartDate = DateTime.Parse("02/03/2021");
            course.EnrolledStudents = new List<CourseStudent>();
            course.EnrolledStudents.Add(courseEnrollment);
            context.Courses.Add(course);
            context.SaveChanges();
            #endregion
            #region--Another approach to insert data in database
            var course1 = new Course();
            course1.Title = "React";
            course1.Fees = 6000;
            course1.ClassStartDate = DateTime.Parse("05/05/2012");
            //course1.EnrolledStudents = new List<CourseStudent>();
            //course1.EnrolledStudents.Add(course1);//

            var courseEnrollment1 = new CourseStudent();
            courseEnrollment1.Course = course1;
            courseEnrollment1.EnrollmentDate = DateTime.Now;

            var newstudent1 = new Students();
            newstudent1.Name = "Rahman";
            newstudent1.Address = "Mirpur";
            newstudent1.DateOfBirth = DateTime.Parse("02/02/2012");
            newstudent1.EnrolledCourses = new List<CourseStudent>();
            //newstudent1.EnrolledCourses = courseEnrollment1;
            newstudent1.EnrolledCourses.Add(courseEnrollment1);
            context.Students.Add(newstudent1);
            context.SaveChanges();


            #endregion
            var getCourse1 = context.Courses.Where(x => x.Title == "Javascript").Include("EnrolledStudents").Include("Topics").ToList();//Data tule nia asar jonno..
            Console.WriteLine("Students has successfully inserted");
        }
    }
}
