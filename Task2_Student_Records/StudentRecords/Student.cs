
public class Student
{
    public string StudentID { get; set; }
    public string StudentName { get; set; }

    public int[] Marks { get; set; }
    public string[] Grades { get; set; }

    public Student(string id, string name, int[] marks, string[] grades)
    {
        StudentID = id;
        StudentName = name;
        Marks = marks;
        Grades = grades;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("\nStudent ID: " + StudentID);
        Console.WriteLine("Student Name: " + StudentName);

        string[] modules =
        {
            "Advanced Programming",
            "Advanced Databases",
            "Networking & Security",
            "Module 4",
            "Module 5"
        };

        for (int i = 0; i < Marks.Length; i++)
        {
            Console.WriteLine(
                modules[i] + " - Mark: " + Marks[i] +
                ", Grade: " + Grades[i]);
        }
    }
}
