using Dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Henrique";
            command.LastName = "Giaretta";
            command.Document = "21629772062";
            command.Email = "hbgiaretta@gmail.com";
            command.Phone = "51999999999";
            
            Assert.AreEqual(true, command.Valid());
        }
    }
}