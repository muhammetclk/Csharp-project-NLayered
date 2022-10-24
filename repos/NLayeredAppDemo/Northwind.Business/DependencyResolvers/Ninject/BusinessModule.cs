using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    //iplemente ettik.override Load methodu.
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            //biri sende IProductService isterse ona(to) ProductManager olustur ve ona ver anlamina geliyor.
            Bind<IProductService>().To<ProductManager>().InSingletonScope();//InSingletonScope bir kere uret heryerde kullan
            Bind<IProductDal>().To<EfProductDal>();
            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDal>().To<EfCategoryDal>();
        }
    }
}
