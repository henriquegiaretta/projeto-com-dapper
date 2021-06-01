using Dapper.Shared.Entities;

namespace Dapper.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            
            if (product.QuantityOnHand < quantity)
                AddNotification("Quantidade", "Produto não contém estoque para a quantidade informada");
           
            product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}