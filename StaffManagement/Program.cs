using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StaffManagement.DataAccess;
using StaffManagement.DataAccess.Models;
using StaffManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddDbContextPool<AppDbContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
