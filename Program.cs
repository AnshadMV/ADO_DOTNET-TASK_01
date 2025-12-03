using System;

class Program
{
    static void Main(string[] args)
    {
        StudentRepository repo = new StudentRepository();

        while (true)
        {
            Console.WriteLine("\n--- Student Management ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. View All Students");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");

            Console.Write("Choose option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertStudent(repo);
                    break;

                case 2:
                    UpdateStudent(repo);
                    break;

                case 3:
                    ViewStudents(repo);
                    break;

                case 4:
                    DeleteStudent(repo);
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    static void InsertStudent(StudentRepository repo)
    {
        Student s = new Student();

        Console.Write("First Name: ");
        s.FirstName = Console.ReadLine();

        Console.Write("Last Name: ");
        s.LastName = Console.ReadLine();

        Console.Write("Age: ");
        s.Age = int.Parse(Console.ReadLine());

        repo.AddStudent(s);            // FIXED
        Console.WriteLine("Student inserted successfully.");
    }

    static void UpdateStudent(StudentRepository repo)
    {
        Student s = new Student();

        Console.Write("Student ID to Update: ");
        s.StudentID = int.Parse(Console.ReadLine());   // FIXED

        Console.Write("New First Name: ");
        s.FirstName = Console.ReadLine();

        Console.Write("New Last Name: ");
        s.LastName = Console.ReadLine();

        Console.Write("New Age: ");
        s.Age = int.Parse(Console.ReadLine());

        repo.UpdateStudent(s);
        Console.WriteLine("Student updated successfully.");
    }

    static void ViewStudents(StudentRepository repo)
    {
        var list = repo.GetAllStudents();   // FIXED

        Console.WriteLine("\n--- All Students ---");

        foreach (var s in list)
        {
            Console.WriteLine($"{s.StudentID} - {s.FirstName} {s.LastName} - Age: {s.Age}");
        }
    }

    static void DeleteStudent(StudentRepository repo)
    {
        Console.Write("Student ID to Delete: ");
        int id = int.Parse(Console.ReadLine());

        repo.DeleteStudent(id);
        Console.WriteLine("Student deleted successfully.");
    }
}