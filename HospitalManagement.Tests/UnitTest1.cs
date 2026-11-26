
using Xunit;

public class SearchStaffTests
{
    [Fact]
    public void SearchStaff_ExistingID_ReturnsTrue()
    {
        // Arrange
        Program.staffList.Clear();

        Program.staffList.Add(
            new Doctor("John", "D101", "Cardiology", "Heart Specialist")
        );

        // Act
        bool result = Program.SearchStaff("D101");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SearchStaff_NonExistingID_ReturnsFalse()
    {
        // Arrange
        Program.staffList.Clear();

        Program.staffList.Add(
            new Doctor("John", "D101", "Cardiology", "Heart Specialist")
        );

        // Act
        bool result = Program.SearchStaff("X999");

        // Assert
        Assert.False(result);
    }
}
