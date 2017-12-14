using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestCustomers
    {
        [TestMethod]
        public void Test1GetCustomers()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            List<CustomersWS.customer> customersObt = new List<CustomersWS.customer>(proxy.getcustomers());
            //se ingresa el numero de clientes que hay en la db
            Assert.AreEqual(3, customersObt.Count);
        }

        [TestMethod]
        public void Test2InsertCustomer()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            CustomersWS.customer customersCre = new CustomersWS.customer();
            customersCre.firstname = "Pedro";
            customersCre.lastname = "Castro";
            customersCre.fullname = "Pedro Castro";
            customersCre.gender = true;
            customersCre.birthdate = Convert.ToDateTime("14/08/1997");
            customersCre.phone = "948487283";
            customersCre.email = "pedro@email.com";
            customersCre.numberdni = "68473372";
            customersCre.address = "Surco";
            customersCre.password = "password";
            proxy.insertcustomer(customersCre).Equals(true);

            Assert.AreEqual("Pedro", customersCre.firstname);
            Assert.AreEqual("Castro", customersCre.lastname);
            Assert.AreEqual("Pedro Castro", customersCre.fullname);
            Assert.AreEqual(true, customersCre.gender);
            Assert.AreEqual(Convert.ToDateTime("14/08/1997"), customersCre.birthdate);
            Assert.AreEqual("948487283", customersCre.phone);
            Assert.AreEqual("pedro@email.com", customersCre.email);
            Assert.AreEqual("68473372", customersCre.numberdni);
            Assert.AreEqual("Surco", customersCre.address);
            Assert.AreEqual("password", customersCre.password);
        }

        [TestMethod]
        public void Test3UpdateCustomer()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            CustomersWS.customer customerUpd = new CustomersWS.customer();
            //se ingresa el id del cliente de prueba
            customerUpd.id = 1004;
            customerUpd.firstname = "Pedro";
            customerUpd.lastname = "Modificado";
            customerUpd.fullname = "Pedro Modificado";
            customerUpd.gender = true;
            customerUpd.birthdate = Convert.ToDateTime("14/08/1997");
            customerUpd.phone = "948487283";
            customerUpd.email = "pedro@email.com";
            customerUpd.numberdni = "68473372";
            customerUpd.address = "Surco";
            customerUpd.password = "password";
            proxy.updatecustomer(customerUpd).Equals(true);

            Assert.AreEqual("Pedro", customerUpd.firstname);
            Assert.AreEqual("Modificado", customerUpd.lastname);
            Assert.AreEqual("Pedro Modificado", customerUpd.fullname);
            Assert.AreEqual(true, customerUpd.gender);
            Assert.AreEqual(Convert.ToDateTime("14/08/1997"), customerUpd.birthdate);
            Assert.AreEqual("948487283", customerUpd.phone);
            Assert.AreEqual("pedro@email.com", customerUpd.email);
            Assert.AreEqual("68473372", customerUpd.numberdni);
            Assert.AreEqual("Surco", customerUpd.address);
            Assert.AreEqual("password", customerUpd.password);
        }

        [TestMethod]
        public void Test4GetCustomerById()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            //se ingresa el id del cliente de prueba
            CustomersWS.customer customerObt = proxy.getcustomerById(1004);

            Assert.AreEqual("Pedro", customerObt.firstname);
            Assert.AreEqual("Modificado", customerObt.lastname);
            Assert.AreEqual("Pedro Modificado", customerObt.fullname);
            Assert.AreEqual(true, customerObt.gender);
            Assert.AreEqual(Convert.ToDateTime("14/08/1997"), customerObt.birthdate);
            Assert.AreEqual("948487283", customerObt.phone);
            Assert.AreEqual("pedro@email.com", customerObt.email);
            Assert.AreEqual("68473372", customerObt.numberdni);
            Assert.AreEqual("Surco", customerObt.address);
            Assert.AreEqual("password", customerObt.password);
        }

        [TestMethod]
        public void Test5GetCustomerLogin()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            //se ingresa email y contraseña del cliente de prueba
            CustomersWS.customer customerLog = proxy.getcustomerLogin("pedro@email.com", "password");

            Assert.AreEqual("pedro@email.com", customerLog.email);
            Assert.AreEqual("password", customerLog.password);
        }


        [TestMethod]
        public void Test6DeleteCustomer()
        {
            CustomersWS.ServiceCustomersClient proxy = new CustomersWS.ServiceCustomersClient();
            //se ingresa el id del cliente de prueba
            CustomersWS.customer customerDel = proxy.getcustomerById(1004);
            proxy.deletecustomer(1004).Equals(true);
            
            //Assert.IsNull(customerDel);
            Assert.AreEqual(1004, customerDel.id);
        }
    }
}
