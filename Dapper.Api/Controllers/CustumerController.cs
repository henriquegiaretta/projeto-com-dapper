using System;
using System.Collections.Generic;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Dapper.Domain.StoreContext.Handlers;
using Dapper.Domain.StoreContext.Queries;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    public class CustumerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustumerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustumerQueryResult> Get()
        {
            return _repository.Get();
        }
        
        [HttpGet]
        [Route("v1/customer/{id}/orders")]
        public CustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }
        
        [HttpGet]
        [Route("v1/customers/{id}")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }
        
        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }
    }
}