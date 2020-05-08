using App.Service.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace App.Service
{
    public static class WsLogWriter
    {
        public static int lastLoggedId { get; private set; }
        public static void WriteWsCatch(WsCatch c)
        {
            using(var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlyLoggingLimitedConnectionString"].ConnectionString))
            { 
            var sqlcommand = new SqlCommand(queryInsert, connection);
            sqlcommand.Parameters.AddWithValue("@request_value", c.Request);
            sqlcommand.Parameters.AddWithValue("@response_value", c.Response);
            sqlcommand.Parameters.AddWithValue("@type_code", c.type);
            sqlcommand.Parameters.AddWithValue("@linked_id", c.linked_id);
            sqlcommand.Parameters.AddWithValue("@insert_date",DateTime.Now);
            lastLoggedId = (int)sqlcommand.ExecuteScalar();
            }
        }
        private static int GetLastLoggedId()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OnlyLoggingLimitedConnectionString"].ConnectionString))
            {
                var sqlcommand = new SqlCommand(queryInsert, connection);
                return (int)sqlcommand.ExecuteScalar();
            }
        }
            public static void WriteLinkedWsCatches(List<WsCatch> catches)
        {
            int id = GetLastLoggedId()+1;
            foreach (WsCatch c in catches)
            {
                c.linked_id = id;
                WsLogWriter.WriteWsCatch(c);
            }
        }
        private static string queryInsert= @"INSERT INTO [dbo].[WebServiceCatch]
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
        private const string queryLastId =
@"SELECT TOP(1) Id FROM [dbo].[WebServiceCatch]
ORDER BY Id DESC
OUTPUT Id";
    }
}
