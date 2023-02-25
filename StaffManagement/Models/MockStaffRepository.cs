namespace StaffManagement.Models
{
    public class MockStaffRepository : IStaffRepository
    {
        private readonly List<Staff> _staffs;

        public MockStaffRepository()
        {
            _staffs = new List<Staff>()
            {
                new Staff() { Id = 1, Name = "Sardor", Department = EDepartments.Sales },
                new Staff() { Id = 2, Name = "Sarvar", Department = EDepartments.Production},
                new Staff() { Id = 3, Name = "Sanjar", Department = EDepartments.HR },
            };
        }

        public Staff Create(Staff staff)
        {
            staff.Id = _staffs.Max(x => x.Id) + 1;
            _staffs.Add(staff);
            return staff;
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
