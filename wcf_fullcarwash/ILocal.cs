﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_fullcarwash
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceLocal" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceLocal
    {
        [OperationContract]
        List<locals> getlocals();
        
        [OperationContract]
        Boolean insertlocal(locals objloc);

        [OperationContract]
        Boolean updatelocal(locals objlocal);

        [OperationContract]
        Boolean deletelocal(int id);

        [OperationContract]
        locals getlocalById(int id);
    }

    [DataContract]
    [Serializable]

    public class locals
    {
        private int _id;

        [DataMember]
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;

        [DataMember]
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _schedules;

        [DataMember]
        public string schedules
        {
            get { return _schedules; }
            set { _schedules = value; }
        }
    }
}
