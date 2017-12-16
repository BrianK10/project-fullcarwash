using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_REST_Services.Dominio;
using WCF_REST_Services.Persistencia;

namespace WCF_REST_Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Customers" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Customers.svc o Customers.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Customers : ICustomers
    {
        private CustomerDAO customerDAO = new CustomerDAO();
        public Customer insertcustomer(Customer employeeACrear)
        {
            return customerDAO.Crear(employeeACrear);
        }

        public Customer getcustomerById(string idCustomer)
        {
            return customerDAO.Obtener(int.Parse(idCustomer));
        }

        public Customer updatecustomer(Customer customerAModificar)
        {
            return customerDAO.Modificar(customerAModificar);
        }

        public void deletecustomer(string idCustomer)
        {
            customerDAO.Eliminar(int.Parse(idCustomer));
        }

        public List<Customer> getcustomers()
        {
            return customerDAO.Listar();
        }
    }
}
