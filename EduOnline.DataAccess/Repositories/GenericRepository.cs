using EduOnline.DataAccess.Abstract;
using EduOnline.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EduOnline.DataAccess.Repositories
{
    public class GenericRepository<T>(OnlineEduContext onlineEduContext) : IRepository<T> where T : class
    {
            public DbSet<T> Table { get => onlineEduContext.Set<T>();}

            public int Count()
            {
                return Table.Count();
            }

            public void Create(T entity)
            {
                Table.Add(entity);
                onlineEduContext.SaveChanges();
            }

            public void Delete(int id)
            {
                var entity = Table.Find(id);
                if (entity != null)
                {
                    Table.Remove(entity);
                    onlineEduContext.SaveChanges();
                }
            }

            public int FilteredCount(Expression<Func<T, bool>> predicate)
            {
                return Table.Where(predicate).Count();
            }

            public List<T> GetAll()
            {
                return Table.ToList();
            }

            public T GetByFilter(Expression<Func<T, bool>> predicate)
            {
                return Table.Where(predicate).FirstOrDefault(); 
            }

            public T GetById(int id)
            {
               var value = Table.Find(id);
                return value;
            }

            public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
            {
                return Table.ToList();
            }

            public void Update(T entity)
            {
                Table.Update(entity);
                onlineEduContext.SaveChanges();
            }
    }
}
