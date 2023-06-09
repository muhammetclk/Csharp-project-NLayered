﻿using FluentValidation;
using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager:IProductService
    {
        // EfProductDal _productDal = new EfProductDal();//bu sekilde newlenmesi dogru deil.

        IProductDal _productDal;//Bir IProductDal olusturdum ve kullanicinin sececegi orm ile islemler yapilacak.
        //NHibernate ile mysql veritabanina kayit olabilir.EntityFramework ile sqlserver veritabanina kayit olabilir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);

            }
            catch 
            {

                throw new Exception("Silme gerceklesmedi.");
            }
           
        }

        public List<Product> GetAll()
        {
            //business code yazilir.
            //Bir kisi datayi cekebilirmi.Birimi uygunmu gibi kurallar yazilir.

            
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
