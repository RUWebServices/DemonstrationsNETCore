using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetCoreExample.Tests.Mocks;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Repositories;
using NetCoreExamples.Repositories.Implementations;
using NetCoreExamples.Repositories.Interfaces;

namespace NetCoreExample.Tests.RepositoryTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private ICustomerRepository _customerRepository;
        private Mock<IDataProvider> _dataProviderMock = new Mock<IDataProvider>();

        [TestInitialize]
        public void Initialize()
        {
            _dataProviderMock.Setup(method => method.GetCustomers()).Returns(FizzWare.NBuilder.Builder<Customer>.CreateListOfSize(5).Build().ToList());
            _customerRepository = new CustomerRepository(_dataProviderMock.Object);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAListOfLengthFive()
        {
            var customers = _customerRepository.GetAllCustomer();
            Assert.AreEqual(5, customers.Count());
        }
    }
}