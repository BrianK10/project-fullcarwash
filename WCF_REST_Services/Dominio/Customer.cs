using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_REST_Services.Dominio
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int idcustomer { get; set; }

        [DataMember]
        public string firstname { get; set; }

        [DataMember]
        public string lastname { get; set; }

        [DataMember(IsRequired = false)]
        public string fullname { get; set; }

        [DataMember]
        public bool gender { get; set; }

        [DataMember]
        public DateTime birthdate { get; set; }

        [DataMember]
        public string phone { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string numberdni { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public string password { get; set; }
    }
}