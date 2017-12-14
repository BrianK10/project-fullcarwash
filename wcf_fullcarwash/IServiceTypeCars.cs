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
        List<typecar> gettypecars();
        
        [OperationContract]
        Boolean inserttypecar(typecar objtype);

        [OperationContract]
        Boolean updatetypecar(typecar objtype);

        [OperationContract]
        Boolean deletetypecar(int id);

        [OperationContract]
        typecar gettypecarById(int id);
    }

    [DataContract]
    [Serializable]

    public class typecar
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
        public string nametypecar
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
    }
}
