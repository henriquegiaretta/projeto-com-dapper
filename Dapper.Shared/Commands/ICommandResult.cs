using System;

namespace Dapper.Shared.Commands
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        Object Data { get; set; }
    }
}