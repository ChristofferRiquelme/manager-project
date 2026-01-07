using System;
using CManager.Application.Interfaces;
using CManager.Application.Services;
using CManager.Domain.Models;
using Moq;

namespace CManager.Tests.Services;

public class CustomerServiceTests
{
    [Fact]
    public void Create_Should_Assign_Id_And_Save_Customer()
    {
        // Arrange
        var mockRepo = new Mock<ICustomerRepository>();
        mockRepo
            .Setup(x => x.GetAll())
            .Returns(new List<Customer>());

        var service = new CustomerService(mockRepo.Object);

        var customer = new Customer
        {
            FirstName = "Test",
            LastName = "User",
            Email = "test@test.se"
        };

        // Act
        service.Create(customer);

        // Assert
        Assert.NotEqual(Guid.Empty, customer.Id);
        mockRepo.Verify(x => x.Save(It.IsAny<List<Customer>>()), Times.Once);
    }
}
