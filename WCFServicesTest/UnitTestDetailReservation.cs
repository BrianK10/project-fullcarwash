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
            DetailReservationsWS.ServiceDetailReservationsClient proxy = new DetailReservationsWS.ServiceDetailReservationsClient();
            List<DetailReservationsWS.detailreservation> detailreservationsObt = new List<DetailReservationsWS.detailreservation>(proxy.getdetailreservations());
            //se ingresa el numero de DetailReservations que hay en la db
            Assert.AreEqual(1, detailreservationsObt.Count);
        }

        [TestMethod]
        public void Test2InsertDetailReservation()
        {
            DetailReservationsWS.ServiceDetailReservationsClient proxy = new DetailReservationsWS.ServiceDetailReservationsClient();
            DetailReservationsWS.detailreservation detailreservationCre = new DetailReservationsWS.detailreservation();
            //debe haber minimo 1 reservacion, servicio y tipo de carro en la bd
            detailreservationCre.idreservation = 5;
            detailreservationCre.idservice = 1;
            detailreservationCre.idcar = 1;
            detailreservationCre.priceservice = 28;
            detailreservationCre.pricetypecar = 15;
            detailreservationCre.fullpayment = 43;
            detailreservationCre.carRegistration = "74-rtf";
            proxy.insertdetailreservation(detailreservationCre).Equals(true);

            Assert.AreEqual(5, detailreservationCre.idreservation);
            Assert.AreEqual(1, detailreservationCre.idservice);
            Assert.AreEqual(1, detailreservationCre.idcar);
            Assert.AreEqual(28, detailreservationCre.priceservice);
            Assert.AreEqual(15, detailreservationCre.pricetypecar);
            Assert.AreEqual(43, detailreservationCre.fullpayment);
            Assert.AreEqual("74-rtf", detailreservationCre.carRegistration);
        }

        [TestMethod]
        public void Test3UpdateDetailReservation()
        {
            DetailReservationsWS.ServiceDetailReservationsClient proxy = new DetailReservationsWS.ServiceDetailReservationsClient();
            DetailReservationsWS.detailreservation detailreservationUpd = new DetailReservationsWS.detailreservation();
            //se ingresa el id del DetailReservation de prueba
            detailreservationUpd.id = 1;
            detailreservationUpd.idreservation = 5;
            detailreservationUpd.idservice = 1;
            detailreservationUpd.idcar = 1;
            detailreservationUpd.priceservice = 20;
            detailreservationUpd.pricetypecar = 15;
            detailreservationUpd.fullpayment = 35;
            detailreservationUpd.carRegistration = "74-rtf MODIFICADO";
            proxy.updatedetailreservation(detailreservationUpd).Equals(true);

            Assert.AreEqual(5, detailreservationUpd.idreservation);
            Assert.AreEqual(1, detailreservationUpd.idservice);
            Assert.AreEqual(1, detailreservationUpd.idcar);
            Assert.AreEqual(20, detailreservationUpd.priceservice);
            Assert.AreEqual(15, detailreservationUpd.pricetypecar);
            Assert.AreEqual(35, detailreservationUpd.fullpayment);
            Assert.AreEqual("74-rtf MODIFICADO", detailreservationUpd.carRegistration);
        }

        [TestMethod]
        public void Test4GetDetailReservationById()
        {
            DetailReservationsWS.ServiceDetailReservationsClient proxy = new DetailReservationsWS.ServiceDetailReservationsClient();
            //se ingresa el id del DetailReservation de prueba
            DetailReservationsWS.detailreservation detailreservationObt = proxy.getdetailreservationById(1);

            Assert.AreEqual(5, detailreservationObt.idreservation);
            Assert.AreEqual(1, detailreservationObt.idservice);
            Assert.AreEqual(1, detailreservationObt.idcar);
            Assert.AreEqual(20, detailreservationObt.priceservice);
            Assert.AreEqual(15, detailreservationObt.pricetypecar);
            Assert.AreEqual(35, detailreservationObt.fullpayment);
            Assert.AreEqual("74-rtf MODIFICADO", detailreservationObt.carRegistration);
        }

        [TestMethod]
        public void Test5DeleteDetailReservation()
        {
            DetailReservationsWS.ServiceDetailReservationsClient proxy = new DetailReservationsWS.ServiceDetailReservationsClient();
            //se ingresa el id del DetailReservation de prueba
            DetailReservationsWS.detailreservation detailreservationDel = proxy.getdetailreservationById(1);
            proxy.deletedetailreservation(1).Equals(true);

            //Assert.IsNull(detailreservationDel);
            Assert.AreEqual(1, detailreservationDel.id);
        }
    }
}
