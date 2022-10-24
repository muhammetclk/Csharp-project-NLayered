using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        //IValidater turunde birsey yolla ve object(herhangi bir tur olabilecegi icin.)
        public static void Validate<T>(IValidator<T> validator,T entity)
        {
            
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)//hata varsa firlat
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
