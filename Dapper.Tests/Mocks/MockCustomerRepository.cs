using System;
using System.Collections.Generic;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Queries;
using Dapper.Domain.StoreContext.Repositories;

namespace Dapper.Tests.Mocks
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
        }

        public IEnumerable<ListCustumerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public CustomerQueryResult Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}