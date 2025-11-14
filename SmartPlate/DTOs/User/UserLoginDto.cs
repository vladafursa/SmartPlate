using System.ComponentModel.DataAnnotations;

namespace SmartPlate.DTOs.User
{
    public record class UserLoginDto
    {
        [Required] public string Name { get; init; }
        [Required] public string Password { get; init; }
    }
}
