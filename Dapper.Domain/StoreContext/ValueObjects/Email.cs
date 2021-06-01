using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;
            
            AddNotifications(new ValidationContract()
                .Requires()
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}