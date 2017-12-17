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
        List<servicesf> getservices();
        
        [OperationContract]
        Boolean insertservice(servicesf objserv);

        [OperationContract]
        Boolean updateservice(servicesf objservice);

        [OperationContract]
        Boolean deleteservice(int id);

        [OperationContract]
        servicesf getserviceById(int id);

        [OperationContract]
        servicesf getFilterService(string _service, string _type, int _idcar);
    }

    [DataContract]
    [Serializable]

    public class servicesf
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

        private string _nameLocal;

        [DataMember]
        public string nameLocal
        {
            get { return _nameLocal; }
            set { _nameLocal = value; }
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

        private int _idCar;

        [DataMember]
        public int idCar
        {
            get { return _idCar; }
            set { _idCar = value; }
        }

        private string _nameCar;

        [DataMember]
        public string nameCar
        {
            get { return _nameCar; }
            set { _nameCar = value; }
        }
    }
}
