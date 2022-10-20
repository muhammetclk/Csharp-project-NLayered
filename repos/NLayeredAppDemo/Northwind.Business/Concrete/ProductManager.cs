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
    public class ProductManager
    {
        // EfProductDal _productDal = new EfProductDal();//bu sekilde newlenmesi dogru deil.

        IProductDal _productDal;//Bir IProductDal olusturdum ve kullanicinin sececegi orm ile islemler yapilacak.
        //NHibernate ile mysql veritabanina kayit olabilir.EntityFramework ile sqlserver veritabanina kayit olabilir.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //business code yazilir.
            //Bir kisi datayi cekebilirmi.Birimi uygunmu gibi kurallar yazilir.

            
            return _productDal.GetAll();
        }
    }
}
