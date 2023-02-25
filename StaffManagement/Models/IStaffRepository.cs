namespace StaffManagement.Models
{
    public interface IStaffRepository
    {
        Staff Get(int id);

        List<Staff> GetAll();

        Staff Create(Staff staff);
    }
}
