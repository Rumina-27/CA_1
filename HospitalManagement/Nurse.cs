
public class Nurse : Staff
{
    public string Shift { get; private set; }

    public Nurse(string name, string staffID, string department, string shift)
        : base(name, staffID, department)
    {
        Shift = shift;
    }

    public override void PerformDuty()
    {
        Console.WriteLine("Nurse is caring for patients and monitoring their health.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine("Shift: " + Shift);
        PerformDuty();
    }
}
