using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestTypeCars
    {
        [TestMethod]
        public void Test1GetTypeCars()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            List<TypeCarsWS.typecars> typecarsObt = new List<TypeCarsWS.typecars>(proxy.gettypecars());
            //se ingresa el numero de tipo de carros que hay en la db
            Assert.AreEqual(1, typecarsObt.Count);
        }

        [TestMethod]
        public void Test2InsertTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            TypeCarsWS.typecars typecarCre = new TypeCarsWS.typecars();
            typecarCre.typecar = "Furgoneta";
            typecarCre.price = 20.4;
            proxy.inserttypecar(typecarCre).Equals(true);

            Assert.AreEqual("Furgoneta", typecarCre.typecar);
            Assert.AreEqual(20.4, typecarCre.price);
        }

        [TestMethod]
        public void Test3UpdateTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            TypeCarsWS.typecars typecarUpd = new TypeCarsWS.typecars();
            //se ingresa el id del tipo de carro de prueba
            typecarUpd.id = 1;
            typecarUpd.typecar = "Furgoneta M";
            typecarUpd.price = 20.4;
            proxy.updatetypecar(typecarUpd).Equals(true);

            Assert.AreEqual("Furgoneta M", typecarUpd.typecar);
            Assert.AreEqual(20.4, typecarUpd.price);
        }

        [TestMethod]
        public void Test4GetTypeCarById()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            //se ingresa el id del tipo de carro de prueba
            TypeCarsWS.typecars typecarObt = proxy.gettypecarById(1);

            Assert.AreEqual("Furgoneta M", typecarObt.typecar);
            Assert.AreEqual(20.4, typecarObt.price);
        }

        [TestMethod]
        public void Test5DeleteTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            //se ingresa el id del tipo de carro de prueba
            TypeCarsWS.typecars typecarDel = proxy.gettypecarById(1);
            proxy.deletetypecar(1).Equals(true);

            Assert.IsNull(typecarDel);
        }
    }
}
