using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Data.Database
{
   //Actually there is no need to use EF to insert into database
   //because we only only have one table and it is about logging ws catches
   //it is recommended to insert by limited authorized connectionstring in somewhere
   //hence i will not use EF but normal way using sqlconnection class 
    [Table("WebService", Schema = "dbo")]
    public class WebServiceCatch
    {
        int Id { get; set; }
        int type_code { get; set; }
        string request_value { get; set; }
        string response_value { get; set; }
        DateTime Insert_date { get; set; }
    }
}
