using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Enums;
using Dapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dapper.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _product;
        
        public OrderTests()
        {
            var name = new Name("Henrique", "Giaretta");
            var document = new Document("41066309078");
            var email = new Email("hbgiaretta@gmail.com");
            
            _customer = new Customer(name, document, email, "51999999999");
            _order = new Order(_customer);
            _product = new Product("Produto 1", "produto novo", "image.png", 10M, 10);
        }
        
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }
        
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }
        
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_product, 2);
            _order.AddItem(_product, 2);
            Assert.AreEqual(2, _order.Items.Count);
        }
        
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchaseFiveItems()
        {
            _order.AddItem(_product, 5);
            Assert.AreEqual(_product.QuantityOnHand, 5);
        }
        
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {   
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }
        
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }
        
        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }
        
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }
        
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            _order.AddItem(_product, 1);
            
            _order.Ship();
            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}