using App.Data.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Text;

namespace App.Data
{
    internal class DataHouseDb:DbContext
    {
        public DataHouseDb()
       : base(ConfigurationManager.ConnectionStrings["libra-db"].ConnectionString)
        {
            var instanceExists = System.Data.Entity.SqlServer.SqlProviderServices.Instance != null;
            System.Data.Entity.Database.SetInitializer<DataHouseDb>(null);
        }

        public virtual DbSet<WebServiceCatch> WebServiceCatches { get; set; }
       

    }
}
