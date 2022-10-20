using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    //T yerine gelen nesne tipinde calisir.
    public  interface IEntityRepository<T>where T:class,IEntity,new()//T class olmali,Bir IEntity olmali ve newlenebilir olmali.
    {
        //urunun isminde ... gecenleri getir seklinde demek icin Lınq Expression kullaniyoruz.
        //Func ile T tipinde deger verip bana bool türünde dondur diyoruz.
        List<T> GetAll(Expression<Func<T,bool>>filter=null);//kullanici isterse filtera null verebilir.(Filtre yok anlaminda)
        T Get(Expression<Func<T,bool>>filter);//filtreye gore urunleri getir.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
