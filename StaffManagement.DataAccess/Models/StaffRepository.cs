using StaffManagement.Models;

namespace StaffManagement.DataAccess.Models;

public class StaffRepository : IStaffRepository
{
    private readonly AppDbContext _appdbContext;

    public StaffRepository(AppDbContext appDbContext)
    {
        _appdbContext = appDbContext;
    }

    public Staff Create(Staff staff)
    {
        _appdbContext.Staffs.Add(staff);
        _appdbContext.SaveChanges();
        return staff;
    }

    public Staff Delete(int id)
    {
        var deletingStaff = _appdbContext.Staffs.FirstOrDefault(s => s.Id == id);
        if (deletingStaff != null)
        {
            _appdbContext.Remove(deletingStaff);
            _appdbContext.SaveChanges();
        }
        return deletingStaff;
    }

    public Staff Get(int id)
    {
        return _appdbContext.Staffs.FirstOrDefault(s => s.Id == id);
    }

    public Staff Update(Staff staff)
    {
        var updatedStaff = _appdbContext.Staffs.Attach(staff);
        updatedStaff.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        return staff;
    }

    public IEnumerable<Staff> GetAll()
    {
        return _appdbContext.Staffs;
    }
}
