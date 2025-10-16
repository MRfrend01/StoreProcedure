using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Storeprocedur.Models;
using System.Data;

namespace Storeprocedur.Controllers
{
 public class StudentsController : Controller
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=IseOtsustad;Trusted_Connection=true;MultipleActiveResultSets=true;";

        public IActionResult Index()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudents", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = (int)reader["StudentID"],
                        Name = reader["Name"].ToString(),
                        Group = reader["Group"].ToString(),
                        AverageGrade = (decimal)reader["AverageGrade"],
                        BirthYear = (int)reader["BirthYear"],
                        Email = reader["Email"].ToString()
                    });
                }
            }

            return View(students);
        }
    }
}