using Microsoft.EntityFrameworkCore;
using Microcredentials.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microcredentials.Data
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly MicrocredentialsDbContext dbContext;

        public CustomerRepository(MicrocredentialsDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await this.dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await this.dbContext.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> Create(Customer entity)
        {
            this.dbContext.Customers.Add(entity);
            await this.dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<int> Update(Customer entity)
        {
            var customer = await Get(entity.Id);

            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.PhoneNumber = entity.PhoneNumber;
            customer.Email = entity.Email;
            customer.Street = entity.Street;
            customer.City = entity.City;
            customer.State = entity.State;
            customer.PostalCode = entity.PostalCode;

            this.dbContext.Customers.Update(customer);
            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var customer = await this.Get(id);

            this.dbContext.Customers.Remove(customer);

            return await this.dbContext.SaveChangesAsync();
        }
    }

}
