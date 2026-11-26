public class Doctor : Staff
{
    public string Specialisation { get; private set; }

    public Doctor(string name, string staffID, string department, string specialisation)
        : base(name, staffID, department)
    {
        Specialisation = specialisation;
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Doctor is diagnosing and treating patients.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Specialisation: " + Specialisation);
        PerformDuty();
    }
}
