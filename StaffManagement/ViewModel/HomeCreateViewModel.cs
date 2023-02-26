using StaffManagement.Attributes;
using StaffManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace StaffManagement.ViewModel;

public class HomeCreateViewModel
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Department")]
    public EDepartments? Department { get; set; }

    [MaxFileSize(800)]
    [AllowedExtensions(new string[] {".jpg",".png"})]
    public IFormFile? Photo { get; set; }
}
