using App.Data;
using App.Service.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace App.Service
{
    public  class WsLogWriter:ILogWriter
    {

        private readonly IConfiguration _configuration;
        public WsLogWriter(IConfiguration  configuration)
        {
            _configuration = configuration;
        }
        public  int lastLoggedId { get; private set; }
        public  void WriteWsCatch(WsCatch c)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(_configuration.GetConnectionString("OnlyLoggingAuthorizedConnection")))
            { 
            var sqlcommand = new System.Data.SqlClient.SqlCommand(queryInsert, connection);
            sqlcommand.Parameters.AddWithValue("@request_value", c.Request);
            sqlcommand.Parameters.AddWithValue("@response_value", c.Response);
            sqlcommand.Parameters.AddWithValue("@type_code", c.type);
            sqlcommand.Parameters.AddWithValue("@linked_id", c.linked_id);
            lastLoggedId = (int)sqlcommand.ExecuteScalar();
            }
        }
        private  int GetLastLoggedId()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("OnlyLoggingAuthorizedConnection")))
            {
                var sqlcommand = new SqlCommand(queryLastId , connection);
                return (int)sqlcommand.ExecuteScalar();
            }
        }
            public  void WriteLinkedWsCatches(List<WsCatch> catches)
        {
            int id = GetLastLoggedId()+1;
            foreach (WsCatch c in catches)
            {
                c.linked_id = id;
                WriteWsCatch(c);
            }
        }

        private  string queryInsert= @"INSERT INTO [dbo].[WebServiceCatch]
(
	[Id],
	[type_code],
	[request_value],
	[response_value],
	[insert_date],
	[linked_id]
)
OUTPUT Id
VALUES
(
	@Id,
	@type_code,
	@request_value
	@response_value,
	getdate(),
	@linked_id
)";
        private object connection;
        private const string queryLastId =
@"SELECT TOP(1) Id FROM [dbo].[WebServiceCatch]
ORDER BY Id DESC
OUTPUT Id";
    }
}
