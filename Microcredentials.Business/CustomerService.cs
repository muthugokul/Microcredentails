using Microcredentials.Data;
using Microcredentials.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microcredentials.Business
{
    public class CustomerService : IService<Customer>
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await this.customerRepository.GetAll();
        }

        public async Task<Customer> Get(int id)
        {
            return await this.customerRepository.Get(id);
        }

        public async Task<int> Create(Customer entity)
        {
            return await this.customerRepository.Create(entity);
        }

        public async Task<int> Update(Customer entity)
        {
            return await this.customerRepository.Update(entity);
        }

        public async Task<int> Delete(int id)
        {
            return await this.customerRepository.Delete(id);
        }

    }
}
