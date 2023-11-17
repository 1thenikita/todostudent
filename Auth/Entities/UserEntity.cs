using System.ComponentModel.DataAnnotations;

namespace TodoStudent.Auth.Entities;

public class UserEntity
{
    [Key]
    public Guid ID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Login { get; set; }
    [Required]
    public string PasswordHash { get; set; }
}