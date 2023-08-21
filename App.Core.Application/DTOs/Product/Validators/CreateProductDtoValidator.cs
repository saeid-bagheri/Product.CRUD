using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .NotNull();

            RuleFor(product => product.ManufacturePhone)
                .NotEmpty().WithMessage("{PropertyName} اجباری است")
                .Matches(@"^09\d{9}$").WithMessage("شماره تلفن نامتعبر است");
        }
    }
}
