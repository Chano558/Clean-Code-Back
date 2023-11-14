using AutoMapper;
using CleanArchitectureApplication.Contracts;
using CleanArchitectureApplication.Handler;
using CleanArchitectureApplication.Models;
using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using FluentValidation;
using Moq;

namespace TestProject
{
    public class GetUserListHandlerTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IValidator<GetUserListRequest>> _validator;
        private readonly GetUserListHandler _handler;

        public GetUserListHandlerTests()
        {
            var result = new FluentValidation.Results.ValidationResult();
            var userDto = new UserDto();
            var userList = new List<User>();

            _mapper = new Mock<IMapper>();
            _mapper.Setup(m => m.Map<UserDto>(It.IsAny<User>()));

            _validator = new Mock<IValidator<GetUserListRequest>>();
            _validator.Setup(val => val.Validate(It.IsAny<GetUserListRequest>()))
                .Returns(result);

            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(repo => repo.GetList(null, null))
                .Returns(userList);

            _handler = new GetUserListHandler(_mapper.Object, _validator.Object, _userRepository.Object);
        }

        [Fact]
        public async void GetUserListHandlerTests_ReturnOk()
        {
            var response = await _handler.Handle(new GetUserListRequest(), CancellationToken.None);

            Assert.NotNull(response);
            Assert.NotNull(response.UserList);
        }
    }
}