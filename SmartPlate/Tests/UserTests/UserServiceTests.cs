using Xunit;
using SmartPlate.Services.UserService;
using SmartPlate.DTOs.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartPlate.Data;
using SmartPlate.Helpers;
using Moq;

namespace SmartPlate.Tests.UserTests
{
    public class UserServiceTests
    {
        private readonly UserService _service;
        private readonly UserDbContext _context;

        public UserServiceTests()
        {
            var options = new DbContextOptionsBuilder<UserDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new UserDbContext(options);

            var jwtOptions = Options.Create(new JwtSettings
            {
                Key = "TestSecretKey1234567890",
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                ExpireMinutes = 60
            });

            _service = new UserService(_context, jwtOptions);
        }

        [Fact]
        public async Task Register_ShouldCreateUser()
        {
            var dto = new UserRegisterDto
            {
                Name = "testuser",
                Password = "password123",
                Email = "test@example.com",
                Role = "User"
            };

            var user = await _service.RegisterAsync(dto);

            Assert.NotNull(user);
            Assert.Equal("testuser", user!.UserName);
        }
    }
}
