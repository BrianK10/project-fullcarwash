using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestDetailReservation
    {
        [TestMethod]
        public void Test1GetDetailReservations()
        {
            DetailReservationWS.ServiceDetailReservationClient proxy = new DetailReservationWS.ServiceDetailReservationClient();
            List<DetailReservationWS.detailreservation> detailreservationsObt = new List<DetailReservationWS.detailreservation>(proxy.getdetailreservation());
            //se ingresa el numero de DetailReservations que hay en la db
            Assert.AreEqual(4, detailreservationsObt.Count);
        }

        [TestMethod]
        public void Test2InsertDetailReservation()
        {
            DetailReservationWS.ServiceDetailReservationClient proxy = new DetailReservationWS.ServiceDetailReservationClient();
            DetailReservationWS.detailreservation detailreservationCre = new DetailReservationWS.detailreservation();
            detailreservationCre.idreservation = 1;
            detailreservationCre.idservice = 1;
            detailreservationCre.idcar = 1;
            detailreservationCre.priceservice = 28;
            detailreservationCre.pricetypecar = 15;
            detailreservationCre.fullpayment = 43;
            proxy.insertdetailreservation(detailreservationCre).Equals(true);

            Assert.AreEqual(1, detailreservationCre.idreservation);
            Assert.AreEqual(1, detailreservationCre.idservice);
            Assert.AreEqual(1, detailreservationCre.idcar);
            Assert.AreEqual(28, detailreservationCre.priceservice);
            Assert.AreEqual(15, detailreservationCre.pricetypecar);
            Assert.AreEqual(43, detailreservationCre.fullpayment);
        }

        [TestMethod]
        public void Test3UpdateDetailReservation()
        {
            DetailReservationWS.ServiceDetailReservationClient proxy = new DetailReservationWS.ServiceDetailReservationClient();
            DetailReservationWS.detailreservation detailreservationUpd = new DetailReservationWS.detailreservation();
            //se ingresa el id del DetailReservation de prueba
            detailreservationUpd.id = 5;
            detailreservationUpd.idreservation = 1;
            detailreservationUpd.idservice = 1;
            detailreservationUpd.idcar = 1;
            detailreservationUpd.priceservice = 20;
            detailreservationUpd.pricetypecar = 15;
            detailreservationUpd.fullpayment = 35;
            proxy.updatedetailreservation(detailreservationUpd).Equals(true);

            Assert.AreEqual(1, detailreservationUpd.idreservation);
            Assert.AreEqual(1, detailreservationUpd.idservice);
            Assert.AreEqual(1, detailreservationUpd.idcar);
            Assert.AreEqual(20, detailreservationUpd.priceservice);
            Assert.AreEqual(15, detailreservationUpd.pricetypecar);
            Assert.AreEqual(35, detailreservationUpd.fullpayment);
        }

        [TestMethod]
        public void Test4GetDetailReservationById()
        {
            DetailReservationWS.ServiceDetailReservationClient proxy = new DetailReservationWS.ServiceDetailReservationClient();
            //se ingresa el id del DetailReservation de prueba
            DetailReservationWS.detailreservation detailreservationObt = proxy.getdetailreservationById(5);

            Assert.AreEqual(1, detailreservationObt.idreservation);
            Assert.AreEqual(1, detailreservationObt.idservice);
            Assert.AreEqual(1, detailreservationObt.idcar);
            Assert.AreEqual(20, detailreservationObt.priceservice);
            Assert.AreEqual(15, detailreservationObt.pricetypecar);
            Assert.AreEqual(35, detailreservationObt.fullpayment);
        }

        [TestMethod]
        public void Test5DeleteDetailReservation()
        {
            DetailReservationWS.ServiceDetailReservationClient proxy = new DetailReservationWS.ServiceDetailReservationClient();
            //se ingresa el id del DetailReservation de prueba
            DetailReservationWS.detailreservation detailreservationDel = proxy.getdetailreservationById(5);
            proxy.deletedetailreservation(5).Equals(true);

            Assert.IsNull(detailreservationDel);
        }
    }
}
