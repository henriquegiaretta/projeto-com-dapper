using Dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Dapper.Domain.StoreContext.Handlers;
using Dapper.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Henrique";
            command.LastName = "Giaretta";
            command.Document = "21629772062";
            command.Email = "hbgiaretta@gmail.com";
            command.Phone = "51999999999";
            
            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
            var result = handler.Handle(command);
            
            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}