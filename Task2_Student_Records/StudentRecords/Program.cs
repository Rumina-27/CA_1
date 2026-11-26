
using System;
using System.Collections.Generic;

class Program
{
    // Dictionary to store student records
    static Dictionary<string, Student> students =
        new Dictionary<string, Student>();

    // Main method
    static void Main(string[] args)
    {
        AddSampleStudents();

        int choice = -1;

        do
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("       STUDENT RECORD SYSTEM");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Search Student");
            Console.WriteLine("2. Display Total Students");
            Console.WriteLine("0. Exit");
            Console.WriteLine("====================================");

            Console.Write("Enter your choice: ");

            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                choice = -1;
                continue;
            }

            switch (choice)
            {
                case 1:
                    SearchStudent();
                    break;

                case 2:
                    Console.WriteLine(
                        "Total Students Stored: " + students.Count);
                    break;

                case 0:
                    Console.WriteLine(
                        "Thank you for using Student Records!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 0);
    }

    // Search student using Student ID
    static void SearchStudent()
    {
        Console.Write("\nEnter Student ID: ");
        string id = Console.ReadLine() ?? "";

        if (students.ContainsKey(id))
        {
            Console.WriteLine("\nStudent record found!");
            students[id].DisplayDetails();
        }
        else
        {
            Console.WriteLine("\nStudent ID not found.");
        }
    }

    // Add 20 sample student records
    static void AddSampleStudents()
    {
        students.Add("20001010", new Student(
            "20001010", "Charles Severance",
            new int[] { 70, 65, 55, 68, 72 },
            new string[] { "B+", "B", "C", "B", "B+" }));

        students.Add("20001011", new Student(
            "20001011", "John Smith",
            new int[] { 80, 75, 69, 72, 85 },
            new string[] { "A", "B+", "B", "B+", "A" }));

        students.Add("20001012", new Student(
            "20001012", "Sarah Johnson",
            new int[] { 65, 70, 60, 75, 68 },
            new string[] { "B", "B+", "C+", "B+", "B" }));

        students.Add("20001013", new Student(
            "20001013", "Michael Brown",
            new int[] { 55, 60, 58, 62, 65 },
            new string[] { "C", "C+", "C", "C+", "B" }));

        students.Add("20001014", new Student(
            "20001014", "Emily Davis",
            new int[] { 90, 85, 88, 92, 87 },
            new string[] { "A+", "A", "A", "A+", "A" }));

        students.Add("20001015", new Student(
            "20001015", "Daniel Wilson",
            new int[] { 72, 68, 75, 70, 78 },
            new string[] { "B+", "B", "B+", "B+", "B+" }));

        students.Add("20001016", new Student(
            "20001016", "Olivia Taylor",
            new int[] { 60, 62, 65, 58, 70 },
            new string[] { "C+", "C+", "B", "C", "B+" }));

        students.Add("20001017", new Student(
            "20001017", "James Anderson",
            new int[] { 78, 82, 74, 80, 76 },
            new string[] { "B+", "A", "B+", "A", "B+" }));

        students.Add("20001018", new Student(
            "20001018", "Sophia Thomas",
            new int[] { 85, 88, 80, 84, 90 },
            new string[] { "A", "A", "A", "A", "A+" }));

        students.Add("20001019", new Student(
            "20001019", "William Moore",
            new int[] { 50, 55, 60, 52, 58 },
            new string[] { "C", "C", "C+", "C", "C" }));

        students.Add("20001020", new Student(
            "20001020", "Isabella Martin",
            new int[] { 68, 72, 70, 75, 73 },
            new string[] { "B", "B+", "B+", "B+", "B+" }));

        students.Add("20001021", new Student(
            "20001021", "Benjamin Lee",
            new int[] { 88, 90, 85, 87, 92 },
            new string[] { "A", "A+", "A", "A", "A+" }));

        students.Add("20001022", new Student(
            "20001022", "Mia White",
            new int[] { 75, 78, 72, 80, 76 },
            new string[] { "B+", "B+", "B+", "A", "B+" }));

        students.Add("20001023", new Student(
            "20001023", "Lucas Harris",
            new int[] { 62, 65, 68, 60, 66 },
            new string[] { "C+", "B", "B", "C+", "B" }));

        students.Add("20001024", new Student(
            "20001024", "Amelia Clark",
            new int[] { 82, 85, 80, 88, 84 },
            new string[] { "A", "A", "A", "A", "A" }));

        students.Add("20001025", new Student(
            "20001025", "Henry Lewis",
            new int[] { 58, 62, 55, 60, 64 },
            new string[] { "C", "C+", "C", "C+", "B" }));

        students.Add("20001026", new Student(
            "20001026", "Charlotte Walker",
            new int[] { 70, 74, 76, 72, 78 },
            new string[] { "B+", "B+", "B+", "B+", "B+" }));

        students.Add("20001027", new Student(
            "20001027", "Alexander Hall",
            new int[] { 95, 92, 90, 94, 96 },
            new string[] { "A+", "A+", "A+", "A+", "A+" }));

        students.Add("20001028", new Student(
            "20001028", "Grace Young",
            new int[] { 66, 69, 64, 70, 72 },
            new string[] { "B", "B", "B", "B+", "B+" }));

        students.Add("20001029", new Student(
            "20001029", "Ethan King",
            new int[] { 76, 73, 78, 75, 80 },
            new string[] { "B+", "B+", "B+", "B+", "A" }));
    }
}
