using Dapper.Domain.StoreContext.Services;

namespace Dapper.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string @from, string subject, string body)
        {
            //TODO: Implementar
        }
    }
}