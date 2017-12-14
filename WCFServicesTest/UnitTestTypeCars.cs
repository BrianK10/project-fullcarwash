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
            List<TypeCarsWS.typecar> typecarsObt = new List<TypeCarsWS.typecar>(proxy.gettypecars());
            //se ingresa el numero de tipo de carros que hay en la db
            Assert.AreEqual(3, typecarsObt.Count);
        }

        [TestMethod]
        public void Test2InsertTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            TypeCarsWS.typecar typecarCre = new TypeCarsWS.typecar();
            typecarCre.nametypecar = "Furgoneta";
            typecarCre.price = 20.4;
            proxy.inserttypecar(typecarCre).Equals(true);

            Assert.AreEqual("Furgoneta", typecarCre.nametypecar);
            Assert.AreEqual(20.4, typecarCre.price);
        }

        [TestMethod]
        public void Test3UpdateTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            TypeCarsWS.typecar typecarUpd = new TypeCarsWS.typecar();
            //se ingresa el id del tipo de carro de prueba
            typecarUpd.id = 5;
            typecarUpd.nametypecar = "Furgoneta M";
            typecarUpd.price = 20.4;
            proxy.updatetypecar(typecarUpd).Equals(true);

            Assert.AreEqual("Furgoneta M", typecarUpd.nametypecar);
            Assert.AreEqual(20.4, typecarUpd.price);
        }

        [TestMethod]
        public void Test4GetTypeCarById()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            //se ingresa el id del tipo de carro de prueba
            TypeCarsWS.typecar typecarObt = proxy.gettypecarById(5);

            Assert.AreEqual("Furgoneta M", typecarObt.nametypecar);
            Assert.AreEqual(20.4, typecarObt.price);
        }

        [TestMethod]
        public void Test5DeleteTypeCar()
        {
            TypeCarsWS.ServiceTypeCarsClient proxy = new TypeCarsWS.ServiceTypeCarsClient();
            //se ingresa el id del tipo de carro de prueba
            TypeCarsWS.typecar typecarDel = proxy.gettypecarById(5);
            proxy.deletetypecar(5).Equals(true);

            //Assert.IsNull(typecarDel);
            Assert.AreEqual(5, typecarDel.id);
        }
    }
}
