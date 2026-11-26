public abstract class Staff
{
    // Properties
    public string Name { get; private set; }
    public string StaffID { get; private set; }
    public string Department { get; private set; }

    // Constructor
    public Staff(string name, string staffID, string department)
    {
        Name = name;
        StaffID = staffID;
        Department = department;
    }

    // Abstract method
    public abstract void PerformDuty();

    // Display staff details
    public virtual void DisplayDetails()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Staff ID: " + StaffID);
        Console.WriteLine("Department: " + Department);
    }
}
