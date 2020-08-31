using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microcredentials.Business
{
    public interface IService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(int id);

        Task<int> Create(TEntity entity);

        Task<int> Update(TEntity entity);

        Task<int> Delete(int id);
    }
}
