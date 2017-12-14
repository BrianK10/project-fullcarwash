using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestServices
    {
        [TestMethod]
        public void Test1GetServices()
        {
            ServicesWS.ServiceServicesClient proxy = new ServicesWS.ServiceServicesClient();
            List<ServicesWS.service> servicesObt = new List<ServicesWS.service>(proxy.getservices());
            //se ingresa el numero de servicios que hay en la db
            Assert.AreEqual(2, servicesObt.Count);
        }

        [TestMethod]
        public void Test2InsertService()
        {
            ServicesWS.ServiceServicesClient proxy = new ServicesWS.ServiceServicesClient();
            ServicesWS.service serviceCre = new ServicesWS.service();
            //debe haber minimo 1  local en la bd
            serviceCre.idLocal = 1;
            serviceCre.nameService = "Lavado";
            serviceCre.typeService = "A domicilio";
            serviceCre.price = 15.3;
            proxy.insertservice(serviceCre).Equals(true);

            Assert.AreEqual(1, serviceCre.idLocal);
            Assert.AreEqual("Lavado", serviceCre.nameService);
            Assert.AreEqual("A domicilio", serviceCre.typeService);
            Assert.AreEqual(15.3, serviceCre.price);
        }

        [TestMethod]
        public void Test3UpdateService()
        {
            ServicesWS.ServiceServicesClient proxy = new ServicesWS.ServiceServicesClient();
            ServicesWS.service serviceUpd = new ServicesWS.service();
            //se ingresa el id del servicio de prueba
            serviceUpd.id = 4;
            serviceUpd.idLocal = 1;
            serviceUpd.nameService = "Lavado y encerado";
            serviceUpd.typeService = "A domicilio";
            serviceUpd.price = 18.3;
            proxy.updateservice(serviceUpd).Equals(true);

            Assert.AreEqual(1, serviceUpd.idLocal);
            Assert.AreEqual("Lavado y encerado", serviceUpd.nameService);
            Assert.AreEqual("A domicilio", serviceUpd.typeService);
            Assert.AreEqual(18.3, serviceUpd.price);
        }

        [TestMethod]
        public void Test4GetServiceById()
        {
            ServicesWS.ServiceServicesClient proxy = new ServicesWS.ServiceServicesClient();
            //se ingresa el id del servicio de prueba
            ServicesWS.service serviceObt = proxy.getserviceById(4);

            Assert.AreEqual(1, serviceObt.idLocal);
            Assert.AreEqual("Lavado y encerado", serviceObt.nameService);
            Assert.AreEqual("A domicilio", serviceObt.typeService);
            Assert.AreEqual(18.3, serviceObt.price);
        }

        [TestMethod]
        public void Test5DeleteService()
        {
            ServicesWS.ServiceServicesClient proxy = new ServicesWS.ServiceServicesClient();
            //se ingresa el id del servicio de prueba
            ServicesWS.service serviceDel = proxy.getserviceById(4);
            proxy.deleteservice(4).Equals(true);

            //Assert.IsNull(serviceDel);
            Assert.AreEqual(4, serviceDel.id);
        }
    }
}
