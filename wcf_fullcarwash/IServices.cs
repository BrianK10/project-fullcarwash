using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_fullcarwash
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceLocal" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceServices
    {
        [OperationContract]
        List<services> getservices();
        
        [OperationContract]
        Boolean insertservice(services objserv);

        [OperationContract]
        Boolean updateservice(services objservice);

        [OperationContract]
        Boolean deleteservice(int id);

        [OperationContract]
        services getserviceById(int id);
    }

    [DataContract]
    [Serializable]

    public class services
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _idLocal;

        [DataMember]
        public int idLocal
        {
            get { return _idLocal; }
            set { _idLocal = value; }
        }


        private string _name;

        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _typeservice;

        [DataMember]
        public string typeservice
        {
            get { return _typeservice; }
            set { _typeservice = value; }
        }

        private double _price;

        [DataMember]
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
