using System;
using Dapper.Domain.StoreContext.Enums;
using Dapper.Shared.Entities;

namespace Dapper.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliverydate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliverydate = estimatedDeliverydate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliverydate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //Se a data de entrega for no passado, não entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //Se o produto já tiver sido entregue, não podemos cancelar
            Status = EDeliveryStatus.Canceled;
        }
    }
}