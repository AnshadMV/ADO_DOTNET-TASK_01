using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class StudentRepository
{

    private readonly string _connectionString =
                @"Data Source=VELLADATH\SQLEXPRESS;Initial Catalog=ADODOTNET;Integrated Security=True;TrustServerCertificate=True;";

    // INSERT
    public void AddStudent(Student s)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Students (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
            cmd.Parameters.AddWithValue("@LastName", s.LastName);
            cmd.Parameters.AddWithValue("@Age", s.Age);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // UPDATE
    public void UpdateStudent(Student s)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            string query = @"UPDATE Students 
                             SET FirstName=@FirstName, LastName=@LastName, Age=@Age 
                             WHERE StudentID=@StudentID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@StudentID", s.StudentID);
            cmd.Parameters.AddWithValue("@FirstName", s.FirstName);
            cmd.Parameters.AddWithValue("@LastName", s.LastName);
            cmd.Parameters.AddWithValue("@Age", s.Age);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // DELETE
    public void DeleteStudent(int id)
    {
        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            string query = "DELETE FROM Students WHERE StudentID=@StudentID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StudentID", id);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    // SELECT ALL
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();

        using (SqlConnection con = new SqlConnection(_connectionString))
        {
            string query = "SELECT StudentID, FirstName, LastName, Age FROM Students";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    StudentID = Convert.ToInt32(reader["StudentID"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Age = Convert.ToInt32(reader["Age"])
                });
            }
        }

        return students;
    }
}