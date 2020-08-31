using Microcredentials.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microcredentials.Test
{
    public static class CustomerFixture
    {
        public static IList<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Jon 1", LastName="Paul 1", PhoneNumber = "234234", Email="test1@test.com", Street="Street 1", City="city 1", State="state 1", PostalCode="code 1" },
                new Customer { Id = 2, FirstName = "Jon 2", LastName="Paul 2", PhoneNumber = "23423434", Email="test2@test.com", Street="Street 2", City="city 2", State="state 2", PostalCode="code 2" },
                new Customer { Id = 3, FirstName = "Jon 3", LastName="Paul 3", PhoneNumber = "234234567", Email="test3@test.com", Street="Street 3", City="city31", State="state 3", PostalCode="code 3" }
            };
        }
    }
}
