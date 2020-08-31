using Microcredentials.Business;
using Microcredentials.Data;
using Microcredentials.Model;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Microcredentials.Test
{
    public class CustomerServiceTest
    {
        #region Private Fields

        private readonly Mock<IRepository<Customer>> mockRepository;
        private readonly CustomerService customerService;

        #endregion

        #region Constructor

        public CustomerServiceTest()
        {
            mockRepository = new Mock<IRepository<Customer>>();
            customerService = new CustomerService(mockRepository.Object);
        }

        #endregion

        #region GetAll

        [Fact]
        public async Task GetAll_Calls_CustomerRepository_GetAll_Once()
        {
            // Arrange && Act
            var result = await customerService.GetAll();

            // Assert
            mockRepository.Verify(r => r.GetAll(), Times.Once);
        }

        #endregion

        #region Get

        [Fact]
        public async Task Get_Calls_CustomerRepository_Get_Once()
        {
            // Arrange && Act
            var result = await customerService.Get(1);

            // Assert
            mockRepository.Verify(r => r.Get(It.IsAny<int>()), Times.Once);
        }

        #endregion

        #region Create

        [Fact]
        public async Task Create_Calls_CustomerRepository_Create_Once()
        {
            // Arrange && Act
            var result = await customerService.Create(new Customer());

            // Assert
            mockRepository.Verify(r => r.Create(It.IsAny<Customer>()), Times.Once);
        }

        #endregion

        #region Update

        [Fact]
        public async Task Update_Calls_CustomerRepository_Update_Once()
        {
            // Arrange && Act
            var result = await customerService.Update(new Customer());

            // Assert
            mockRepository.Verify(r => r.Update(It.IsAny<Customer>()), Times.Once);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_Calls_CustomerRepository_Delete_Once()
        {
            // Arrange && Act
            var result = await customerService.Delete(1);

            // Assert
            mockRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }

        #endregion
    }
}
