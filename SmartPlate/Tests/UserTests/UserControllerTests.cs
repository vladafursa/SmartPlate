using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using SmartPlate.Controllers;
using SmartPlate.DTOs.User;
using SmartPlate.Models;
using SmartPlate.Services.UserService;

namespace SmartPlate.Tests.UserTests
{
    public class UserControllerTests
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _userServiceMock;

        public UserControllerTests()
        {
            //Dependencies
            _userServiceMock = new Mock<IUserService>();

            //SUT
            _userController = new UserController(_userServiceMock.Object);
        }

        //registration tests
        [Fact]
        public async Task Register_ShouldReturnOk_WhenUserIsCreated()
        {
            // Arrange
            var dto = new UserRegisterDto
            {
                Name = "test",
                Password = "password",
                Email = "test@test.com",
                Role = "User"
            };

            var createdUserResponse = new UserResponseDto
            {
                UserName = "test",
                Email = "test@test.com",
                Role = "User"
            };

            _userServiceMock
                .Setup(s => s.RegisterAsync(dto))
                .ReturnsAsync(createdUserResponse);

            // Act
            var result = await _userController.Register(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserResponseDto>(okResult.Value);
            Assert.Equal("test", returnedUser.UserName);
        }

        [Fact]
        public async Task Register_ShouldReturnBadRequest_WhenUserIsNull()
        {
            // Arrange
            var dto = new UserRegisterDto
            {
                Name = "test",
                Password = "password",
                Email = "test@test.com",
                Role = "User"
            };

            _userServiceMock
                .Setup(s => s.RegisterAsync(dto))
                .ReturnsAsync((UserResponseDto)null);

            // Act
            var result = await _userController.Register(dto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Username or Email already exists.", badRequestResult.Value);
        }
    }
}
