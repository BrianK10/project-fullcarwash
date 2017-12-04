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
        List<reservation> getreservation();
        
        [OperationContract]
        bool insertreservation(reservation objreserv);

        [OperationContract]
        bool updatereservation(reservation objreserv);

        [OperationContract]
        bool deletereservation(int id);

        [OperationContract]
        reservation getreservationById(int id);
    }

    [DataContract]
    [Serializable]

    public class reservation
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

        private int _idCustomer;
        [DataMember]
        public int idCustomer
        {
          get { return _idCustomer; }
          set { _idCustomer = value; }
        }


        private int _idLocal;
        [DataMember]
        public int idLocal
        {
            get { return _idLocal; }
            set { _idLocal = value; }
        }
        
       
    }
}

