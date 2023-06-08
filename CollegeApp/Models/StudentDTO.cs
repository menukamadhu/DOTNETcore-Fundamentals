using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models;

public class StudentDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Student Name is Required")]
    [StringLength(50)]
    public string Name { get; set; }
    [EmailAddress(ErrorMessage = "Please enter valid e-mail address")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Address is Required")]
    public string Address { get; set; }
}