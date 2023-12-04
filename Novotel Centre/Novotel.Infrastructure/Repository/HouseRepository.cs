using Novotel.Application.Common.Interface;
using Novotel.Domain.Entities;
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
        public void Add(House entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(House entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<House> Get(Expression<Func<House, bool>> filter, string? includeProperty = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<House> GetAll(Expression<Func<House, bool>>? filter = null, string? includeProperty = null)
        {
            throw new NotImplementedException();
        }

        public void SaveEntity()
        {
            throw new NotImplementedException();
        }

        public void Update(House entity)
        {
            throw new NotImplementedException();
        }
    }
}
