using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicesTest
{
    class Customer
    {
        public int idcustomer { get; set; }
        
        public string firstname { get; set; }
        
        public string lastname { get; set; }
        
        public string fullname { get; set; }
        
        public bool gender { get; set; }
        
        public DateTime birthdate { get; set; }
        
        public string phone { get; set; }
        
        public string email { get; set; }
        
        public string numberdni { get; set; }
        
        public string address { get; set; }
        
        public string password { get; set; }
    }
}
