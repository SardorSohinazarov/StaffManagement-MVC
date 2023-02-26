namespace StaffManagement.Models
{
    public interface IStaffRepository
    {
        public Staff Get(int id);

        public IEnumerable<Staff> GetAll();

        public Staff Create(Staff staff);

        public Staff Update(Staff staff);

        public Staff Delete(int id);
    }
}
