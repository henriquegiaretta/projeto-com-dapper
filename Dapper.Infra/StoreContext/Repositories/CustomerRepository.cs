using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Queries;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Infra.StoreContext.DataContexts;

namespace Dapper.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperDataContext _context;

        public CustomerRepository(DapperDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return _context
                .Connection
                .Query<bool>(
                    "sp_CheckDocument",
                    new {Document = document},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "sp_CheckEmail",
                    new {Email = email},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<ListCustumerQueryResult> Get()
        {
            return _context
                .Connection
                .Query<ListCustumerQueryResult>(
                    "SELECT [Id], CONCATENATE([FirstName],' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer]");
        }
        
        public CustomerQueryResult Get(Guid id)
        {
            return _context
                .Connection
                .Query<CustomerQueryResult>(
                    "SELECT [Id], CONCATENATE([FirstName],' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer] WHERE [Id]=@id",
                       new {id = id}
                    )
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _context
                .Connection
                .Query<ListCustomerOrderQueryResult>(
                    "", new {id = id});
        }
    }
}