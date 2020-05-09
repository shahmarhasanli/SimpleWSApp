using App.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace App.Data
{
    public class DataHouseDb:DbContext
    {
        public DataHouseDb(DbContextOptions<DataHouseDb> opt):base(opt)
        {

        }
       
        public virtual DbSet<WebServiceCatch> WebServiceCatches { get; set; }
       

    }
}
