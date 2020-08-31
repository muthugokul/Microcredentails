using Microcredentials.Data;
using Microcredentials.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microcredentials.Test
{
    public class MicrocredentialsDbInitializer
    {
        public static void Initialize(MicrocredentialsDbContext dbContext)
        {
            if (dbContext.Customers.Any())
            {
                return;
            }

            Seed(dbContext);
        }

        private static void Seed(MicrocredentialsDbContext dbContext)
        {
            var customers = GetCustomer();

            dbContext.Customers.AddRange(customers);
            dbContext.SaveChanges();
        }

        private static IEnumerable<Customer> GetCustomer()
        {
            return CustomerFixture.Customers();
        }
    }
}
