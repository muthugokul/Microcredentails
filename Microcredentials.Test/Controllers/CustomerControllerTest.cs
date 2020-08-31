using Microcredentials.Business;
using Microcredentials.Controllers;
using Microcredentials.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Microcredentials.Test
{
    public class CustomerControllerTest
    {
        private readonly Mock<IService<Customer>> mockCustomerService;
        private readonly CustomersController controller;

        public CustomerControllerTest()
        {
            mockCustomerService = new Mock<IService<Customer>>();
            controller = new CustomersController(mockCustomerService.Object);
        }

        #region GetAll

        [Fact]
        public async Task GetAll_Returns_AllCustomer()
        {
            // Arrange
            mockCustomerService.Setup(service => service.GetAll()).Returns(Task.FromResult<IEnumerable<Customer>>(CustomerFixture.Customers()));

            // Act
            var results = await controller.GetAll();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(results);
            var actuals = Assert.IsAssignableFrom<IEnumerable<Customer>>(objectResult.Value);
            Assert.Equal(3, actuals.Count());
        }

        [Fact]
        public async Task GetAll_Throws_InternalServerError()
        {
            // Arrange
            mockCustomerService.Setup(service => service.GetAll()).Throws(new Exception());

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
        }

        #endregion

        #region Get

        [Fact]
        public async Task Get_Returns_Expected_Customer()
        {
            // Arrange
            var customer = CustomerFixture.Customers().FirstOrDefault(x => x.Id == 1);
            mockCustomerService.Setup(service => service.Get(1)).Returns(Task.FromResult<Customer>(customer));

            // Act
            var result = await controller.Get(1);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var actual = Assert.IsAssignableFrom<Customer>(objectResult.Value);
            Assert.Equal(customer.Id, actual.Id);
        }

        [Fact]
        public async Task Get_Returns_NotFound_GivenInvalidId()
        {
            // Arrange
            mockCustomerService.Setup(service => service.Get(10)).Returns(Task.FromResult<Customer>(null));

            // Act
            var result = await controller.Get(10);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Get_Throws_InternalServerError()
        {
            // Arrange
            mockCustomerService.Setup(service => service.Get(10)).Throws(new Exception());

            // Act
            var result = await controller.Get(10);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
        }

        #endregion

        #region Create

        [Fact]
        public async Task Create_Returns_SuccessResponse()
        {
            // Arrange

            mockCustomerService.Setup(service => service.Create(It.IsAny<Customer>())).Returns(Task.FromResult<int>(1));

            // Act
            var result = await controller.Create(new Customer());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_Throws_InternalServerError()
        {
            // Arrange
            mockCustomerService.Setup(service => service.Create(It.IsAny<Customer>())).Throws(new Exception());

            // Act
            var result = await controller.Create(new Customer());

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
        }

        #endregion

        #region Put

        [Fact]
        public async Task Update_Returns_BadRequest_WhenIdIsInvalid()
        {
            // Arrange
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

            // Act
            var result = await controller.Update(100, new Customer { Id = 1 });

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Update_Returns_NotFound_WhenIdIsInvalid()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

            // Act
            var result = await controller.Update(customerToUpdate.Id, new Customer { Id = customerToUpdate.Id });

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }


        [Fact]
        public async Task Update_Returns_NoContent_When_CustomerUpdated()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(customerToUpdate));

            // Act
            var result = await controller.Update(customerToUpdate.Id, new Customer { Id = customerToUpdate.Id });

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_Throws_InternalServerError()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Throws(new Exception());

            // Act
            var result = await controller.Update(customerToUpdate.Id, new Customer { Id = customerToUpdate.Id });

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_Returns_NotFound_WhenIdIsInvalid()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

            // Act
            var result = await controller.Delete(100);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_Returns_NoContent_When_ProjectUpdated()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Returns(Task.FromResult<Customer>(customerToUpdate));

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_Throws_InternalServerError()
        {
            // Arrange
            var customerToUpdate = CustomerFixture.Customers().First();
            mockCustomerService.Setup(service => service.Get(It.IsAny<int>())).Throws(new Exception());

            // Act
            var result = await controller.Delete(2);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, (result as ObjectResult).StatusCode);
        }

        #endregion
    }
}
