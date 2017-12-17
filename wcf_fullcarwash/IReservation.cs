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
    public interface IServiceReservation
    {
        [OperationContract]
        List<reservations> getreservation();
        
        [OperationContract]
        int insertreservation(reservations objreserv);

        [OperationContract]
        bool updatereservation(reservations objreserv);

        [OperationContract]
        bool deletereservation(int id);

        [OperationContract]
        reservations getreservationById(int id);

        [OperationContract]
        int getreservationByCustomer(int idCustomer);
    }

    [DataContract]
    [Serializable]

    public class reservations
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _idEmployee;
        [DataMember]
        public int idEmployee
        {
            get { return _idEmployee; }
            set { _idEmployee = value; }
        }

        private string _nameEmployee;
        [DataMember]
        public string nameEmployee
        {
            get { return _nameEmployee; }
            set { _nameEmployee = value; }
        }

        private int _idCustomer;
        [DataMember]
        public int idCustomer
        {
          get { return _idCustomer; }
          set { _idCustomer = value; }
        }

        private string _nameCustomer;
        [DataMember]
        public string nameCustomer
        {
            get { return _nameCustomer; }
            set { _nameCustomer = value; }
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
        private int _promotions;
        [DataMember]
        public int promotions
        {
            get { return _promotions; }
            set { _promotions = value; }
        }
       
    }
}

