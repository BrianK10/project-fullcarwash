using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST_Services.Dominio;
using WCF_REST_Services.Errores;

namespace WCF_REST_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICustomers" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICustomers
    {
        //[FaultContract(typeof(DuplicadoException))]
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Customers", ResponseFormat = WebMessageFormat.Json)]
        Customer insertcustomer(Customer customerACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Customers/{idCustomer}", ResponseFormat = WebMessageFormat.Json)]
        Customer getcustomerById(string idCustomer);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Customers", ResponseFormat = WebMessageFormat.Json)]
        Customer updatecustomer(Customer customerAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Customers/{idCustomer}", ResponseFormat = WebMessageFormat.Json)]
        void deletecustomer(string idCustomer);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Customers", ResponseFormat = WebMessageFormat.Json)]
        List<Customer> getcustomers();
    }
}
