using Microcredentials.Data;
using Microcredentials.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microcredentials.Test
{
    public class CustomerRepositoryTest : MicrocredentialsDbTestBase
    {
        #region GetAll

        [Fact]
        public async Task GetAll_Returns_CorrectType()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            // Act
            var results = await repository.GetAll();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Customer>>(results);
        }

        [Fact]
        public async Task GetAll_Returns_AllCustomer()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            // Act
            var results = await repository.GetAll();

            // Assert
            Assert.Equal(3, results.Count());
        }

        #endregion

        #region Get

        [Fact]
        public async Task Get_Returns_CorrectType()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            // Act
            var result = await repository.Get(1);

            // Assert
            Assert.IsAssignableFrom<Customer>(result);
        }

        [Fact]
        public async Task Get_Returns_Expected_Customer()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            // Act
            var result = await repository.Get(2);

            // Assert
            Assert.Equal(2, result.Id);
        }

        #endregion

        #region Create

        [Fact]
        public async Task Create_Inserts_NewCustomer()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            // Act
            await repository.Create(new Customer { Id = 4, FirstName = "Jon 4", LastName = "Paul 4", PhoneNumber = "23423412123", Email = "test4@test.com", Street = "Street 4", City = "city 4", State = "state 4", PostalCode = "code 4" });
            var actualCustomers = await repository.GetAll();

            // Assert
            Assert.Equal(4, actualCustomers.Count());
        }

        #endregion

        #region Update

        [Fact]
        public async Task Update_Saves_Customer_With_WithChanges()
        {
            // Arrange
            var repository = new CustomerRepository(dbContext);

            var customer = await repository.Get(1);
            customer.FirstName = "updated name";
            

            // Act
            await repository.Update(customer);
            var actualTask = await repository.Get(1);

            // Assert
            Assert.Equal(customer.Id, actualTask.Id);
            Assert.Equal(customer.FirstName, actualTask.FirstName);
        }

        #endregion
    }
}
