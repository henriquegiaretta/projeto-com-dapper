using System;

namespace Dapper.Domain.StoreContext.Queries
{
    public class ListCustumerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}