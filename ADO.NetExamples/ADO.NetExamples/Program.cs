using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.NetExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionstrings = "Server=DESKTOP-82TEKUF\\SQLEXPRESS;Database=CSharpB6;User Id=csharpb6;Password=12345;";
            using SqlConnection sqlConnection = new SqlConnection(connectionstrings);

            var sql = "insert into student(name, age, weight) values('Labib',32,25.50)";
            //WriteOperation(sql, sqlConnection);
            var sql2 = "update student set name='Shipu' where name='Labib'";
            //WriteOperation(sql2, sqlConnection);

            var sql3 = "delete student where name='habib'";
            //WriteOperation(sql3, sqlConnection);

            var sql4 = "select * from student";
            var students = ReadOperation(sql4,sqlConnection);
            foreach(var student in students)
            {
                Console.WriteLine($"Id:{student.Id},Name:{student.Name},Age:{student.Age},Weight:{student.Weight}");
            }
            //using SqlCommand command = new SqlCommand(sql, sqlConnection);

            //if (sqlConnection.State != System.Data.ConnectionState.Open)
            //    sqlConnection.Open();

            //command.ExecuteNonQuery();
            Console.WriteLine("done");

        }
        static void WriteOperation(string sql, SqlConnection connection)
        {
            using SqlCommand command1 = new SqlCommand(sql, connection);
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            command1.ExecuteNonQuery();
        }
        static List<Student> ReadOperation(string sql, SqlConnection connection)
        {
            using SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();
            var students = new List<Student>();
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                var student = new Student();
                student.Id = (int)reader["Id"];
                student.Name = (string)reader["Name"];
                student.Age = (int)reader["Age"];
                student.Weight = (decimal)reader["Weight"];
                students.Add(student);
            }
            return students;
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public decimal Weight { get; set; }
        }

    }
}
