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
    public class ServiceServices : IServiceServices
    {
        bool value;

        public List<servicesf> getservices()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<servicesf> objlstservice = new List<servicesf>();            
            
            try
            {
                var query = model.SP_SELECT_SERVICES();
                foreach (var result in query)
                {
                    servicesf objservice = new servicesf();

                    objservice.id = Convert.ToInt16(result.idService);
                    objservice.idLocal = Convert.ToInt16(result.idLocal);
                    objservice.nameLocal = result.local;
                    objservice.name = result.nameService;
                    objservice.typeservice = result.typeService;
                    objservice.price = Convert.ToDouble(result.price);
                    objservice.idCar = Convert.ToInt16(result.idCar);
                    objservice.nameCar = result.Auto;

                    objlstservice.Add(objservice);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlstservice;
        }

        public bool insertservice(servicesf objserv)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Services objservice = new Services();

                objservice.idLocal = objserv.idLocal;
                objservice.nameService = objserv.name;
                objservice.typeService = objserv.typeservice;
                objservice.price = Convert.ToDecimal(objserv.price);
                objservice.idCar = Convert.ToInt16(objserv.idCar);
                

                model.Services.Add(objservice);
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

        public bool updateservice(servicesf objservice)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                Services objserv = (from objs in model.Services
                                    where objs.idService == objservice.id
                                select objs).FirstOrDefault();

                objserv.idLocal = objservice.idLocal;
                objserv.nameService = objservice.name;
                objserv.typeService = objservice.typeservice;
                objserv.price = Convert.ToDecimal(objservice.price);
                objservice.idCar = Convert.ToInt16(objserv.idCar);

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

        public bool deleteservice(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Services objserv = (from objs in model.Services
                                    where objs.idService == id
                                    select objs).FirstOrDefault();

                model.Services.Remove(objserv);
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

        public servicesf getserviceById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            servicesf objservice = new servicesf();

            try
            {
                Services objserv = (from objs in model.Services
                                    where objs.idService == id
                                    select objs).FirstOrDefault();

                objservice.id = Convert.ToInt16(objserv.idService);
                objservice.idLocal = Convert.ToInt16(objserv.idLocal);                
                objservice.name = objserv.nameService;
                objservice.typeservice= objserv.typeService;
                objservice.price = Convert.ToDouble(objserv.price);
                objservice.idCar = Convert.ToInt16(objserv.idCar);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objservice;
        }
        public servicesf getFilterService(string _service, string _type, int _idcar)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            servicesf objservice = new servicesf();

            try
            {
                Services objserv = (from objs in model.Services
                                    where objs.nameService == _service && objs.typeService == _type && objs.idCar == _idcar && objs.idLocal == 1
                                    select objs).FirstOrDefault();

                objservice.id = Convert.ToInt16(objserv.idService);
                objservice.idLocal = Convert.ToInt16(objserv.idLocal);
                objservice.name = objserv.nameService;
                objservice.typeservice = objserv.typeService;
                objservice.price = Convert.ToDouble(objserv.price);
                objservice.idCar = Convert.ToInt16(objserv.idCar);
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objservice;
        }
    }
}

