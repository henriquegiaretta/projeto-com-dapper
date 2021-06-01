using FluentValidator;
using FluentValidator.Validation;

namespace Dapper.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}