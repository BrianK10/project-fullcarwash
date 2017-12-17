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
    public interface IServiceDetailReservation
    {
        [OperationContract]
        List<detailreservation> getdetailreservation();
        
        [OperationContract]
        bool insertdetailreservation(detailreservation objdetail);

        [OperationContract]
        bool updatedetailreservation(detailreservation objdetail);

        [OperationContract]
        bool deletedetailreservation(int id);

        [OperationContract]
        detailreservation getdetailreservationById(int id);
    }

    [DataContract]
    [Serializable]

    public class detailreservation
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _idReservation;
        [DataMember]
        public int idreservation
        {
            get { return _idReservation; }
            set { _idReservation = value; }
        }

        private int _idService;
        [DataMember]
        public int idservice
        {
          get { return _idService; }
          set { _idService = value; }
        }

        private string _nameService;

        [DataMember]
        public string nameService
        {
            get { return _nameService; }
            set { _nameService = value; }
        }

        private int _idCar;
        [DataMember]
        public int idcar
        {
            get { return _idCar; }
            set { _idCar = value; }
        }

        private string _typecar;

        [DataMember]
        public string typecar
        {
            get { return _typecar; }
            set { _typecar = value; }
        }

        private double _priceService;
        [DataMember]
        public double priceservice
        {
            get { return _priceService; }
            set { _priceService = value; }
        }

        private double _priceTypeCar;
        [DataMember]
        public double pricetypecar
        {
            get { return _priceTypeCar; }
            set { _priceTypeCar = value; }
        }

        private double _fullPayment;
        [DataMember]
        public double fullpayment
        {
            get { return _fullPayment; }
            set { _fullPayment = value; }
        }

        private string _carRegistration;
        [DataMember]
        public string carRegistration
        {
            get { return _carRegistration; }
            set { _carRegistration = value; }
        }

        private string _address;
        [DataMember]
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}

