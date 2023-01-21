using FluentValidation;
using PMS.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.BLL.Validations
{
   public class ProductCategoryValidator: AbstractValidator<ProductCategoryDto>
    {
        public ProductCategoryValidator()
        {


            RuleFor(d => d.Name).NotNull().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz")
                .NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");

        }
    }
}
