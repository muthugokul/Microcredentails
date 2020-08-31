using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microcredentials.Data
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(int id);

        Task<int> Create(TEntity entity);

        Task<int> Update(TEntity entity);
        
        Task<int> Delete(int id);
    }
}
