using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MaxLength(50)]
        public string Name { get; set; }
 /*       [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage="email is not valid")]
        public string Email { get; set; }   */
        [Required]
        [Display(Name = "Department")]
        public EDepartments? Department { get; set; }
    }
}
