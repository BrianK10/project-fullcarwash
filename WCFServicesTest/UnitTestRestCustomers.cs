using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestRestCustomers
    {
        [TestMethod]
        public void TestRest1InsertCustomer()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Customer customerACrear = new Customer()
            {
                idcustomer = 2011,
                firstname = "Pedro",
                lastname = "León",
                fullname = "Pedro León",
                gender = true,
                birthdate = DateTime.Parse("11/04/1997"),
                phone = "948473633",
                email = "pedroleon@email.com",
                numberdni = "87478392",
                address = "Av. x, Surco",
                password = "password"
            };
            string postdata = js.Serialize(customerACrear);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
                "http://localhost:57692/Customers.svc/Customers");
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Customer customerIns = js.Deserialize<Customer>(tramaJson);
            
            Assert.AreEqual("Pedro", customerIns.firstname);
            Assert.AreEqual("León", customerIns.lastname);
            Assert.AreEqual("Pedro León", customerIns.fullname);
            Assert.AreEqual(true, customerIns.gender);
            Assert.AreEqual("11/04/1997 05:00:00 a.m.", Convert.ToString(customerIns.birthdate));
            Assert.AreEqual("948473633", customerIns.phone);
            Assert.AreEqual("pedroleon@email.com", customerIns.email);
            Assert.AreEqual("87478392", customerIns.numberdni);
            Assert.AreEqual("Av. x, Surco", customerIns.address);
            Assert.AreEqual("password", customerIns.password);
        }

        [TestMethod]
        public void TestRest2GetCustomerById()
        {
            //Se ingresa el id del cliente de prueba
            string idc = "2005";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57692/Customers.svc/Customers/"+idc);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Customer customerObt = js.Deserialize<Customer>(tramaJson);
            
            Assert.AreEqual("Pedro", customerObt.firstname);
            Assert.AreEqual("León", customerObt.lastname);
            Assert.AreEqual("Pedro León", customerObt.fullname);
            Assert.AreEqual(true, customerObt.gender);
            Assert.AreEqual("11/04/1997 05:00:00 a.m.", Convert.ToString(customerObt.birthdate));
            Assert.AreEqual("948473633", customerObt.phone);
            Assert.AreEqual("pedroleon@email.com", customerObt.email);
            Assert.AreEqual("87478392", customerObt.numberdni);
            Assert.AreEqual("Av. x, Surco", customerObt.address);
            Assert.AreEqual("password", customerObt.password);
        }

        [TestMethod]
        public void TestRest3UpdateCustomer()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Customer customerToUpdate = new Customer()
            {
                //Ingresar id de cliente de prueba
                idcustomer = 2010,
                firstname = "Pedro",
                lastname = "León Rosa",
                fullname = "Pedro León Rosa",
                gender = true,
                birthdate = DateTime.Parse("11/04/1997"),
                phone = "948473633",
                email = "pedroleon@email.com",
                numberdni = "87478392",
                address = "Av. x, Surco",
                password = "password"
            };
            string postdata = js.Serialize(customerToUpdate);
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57692/Customers.svc/Customers");
            request.Method = "PUT";
            request.ContentLength = data.Length;
            request.ContentType = "application/json";
            var requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            Customer customerUpd = js.Deserialize<Customer>(tramaJson);

            Assert.AreEqual("Pedro", customerUpd.firstname);
            Assert.AreEqual("León Rosa", customerUpd.lastname);
            Assert.AreEqual("Pedro León Rosa", customerUpd.fullname);
            Assert.AreEqual(true, customerUpd.gender);
            Assert.AreEqual("11/04/1997", customerUpd.birthdate);
            Assert.AreEqual("948473633", customerUpd.phone);
            Assert.AreEqual("pedroleon@email.com", customerUpd.email);
            Assert.AreEqual("87478392", customerUpd.numberdni);
            Assert.AreEqual("Av. x, Surco", customerUpd.address);
            Assert.AreEqual("password", customerUpd.password);
        }

        [TestMethod]
        public void TestRest4DeleteCustomer()
        {
            //Se ingresa el id del cliente de prueba
            string idc = "2005";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57692/Customers.svc/Customers/"+idc);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://localhost:57692/Customers.svc/Customers/"+idc);
            request2.Method = "GET";
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            StreamReader reader = new StreamReader(response2.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Customer customerObt = js.Deserialize<Customer>(tramaJson);
            Assert.IsNull(customerObt);
        }

        [TestMethod]
        public void TestRest5GetCostumers()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:57692/Customers.svc/Customers");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Customer> customersObt = js.Deserialize<List<Customer>>(tramaJson);
            Assert.AreEqual(7, customersObt.Count);

        }
    }
}
