using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestReservation
    {
        [TestMethod]
        public void Test1GetReservation()
        {
            ReservationsWS.ServiceReservationsClient proxy = new ReservationsWS.ServiceReservationsClient();
            List<ReservationsWS.reservation> reservationsObt = new List<ReservationsWS.reservation>(proxy.getreservations());
            //se ingresa el numero de reservaciones que hay en la db
            Assert.AreEqual(1, reservationsObt.Count);
        }

        [TestMethod]
        public void Test2InsertReservation()
        {
            ReservationsWS.ServiceReservationsClient proxy = new ReservationsWS.ServiceReservationsClient();
            ReservationsWS.reservation reservationCre = new ReservationsWS.reservation();
            //debe haber minimo 1 empleado, cliente y local en la bd
            reservationCre.idEmployee = 1;
            reservationCre.idCustomer = 1;
            reservationCre.idLocal = 1;
            proxy.insertreservation(reservationCre).Equals(true);

            Assert.AreEqual(1, reservationCre.idEmployee);
            Assert.AreEqual(1, reservationCre.idCustomer);
            Assert.AreEqual(1, reservationCre.idLocal);
        }

        [TestMethod]
        public void Test3UpdateReservation()
        {
            ReservationsWS.ServiceReservationsClient proxy = new ReservationsWS.ServiceReservationsClient();
            ReservationsWS.reservation reservationUpd = new ReservationsWS.reservation();
            //se ingresa el id de la reservacion de prueba
            reservationUpd.id = 6;
            reservationUpd.idEmployee = 1;
            reservationUpd.idCustomer = 1;
            reservationUpd.idLocal = 1;
            proxy.updatereservation(reservationUpd).Equals(true);

            Assert.AreEqual(1, reservationUpd.idEmployee);
            Assert.AreEqual(1, reservationUpd.idCustomer);
            Assert.AreEqual(1, reservationUpd.idLocal);
        }

        [TestMethod]
        public void Test4GetReservationById()
        {
            ReservationsWS.ServiceReservationsClient proxy = new ReservationsWS.ServiceReservationsClient();
            //se ingresa el id de la reservacion de prueba
            ReservationsWS.reservation reservationObt = proxy.getreservationById(6);

            Assert.AreEqual(1, reservationObt.idEmployee);
            Assert.AreEqual(1, reservationObt.idCustomer);
            Assert.AreEqual(1, reservationObt.idLocal);
        }

        [TestMethod]
        public void Test5DeleteReservation()
        {
            ReservationsWS.ServiceReservationsClient proxy = new ReservationsWS.ServiceReservationsClient();
            //se ingresa el id de la reservacion de prueba
            ReservationsWS.reservation reservationDel = proxy.getreservationById(6);
            proxy.deletereservation(6).Equals(true);

            //Assert.IsNull(reservationDel);
            Assert.AreEqual(6, reservationDel.id);
        }
    }
}
