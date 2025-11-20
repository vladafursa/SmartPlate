using System.ComponentModel.DataAnnotations;

namespace SmartPlate.DTOs.User
{
    public record class UserResponseDto
    {
        public Guid Id { get; init; }
        [Required] public required string UserName { get; init; }
        [Required] public required string Email { get; init; }
        [Required] public required string Role { get; init; }
    }
}
