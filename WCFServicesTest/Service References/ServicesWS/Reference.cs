﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFServicesTest.ServicesWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="service", Namespace="http://schemas.datacontract.org/2004/07/wcf_fullcarwash")]
    [System.SerializableAttribute()]
    public partial class service : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idLocalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameServiceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string typeServiceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idLocal {
            get {
                return this.idLocalField;
            }
            set {
                if ((this.idLocalField.Equals(value) != true)) {
                    this.idLocalField = value;
                    this.RaisePropertyChanged("idLocal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nameService {
            get {
                return this.nameServiceField;
            }
            set {
                if ((object.ReferenceEquals(this.nameServiceField, value) != true)) {
                    this.nameServiceField = value;
                    this.RaisePropertyChanged("nameService");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string typeService {
            get {
                return this.typeServiceField;
            }
            set {
                if ((object.ReferenceEquals(this.typeServiceField, value) != true)) {
                    this.typeServiceField = value;
                    this.RaisePropertyChanged("typeService");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicesWS.IServiceServices")]
    public interface IServiceServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getservices", ReplyAction="http://tempuri.org/IServiceServices/getservicesResponse")]
        WCFServicesTest.ServicesWS.service[] getservices();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getservices", ReplyAction="http://tempuri.org/IServiceServices/getservicesResponse")]
        System.Threading.Tasks.Task<WCFServicesTest.ServicesWS.service[]> getservicesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/insertservice", ReplyAction="http://tempuri.org/IServiceServices/insertserviceResponse")]
        bool insertservice(WCFServicesTest.ServicesWS.service objserv);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/insertservice", ReplyAction="http://tempuri.org/IServiceServices/insertserviceResponse")]
        System.Threading.Tasks.Task<bool> insertserviceAsync(WCFServicesTest.ServicesWS.service objserv);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/updateservice", ReplyAction="http://tempuri.org/IServiceServices/updateserviceResponse")]
        bool updateservice(WCFServicesTest.ServicesWS.service objservice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/updateservice", ReplyAction="http://tempuri.org/IServiceServices/updateserviceResponse")]
        System.Threading.Tasks.Task<bool> updateserviceAsync(WCFServicesTest.ServicesWS.service objservice);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/deleteservice", ReplyAction="http://tempuri.org/IServiceServices/deleteserviceResponse")]
        bool deleteservice(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/deleteservice", ReplyAction="http://tempuri.org/IServiceServices/deleteserviceResponse")]
        System.Threading.Tasks.Task<bool> deleteserviceAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getserviceById", ReplyAction="http://tempuri.org/IServiceServices/getserviceByIdResponse")]
        WCFServicesTest.ServicesWS.service getserviceById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceServices/getserviceById", ReplyAction="http://tempuri.org/IServiceServices/getserviceByIdResponse")]
        System.Threading.Tasks.Task<WCFServicesTest.ServicesWS.service> getserviceByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceServicesChannel : WCFServicesTest.ServicesWS.IServiceServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceServicesClient : System.ServiceModel.ClientBase<WCFServicesTest.ServicesWS.IServiceServices>, WCFServicesTest.ServicesWS.IServiceServices {
        
        public ServiceServicesClient() {
        }
        
        public ServiceServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFServicesTest.ServicesWS.service[] getservices() {
            return base.Channel.getservices();
        }
        
        public System.Threading.Tasks.Task<WCFServicesTest.ServicesWS.service[]> getservicesAsync() {
            return base.Channel.getservicesAsync();
        }
        
        public bool insertservice(WCFServicesTest.ServicesWS.service objserv) {
            return base.Channel.insertservice(objserv);
        }
        
        public System.Threading.Tasks.Task<bool> insertserviceAsync(WCFServicesTest.ServicesWS.service objserv) {
            return base.Channel.insertserviceAsync(objserv);
        }
        
        public bool updateservice(WCFServicesTest.ServicesWS.service objservice) {
            return base.Channel.updateservice(objservice);
        }
        
        public System.Threading.Tasks.Task<bool> updateserviceAsync(WCFServicesTest.ServicesWS.service objservice) {
            return base.Channel.updateserviceAsync(objservice);
        }
        
        public bool deleteservice(int id) {
            return base.Channel.deleteservice(id);
        }
        
        public System.Threading.Tasks.Task<bool> deleteserviceAsync(int id) {
            return base.Channel.deleteserviceAsync(id);
        }
        
        public WCFServicesTest.ServicesWS.service getserviceById(int id) {
            return base.Channel.getserviceById(id);
        }
        
        public System.Threading.Tasks.Task<WCFServicesTest.ServicesWS.service> getserviceByIdAsync(int id) {
            return base.Channel.getserviceByIdAsync(id);
        }
    }
}
