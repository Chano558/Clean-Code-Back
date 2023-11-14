using AutoMapper;
using CleanArchitectureApplication.Contracts;
using CleanArchitectureApplication.Models;
using CleanArchitectureApplication.Profiles;
using CleanArchitectureApplication.Validators;
using CleanArchitectureDomain.Entities;
using CleanArchitectureDomain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApplication.Handler
{
    public class GetUserListHandler : BaseHandler, IRequestHandler<GetUserListRequest, GetUserListResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<GetUserListRequest> _validator;

        public GetUserListHandler(IMapper mapper, IValidator<GetUserListRequest> validator, IUserRepository userRepository)
            : base(mapper)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public Task<GetUserListResponse> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //Aca voy al base, si falla largo una excepcion
                ControlError(_validator.Validate(request));

                var response = new GetUserListResponse
                {
                    UserList = _userRepository.GetList(request.From, request.To).Select(MapTo).ToList(),
                };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private UserDto MapTo(User user)
        {
            return _mapper.Map<UserDto>(user);
        }
    }
}