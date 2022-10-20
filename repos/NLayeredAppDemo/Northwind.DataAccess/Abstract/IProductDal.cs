using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {//EfProduvtDal IProductDal dan implemente ediliyor.
        //suan ici bos ama IProductDal da IEntityRepositoryden implemente ediliyor.
        //burda Product IEntityRepositorye referans olarak gidiyor baska bir yerde ornegin Customerda gidebilir hale geldi.
         
    }
}
