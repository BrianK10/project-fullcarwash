using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_fullcarwash
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceLocal" en el código y en el archivo de configuración a la vez.
    public class ServiceReservation : IServiceReservation
    {
        bool value;

        public List<reservation> getreservation()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<reservation> objlstreservation = new List<reservation>();

            try
            {
                var query = model.SP_SELECT_RESERVATION();
                foreach (var result in query)
                {
                    reservation objreservation = new reservation();

                    objreservation.id = result.idReservation;
                    
                    objreservation.idEmployee = result.idEmployee;
                    objreservation.nameEmployee = result.employee;
                    
                    objreservation.idCustomer = result.idCustomer;
                    objreservation.nameCustomer = result.customer;
                    
                    objreservation.idLocal = Convert.ToInt16(result.idLocal);
                    objreservation.nameLocal = result.local;

                    objlstreservation.Add(objreservation);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlstreservation;
        }

        public bool insertreservation(reservation objreserv)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Reservation objreservation = new Reservation();

                objreservation.idReservation = objreserv.id;
                objreservation.idEmployee = objreserv.idEmployee;
                objreservation.idCustomer = objreserv.idCustomer;
                objreservation.idLocal = objreserv.idLocal;


                model.Reservation.Add(objreservation);
                model.SaveChanges();

                value = true;
            }
            catch (EntityException ex)
            {
                ex.Message.ToString();
                value = false;
            }
            return value;
        }

        public bool updatereservation(reservation objreserv)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                Reservation objres = (from objr in model.Reservation
                                      where objr.idReservation == objreserv.id
                                      select objr).FirstOrDefault();

                objres.idReservation = objreserv.id;
                objres.idEmployee = objreserv.idEmployee;
                objres.idCustomer = objreserv.idCustomer;
                objres.idLocal = objreserv.idLocal;

                model.SaveChanges();
                value = true;
            }
            catch (EntityException ex)
            {
                ex.Message.ToString();
                value = false;
            }
            return value;
        }

        public bool deletereservation(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Reservation objres = (from objr in model.Reservation
                                      where objr.idReservation == id
                                      select objr).FirstOrDefault();

                model.Reservation.Remove(objres);
                model.SaveChanges();

                value = true;

            }
            catch (EntityException ex)
            {
                ex.Message.ToString();
                value = false;
            }

            return value;
        }

        public reservation getreservationById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            reservation objreserv = new reservation();

            try
            {
                Reservation objres = (from objr in model.Reservation
                                      where objr.idReservation == id
                                      select objr).FirstOrDefault();

                objreserv.id = objres.idReservation;
                objreserv.idEmployee = objres.idEmployee;
                objreserv.idCustomer = objres.idCustomer;
                objreserv.idLocal = Convert.ToInt16(objres.idLocal);
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objreserv;
        }
    }
}

