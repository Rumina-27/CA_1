
public class AdministrativeStaff : Staff
{
    public string Role { get; private set; }

    public AdministrativeStaff(string name, string staffID, string department, string role)
        : base(name, staffID, department)
    {
        Role = role;
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Administrative staff is managing hospital records and appointments.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Role: " + Role);
        PerformDuty();
    }
}
