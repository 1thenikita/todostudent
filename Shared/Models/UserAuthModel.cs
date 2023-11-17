using System.ComponentModel.DataAnnotations;

namespace TodoStudent.Shared.Models;

public class UserAuthModel
{
    [Required]
    public string Login { get; set; }
    [Required]
    public string Password { get; set; }
}