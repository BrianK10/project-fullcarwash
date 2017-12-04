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
    public interface IServiceTypeCars
    {
        [OperationContract]
        List<typecars> gettypecars();
        
        [OperationContract]
        Boolean inserttypecar(typecars objtype);

        [OperationContract]
        Boolean updatetypecar(typecars objtype);

        [OperationContract]
        Boolean deletetypecar(int id);

        [OperationContract]
        typecars gettypecarById(int id);
    }

    [DataContract]
    [Serializable]

    public class typecars
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _typecar;

        [DataMember]
        public string typecar
        {
            get { return _typecar; }
            set { _typecar = value; }
        }


        private double _price;

        [DataMember]
        public double price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _carregistration;

        [DataMember]
        public string carregistration
        {
            get { return _carregistration; }
            set { _carregistration = value; }
        }
    }
}
