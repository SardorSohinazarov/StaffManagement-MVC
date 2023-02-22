namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private readonly List<Staff> _staffs;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() { Id = 1, Name = "Sardor", Department = "Developer"},
                new Staff() { Id = 2, Name = "Sarvar", Department = "O'quvchi"},
                new Staff() { Id = 3, Name = "Sanjar", Department = "O'quvchi"},
            };
        }

        public Staff Get(int id)
        {
            return _staffs.FirstOrDefault(staff => staff.Id == id);
        }

        public List<Staff> GetAll()
        {
            return _staffs;
        }
    }
}
