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
    public interface IServiceEmployees
    {
        [OperationContract]
        List<employee> getemployees();
        
        [OperationContract]
        bool insertemployee(employee objemp);

        [OperationContract]
        bool updateemployee(employee objem);

        [OperationContract]
        bool deleteemployee(int id);

        [OperationContract]
        employee getemployeeById(int id);

        [OperationContract]
        employee getemployeeLogin(string email, string password);
    }

    [DataContract]
    [Serializable]

    public class employee
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _firstname;

        [DataMember]
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        private string _lastname;

        [DataMember]
        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        private string _fullname;

        [DataMember]
        public string fullname
        {
            get { return _fullname; }
            set { _fullname = value; }
        }
        private bool _gender;

        [DataMember]
        public bool gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private DateTime _birthdate;

        private string _email;

        [DataMember]
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _numberdni;

        [DataMember]
        public string numberdni
        {
            get { return _numberdni; }
            set { _numberdni = value; }
        }
        
        private string _password;

        [DataMember]
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
    }
}
