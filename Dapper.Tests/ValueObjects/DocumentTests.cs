using Dapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        
        public DocumentTests()
        {
            validDocument = new Document("41066309078");
            invalidDocument = new Document("12345678910");
        }
        
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            var document = new Document("12345678910");
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }
        
        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            var document = new Document("41066309078");
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}