using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                entity.Id = context.Brands.Count() + 1;
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                context.Brands.Remove(entity);
                context.SaveChanges();
            }
            
        }

        public Brand Get(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                return context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (CarsDatabaseContext context = new CarsDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
