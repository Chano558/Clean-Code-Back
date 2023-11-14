using AutoMapper;
using FluentValidation.Results;

namespace CleanArchitectureApplication.Handler
{
    public class BaseHandler
    {
        internal readonly IMapper _mapper;

        public BaseHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void ControlError(ValidationResult? result)
        {
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new Exception(string.Join(",", errors));
            }
        }
    }
}