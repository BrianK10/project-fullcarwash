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
    public class ServiceDetailReservation : IServiceDetailReservation
    {
        bool value;
        public List<detailreservation> getdetailreservation()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<detailreservation> objlstdetail = new List<detailreservation>();

            try
            {
                var query = model.SP_SELECT_DETAILRESERVATION();
                foreach (var result in query)
                {
                    detailreservation objdetail = new detailreservation();

                    objdetail.id = result.idReservation;
                    objdetail.idreservation = result.idReservation;
                    
                    objdetail.idservice = result.idService;
                    objdetail.nameService = result.nameService;

                    objdetail.idcar = result.idCar;
                    objdetail.typecar = result.typeCar;

                    objdetail.priceservice = Convert.ToDouble(result.priceService);
                    objdetail.pricetypecar = Convert.ToDouble(result.priceTypeCar);
                    objdetail.fullpayment = Convert.ToDouble(result.fullPayment);


                    objlstdetail.Add(objdetail);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlstdetail;
        }

        public bool insertdetailreservation(detailreservation objdetail)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                DetailReservation objdet = new DetailReservation();

                objdet.idReservation = objdetail.idreservation;
                objdet.idService = objdetail.idservice;
                objdet.idCar = objdetail.idcar;
                objdet.priceService = Convert.ToDecimal(objdetail.priceservice);
                objdet.priceTypeCar = Convert.ToDecimal(objdetail.pricetypecar);
                objdet.fullPayment  = Convert.ToDecimal(objdetail.fullpayment);


                model.DetailReservation.Add(objdet);
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

        public bool updatedetailreservation(detailreservation objdetail)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                DetailReservation objdet = (from objd in model.DetailReservation
                                            where objd.idDetail == objdetail.id
                                            select objd).FirstOrDefault();

                objdet.idDetail = objdetail.id;
                objdet.idReservation = objdetail.idreservation;
                objdet.idService = objdetail.idservice;
                objdet.idCar = objdetail.idcar;

                objdet.priceService = Convert.ToDecimal(objdetail.priceservice);
                objdet.priceTypeCar = Convert.ToDecimal(objdetail.pricetypecar);
                objdet.fullPayment = Convert.ToDecimal(objdetail.fullpayment);

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

        public bool deletedetailreservation(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                DetailReservation objdet = (from objd in model.DetailReservation
                                            where objd.idDetail == id
                                            select objd).FirstOrDefault();

                model.DetailReservation.Remove(objdet);
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

        public detailreservation getdetailreservationById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            detailreservation objdetail = new detailreservation();

            try
            {
                DetailReservation objdet = (from objr in model.DetailReservation
                                      where objr.idDetail == id
                                      select objr).FirstOrDefault();

                objdetail.id = objdet.idDetail;
                objdetail.idreservation = objdet.idReservation;
                objdetail.idservice = objdet.idService;
                objdetail.idcar = objdet.idCar;

                objdetail.priceservice = Convert.ToDouble(objdet.priceService);
                objdetail.pricetypecar = Convert.ToDouble(objdet.priceTypeCar);
                objdetail.fullpayment = Convert.ToDouble(objdet.fullPayment);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objdetail;
        }
    }
}

