using System;
using System.Collections.Generic;
using System.Text;

namespace App.Service.Models
{
    public class WsCatch
    {
        public int Id { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public Service_Type type { get; set; }
        public int linked_id { get; set; }
    }
   public enum Service_Type
    {
        Rest=1,
        Soap=2
    }
}
