using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.DTOs.Product.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .NotNull();

            RuleFor(p => p.ProductDate)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("{PropertyName} نباید از زمان حال بزرگتر باشد");

            RuleFor(product => product.ManufacturePhone)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .Matches(@"^09\d{9}$").WithMessage("شماره تلفن نامتعبر است");

            RuleFor(product => product.ManufactureEmail)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .EmailAddress().WithMessage("شماره تلفن نامتعبر است");
        }
    }
}
