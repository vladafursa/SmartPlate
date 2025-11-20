using System.ComponentModel.DataAnnotations;


namespace SmartPlate.DTOs.User
{
    public record class UserRegisterDto
    {
        [Required][StringLength(50)] public required string Name { get; init; }
        [Required][StringLength(20)] public required string Password { get; init; }
        [Required][StringLength(20)][EmailAddress] public required string Email { get; init; }
        [StringLength(20)] public string Role { get; init; } = "User";
    }
}