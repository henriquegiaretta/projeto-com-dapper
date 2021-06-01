using System;
using System.Data;
using System.Data.SqlClient;
using Dapper.Shared;

namespace Dapper.Infra.StoreContext.DataContexts
{
    public class DapperDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DapperDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close(); 
            }
        }
    }
}