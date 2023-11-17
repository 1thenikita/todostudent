using System.ComponentModel.DataAnnotations;

namespace TodoStudent.Shared.EditModels;

public class UserEditModel
{
    public string Name { get; set; }
    public string Login { get; set; }
    [MinLength(6), MaxLength(32)]
    public string? Password { get; set; } = null!;

    [Compare(nameof(Password))] 
    public string? RepeatPassword { get; set; } = null!;
}