using Microsoft.EntityFrameworkCore;
using Novotel.Application.Common.Interface;
using Novotel.Domain.Entities;
using Novotel.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Novotel.Infrastructure.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private readonly ApplicationDbContext _context;

        public HouseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(House entity)
        {
           _context.Add(entity);
        }

        public void Delete(House entity)
        {
            _context.Remove(entity);
        }

        public House Get(Expression<Func<House, bool>> filter, string? includeProperty = null)
        {
            IQueryable<House> query = _context.Set<House>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var includeProp in includeProperty
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<House> GetAll(Expression<Func<House, bool>>? filter = null, string? includeProperty = null)
        {
            IQueryable<House> query = _context.Set<House>();
            if(filter != null)
            {
                query = query.Where(filter);
            } 
            if(!string.IsNullOrEmpty(includeProperty))
            {
                foreach (var includeProp in includeProperty
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }   
            return query.ToList();
        }

        public void SaveEntity()
        {
            _context.SaveChanges();
        }

        public void Update(House entity)
        {
           _context.Houses.Update(entity);
        }
    }
}
