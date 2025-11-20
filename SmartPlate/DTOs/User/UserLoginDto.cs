using System.ComponentModel.DataAnnotations;

namespace SmartPlate.DTOs.User
{
    public record class UserLoginDto
    {
        [Required] public required string Email { get; init; }
        [Required] public required string Password { get; init; }
    }
}
