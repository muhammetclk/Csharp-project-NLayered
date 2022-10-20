using Northwind.DataAccess.Abstract;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    //operasyonlari gerceklesitecek.Bize TEntity ve TContext ver IRepository icin implementasyon yapalim anlamina geliyor.
    public class EfEntityrepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()//kısıtlarin burdada tanımlanmasi gerekiyor.
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //entry metodu ile ilgili nesneye erisecek kodu yazabiliriz.
                var addedEntity = context.Entry(entity);//abone olduk.

                //bu veritabaninda yok eklenecek anlamina geliyor.
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {

            using (TContext context = new TContext())
            {
                //entry metodu ile ilgili nesneye erisecek kodu yazabiliriz.
                var DeletedEntity = context.Entry(entity);//abone olduk.

                //bu veritabaninda var silinecek anlamina geliyor.
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }//filter=null ise 1. uygula degilse 2. yazdigimiz uygula.
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {


                var updatedEntity = context.Entry(entity);//abone olduk.
                                                         //bu veritabaninda var eklenecek degisiklik yapilacak anlamina geliyor.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
