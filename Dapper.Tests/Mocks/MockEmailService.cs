using Dapper.Domain.StoreContext.Services;

namespace Dapper.Tests.Mocks
{
    public class MockEmailService : IEmailService
    {
        public void Send(string to, string @from, string subject, string body)
        {
        }
    }
}