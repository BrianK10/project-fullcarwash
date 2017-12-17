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

        public List<reservations> getreservation()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<reservations> objlstreservation = new List<reservations>();

            try
            {
                var query = model.SP_SELECT_RESERVATION();
                foreach (var result in query)
                {
                    reservations objreservation = new reservations();

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

        public int insertreservation(reservations objreserv)
        {
            int _idReservation = 0;
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Reservation objreservation = new Reservation();

                
                objreservation.idEmployee = objreserv.idEmployee;
                objreservation.idCustomer = objreserv.idCustomer;
                objreservation.idLocal = objreserv.idLocal;


                model.Reservation.Add(objreservation);
                model.SaveChanges();

                value = true;

                List<Reservation> objres = (from objr in model.Reservation
                                      //where objr.idEmployee == objreserv.idEmployee && objr.idCustomer == objreserv.idCustomer && objr.idLocal == objreserv.idLocal
                                      select objr).OrderByDescending(x => x.idReservation).ToList();
                foreach (var item in objres)
                {
                    _idReservation = item.idReservation;
                    break;
                }                
            }
            catch (EntityException ex)
            {
                ex.Message.ToString();
                _idReservation = -1;
            }
            return _idReservation;
        }

        public bool updatereservation(reservations objreserv)
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

        public reservations getreservationById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            reservations objreserv = new reservations();

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

        public int getreservationByCustomer(int idCustomer)
        {
            int quantity = 0;
            fullcarwashEntities model = new fullcarwashEntities();
            reservations objreserv = new reservations();

            try
            {
                List<Reservation> objres = (from objr in model.Reservation
                                      where objr.idCustomer == idCustomer
                                      select objr).ToList();

                quantity = objres.Count;

                objreserv.promotions = quantity;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return quantity;
        }
    }
}

