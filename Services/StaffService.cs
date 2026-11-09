using EHA_Assessment.Models;

public class StaffService
{
    private List<StaffMember> staffMembers = new()
    {
        // Sample members
        new StaffMember { StaffId = 1, FullName = "Max Cole", Email = "max@gmail.com", Position = "Programmer", Unit = "A1" },
        new StaffMember { StaffId = 2, FullName = "Caleb Smith", Email = "caleb@gmail.com", Position = "Programmer", Unit = "A2" },
        new StaffMember { StaffId = 3, FullName = "John Doe", Email = "john@gmail.com", Position = "Maintenance", Unit = "B4" },
        new StaffMember { StaffId = 4, FullName = "Carl Johnson", Email = "carl@gmail.com", Position = "Maintenance", Unit = "B1" },
        new StaffMember { StaffId = 5, FullName = "Jane Doe", Email = "jane@gmail.com", Position = "Programmer", Unit = "A2" },
        new StaffMember { StaffId = 6, FullName = "Alice Smith", Email = "alice@gmail.com", Position = "Maintenance", Unit = "B1" }
    };
    private int NextId = 7; // Next available ID for new staff members

    public void AddStaffMember(string fullName, string email, string position, string unit)
    {
        staffMembers.Add(new StaffMember
        {
            StaffId = NextId,
            FullName = fullName,
            Email = email,
            Position = position,
            Unit = unit
        });

        //increases int ID for next new member
        NextId++;
    }

    public StaffMember? RetrieveStaffMember(int staffId)
    {
        return staffMembers.FirstOrDefault(x => x.StaffId == staffId);
    }

    public List<StaffMember>? RetrieveAllStaffMembers()
    {
        return staffMembers;
    }

    public bool UpdateStaffMember(int staffId, string fullName, string email, string position, string unit)
    {
        StaffMember? updatedMember = RetrieveStaffMember(staffId);
        if (updatedMember == null)
        {
            return false;
        }

        int index = staffMembers.IndexOf(updatedMember);

        //Replaces changed details with updated ones
        if (!string.IsNullOrWhiteSpace(fullName)) updatedMember.FullName = fullName;
        if (!string.IsNullOrWhiteSpace(email)) updatedMember.Email = email;
        if (!string.IsNullOrWhiteSpace(position)) updatedMember.Position = position;
        if (!string.IsNullOrWhiteSpace(unit)) updatedMember.Unit = unit;

        //Overwrites staff member in list with updated details
        staffMembers[index] = updatedMember;
        
        return true;
    }

    public bool DeleteStaffMember(int staffId)
    {
        StaffMember? member = RetrieveStaffMember(staffId);
        if (member == null)
        {
            return false;
        }

        staffMembers.Remove(member);

        return true;
    }
}