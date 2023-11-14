using CleanArchitectureApplication.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApplication.Validators
{
    public class GetUserListValidator : AbstractValidator<GetUserListRequest>
    {
        public GetUserListValidator()
        {
            RuleFor(x => x.From).NotEmpty()
              .WithMessage("Ingrese una fecha Desde.");
            RuleFor(x => x.To).NotEmpty()
                .WithMessage("Ingrese una fecha Hasta.");
            RuleFor(x => x.From)
               .Must(FromValidDate)
               .WithMessage("La fecha desde no puede ser igual o mayor que la fecha actual.");
            RuleFor(x => x.To)
                 .Must(ToValidDate)
                 .WithMessage("La fecha hasta no puede ser menor que la fecha actual.");
            RuleFor(x => x.From)
           .Must((instance, from) => from <= instance.To)
           .WithMessage("La fecha de inicio no puede ser mayor que la fecha de finalización.");
        }

        private bool ToValidDate(DateTime? fecha)
        {
            return fecha >= DateTime.Now;
        }

        private bool FromValidDate(DateTime? fecha)
        {
            return fecha < DateTime.Now;
        }
    }
}