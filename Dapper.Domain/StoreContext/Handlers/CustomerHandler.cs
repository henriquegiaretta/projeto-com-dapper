using System;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Dapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Dapper.Domain.StoreContext.Entities;
using Dapper.Domain.StoreContext.Repositories;
using Dapper.Domain.StoreContext.Services;
using Dapper.Domain.StoreContext.ValueObjects;
using Dapper.Shared.Commands;
using FluentValidator;

namespace Dapper.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
            }
            
            if (_repository.CheckEmail(command.Email))
            {
                AddNotification("Email", "Este e-mail já está em uso");
            }
            
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor, efetue a correção dos campos abaixo", Notifications);
            }
                
            _repository.Save(customer);
            _emailService.Send(email.Address, "hbgiaretta@gmail.com", "Seja Bem Vindo", "Seja bem vindo à loja");
            
            return new CommandResult(true, "Bem vindo a loja", new {Id = customer.Id, Name = name.ToString(), Email = email.Address});
        }
    
        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}