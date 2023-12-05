using Novotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Novotel.Application.Common.Interface
{
    public interface IHouseRepository
    {
        IEnumerable<House> GetAll(Expression<Func<House,bool>>? filter = null, string? includeProperty = null);
        House Get(Expression<Func<House, bool>> filter, string? includeProperty = null);
        void Update(House entity); 
        void Add(House entity);
        void Delete(House entity);
        void SaveEntity();
    }
}
