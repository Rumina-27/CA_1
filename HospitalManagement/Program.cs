
using System;
using System.Collections.Generic;

public class Program
{
    // Store all staff members
    public static List<Staff> staffList = new List<Staff>();

    // Main method
    static void Main(string[] args)
    {
        int choice = -1;

        do
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("           STAFF MANAGEMENT");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Add Nurse");
            Console.WriteLine("3. Add Administrative Staff");
            Console.WriteLine("4. Display All Staff");
            Console.WriteLine("5. Search Staff");
            Console.WriteLine("0. Exit");
            Console.WriteLine("========================================");

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
                    AddDoctor();
                    break;

                case 2:
                    AddNurse();
                    break;

                case 3:
                    AddAdministrativeStaff();
                    break;

                case 4:
                    DisplayAllStaff();
                    break;

                case 5:
                    SearchStaff();
                    break;

                case 0:
                    Console.WriteLine("Thank you for using Staff Management!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

        } while (choice != 0);
    }

    // Check duplicate Staff ID
    static bool IsStaffIDAvailable(string id)
    {
        return !staffList.Exists(s =>
            s.StaffID.Equals(id, StringComparison.OrdinalIgnoreCase));
    }

    // Add Doctor
    static void AddDoctor()
    {
        Console.Write("\nEnter Doctor Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Staff ID: ");
        string id = Console.ReadLine() ?? "";

        if (!IsStaffIDAvailable(id))
        {
            Console.WriteLine("Staff ID already exists!");
            return;
        }

        Console.Write("Enter Department: ");
        string department = Console.ReadLine() ?? "";

        Console.Write("Enter Specialisation: ");
        string specialisation = Console.ReadLine() ?? "";

        staffList.Add(new Doctor(name, id, department, specialisation));

        Console.WriteLine("Doctor added successfully!");
    }

    // Add Nurse
    static void AddNurse()
    {
        Console.Write("\nEnter Nurse Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Staff ID: ");
        string id = Console.ReadLine() ?? "";

        if (!IsStaffIDAvailable(id))
        {
            Console.WriteLine("Staff ID already exists!");
            return;
        }

        Console.Write("Enter Department: ");
        string department = Console.ReadLine() ?? "";

        Console.Write("Enter Shift: ");
        string shift = Console.ReadLine() ?? "";

        staffList.Add(new Nurse(name, id, department, shift));

        Console.WriteLine("Nurse added successfully!");
    }

    // Add Administrative Staff
    static void AddAdministrativeStaff()
    {
        Console.Write("\nEnter Staff Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter Staff ID: ");
        string id = Console.ReadLine() ?? "";

        if (!IsStaffIDAvailable(id))
        {
            Console.WriteLine("Staff ID already exists!");
            return;
        }

        Console.Write("Enter Department: ");
        string department = Console.ReadLine() ?? "";

        Console.Write("Enter Role: ");
        string role = Console.ReadLine() ?? "";

        staffList.Add(new AdministrativeStaff(name, id, department, role));

        Console.WriteLine("Administrative Staff added successfully!");
    }

    // Display all staff
    static void DisplayAllStaff()
    {
        if (staffList.Count == 0)
        {
            Console.WriteLine("No staff records available.");
            return;
        }

        Console.WriteLine("\n========== ALL STAFF DETAILS ==========");

        foreach (Staff staff in staffList)
        {
            Console.WriteLine("----------------------------------------");
            staff.DisplayDetails();
        }
    }

    // Search staff through menu
    static void SearchStaff()
    {
        Console.Write("\nEnter Staff ID to search: ");
        string id = Console.ReadLine() ?? "";

        bool result = SearchStaff(id);

        if (result)
        {
            Staff? staff = staffList.Find(s =>
                s.StaffID.Equals(id, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("\nStaff member found!");
            staff?.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Staff member not found.");
        }
    }

    // Boolean method: returns true or false
    public static bool SearchStaff(string id)
    {
        return staffList.Exists(s =>
            s.StaffID.Equals(id, StringComparison.OrdinalIgnoreCase));
    }
}
