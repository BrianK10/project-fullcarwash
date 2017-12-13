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
            LocalsWS.ServiceLocalClient proxy = new LocalsWS.ServiceLocalClient();
            List<LocalsWS.locals> localsObt = new List<LocalsWS.locals>(proxy.getlocals());
            //se ingresa el numero de locales que hay en la db
            Assert.AreEqual(4, localsObt.Count);
        }

        [TestMethod]
        public void Test2InsertLocal()
        {
            LocalsWS.ServiceLocalClient proxy = new LocalsWS.ServiceLocalClient();
            LocalsWS.locals localCre = new LocalsWS.locals();
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
            LocalsWS.ServiceLocalClient proxy = new LocalsWS.ServiceLocalClient();
            LocalsWS.locals localUpd = new LocalsWS.locals();
            //se ingresa el id del local de prueba
            localUpd.id = 5;
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
            LocalsWS.ServiceLocalClient proxy = new LocalsWS.ServiceLocalClient();
            //se ingresa el id del local de prueba
            LocalsWS.locals localObt = proxy.getlocalById(5);

            Assert.AreEqual("VIII Modificado", localObt.name);
            Assert.AreEqual("av. Benavides 424", localObt.address);
            Assert.AreEqual("8am - 6pm", localObt.schedules);
        }
 
        [TestMethod]
        public void Test5DeleteLocal()
        {
            LocalsWS.ServiceLocalClient proxy = new LocalsWS.ServiceLocalClient();
            //se ingresa el id del local de prueba
            LocalsWS.locals localDel = proxy.getlocalById(5);
            proxy.deletelocal(5).Equals(true);

            Assert.IsNull(localDel);
        }
    }
}
