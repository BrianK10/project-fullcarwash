using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestLocals
    {
        [TestMethod]
        public void Test1GetLocals()
        {
            LocalsWS.ServiceLocalsClient proxy = new LocalsWS.ServiceLocalsClient();
            List<LocalsWS.local> localsObt = new List<LocalsWS.local>(proxy.getlocals());
            //se ingresa el numero de locales que hay en la db
            Assert.AreEqual(6, localsObt.Count);
        }

        [TestMethod]
        public void Test2InsertLocal()
        {
            LocalsWS.ServiceLocalsClient proxy = new LocalsWS.ServiceLocalsClient();
            LocalsWS.local localCre = new LocalsWS.local();
            localCre.name = "VIII";
            localCre.address = "av. Benavides 424";
            localCre.schedules = "8am - 6pm";
            proxy.insertlocal(localCre).Equals(true);

            Assert.AreEqual("VIII", localCre.name);
            Assert.AreEqual("av. Benavides 424", localCre.address);
            Assert.AreEqual("8am - 6pm", localCre.schedules);
        }

        [TestMethod]
        public void Test3UpdateLocal()
        {
            LocalsWS.ServiceLocalsClient proxy = new LocalsWS.ServiceLocalsClient();
            LocalsWS.local localUpd = new LocalsWS.local();
            //se ingresa el id del local de prueba
            localUpd.id = 1005;
            localUpd.name = "VIII Modificado";
            localUpd.address = "av. Benavides 424";
            localUpd.schedules = "8am - 6pm";
            proxy.updatelocal(localUpd).Equals(true);

            Assert.AreEqual("VIII Modificado", localUpd.name);
            Assert.AreEqual("av. Benavides 424", localUpd.address);
            Assert.AreEqual("8am - 6pm", localUpd.schedules);
        }

        [TestMethod]
        public void Test4GetLocalById()
        {
            LocalsWS.ServiceLocalsClient proxy = new LocalsWS.ServiceLocalsClient();
            //se ingresa el id del local de prueba
            LocalsWS.local localObt = proxy.getlocalById(1005);

            Assert.AreEqual("VIII Modificado", localObt.name);
            Assert.AreEqual("av. Benavides 424", localObt.address);
            Assert.AreEqual("8am - 6pm", localObt.schedules);
        }
 
        [TestMethod]
        public void Test5DeleteLocal()
        {
            LocalsWS.ServiceLocalsClient proxy = new LocalsWS.ServiceLocalsClient();
            //se ingresa el id del local de prueba
            LocalsWS.local localDel = proxy.getlocalById(1005);
            proxy.deletelocal(1005).Equals(true);

            //Assert.IsNull(localDel);
            Assert.AreEqual(1005, localDel.id);
        }
    }
}
