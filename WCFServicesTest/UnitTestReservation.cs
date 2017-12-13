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
            ReservationWS.ServiceReservationClient proxy = new ReservationWS.ServiceReservationClient();
            List<ReservationWS.reservations> reservationsObt = new List<ReservationWS.reservations>(proxy.getreservation());
            //se ingresa el numero de reservaciones que hay en la db
            Assert.AreEqual(0, reservationsObt.Count);
        }

        [TestMethod]
        public void Test2InsertReservation()
        {
            ReservationWS.ServiceReservationClient proxy = new ReservationWS.ServiceReservationClient();
            ReservationWS.reservations reservationCre = new ReservationWS.reservations();
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
            ReservationWS.ServiceReservationClient proxy = new ReservationWS.ServiceReservationClient();
            ReservationWS.reservations reservationUpd = new ReservationWS.reservations();
            //se ingresa el id de la reservacion de prueba
            reservationUpd.id = 1;
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
            ReservationWS.ServiceReservationClient proxy = new ReservationWS.ServiceReservationClient();
            //se ingresa el id de la reservacion de prueba
            ReservationWS.reservations reservationObt = proxy.getreservationById(1);

            Assert.AreEqual(1, reservationObt.idEmployee);
            Assert.AreEqual(1, reservationObt.idCustomer);
            Assert.AreEqual(1, reservationObt.idLocal);
        }

        [TestMethod]
        public void Test5DeleteReservation()
        {
            ReservationWS.ServiceReservationClient proxy = new ReservationWS.ServiceReservationClient();
            //se ingresa el id de la reservacion de prueba
            ReservationWS.reservations reservationDel = proxy.getreservationById(1);
            proxy.deletereservation(1).Equals(true);

            Assert.IsNull(reservationDel);
        }
    }
}
