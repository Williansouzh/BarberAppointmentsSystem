using System.ComponentModel.DataAnnotations;

namespace BarberFlow.API.DTOs;

public class LoginUserDTO
{
    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [StringLength(100, ErrorMessage = "Email length can't be more than 100.")]
    public string Email { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Password length can't be more than 100.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
