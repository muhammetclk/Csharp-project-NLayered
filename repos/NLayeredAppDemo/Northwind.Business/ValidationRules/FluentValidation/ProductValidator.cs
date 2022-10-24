using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    //Product icin kurallar gerceklestiricez.
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();//urun ismini girmen gerekiyor.
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("categoryId bos olamaz");//mesajimizida biz belirleyebiliriz..
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);// sıfırdan buyuk olmali
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short) 0);//ilk etapta 0 olamaz.
            //int ıstiyor.Int16 oldugu icin kiziyordu.

            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId==2);
            //unitprice 10 dan buyuk olmali categoryId=2 oldugunda

            RuleFor(p => p.ProductName).Must(StartsWithA).WithMessage("ProductName A ile baslamali");//kendi methodumuzuda Must ile olusturabiliriz.
            //uzerine gelip generate ederek methodu otomatik olusturur.kuralimiz a ile baslamasini istiyor.
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");//deger dondurduk.A ile balamali.
        }
    }
}
