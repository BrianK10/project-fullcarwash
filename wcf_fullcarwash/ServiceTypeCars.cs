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
    public class ServiceTypeCars : IServiceTypeCars
    {
        bool value;      

        public List<typecars> gettypecars()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<typecars> objlsttypecar = new List<typecars>();

            try
            {
                var query = model.SP_SELECT_TYPECARS();
                foreach (var result in query)
                {
                    typecars objtypecar = new typecars();

                    objtypecar.id = Convert.ToInt16(result.idCar);
                    objtypecar.typecar = result.typeCar;
                    objtypecar.price = Convert.ToDouble(result.price);
                    objtypecar.carregistration = result.carRegistration;

                    objlsttypecar.Add(objtypecar);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlsttypecar;
        }

        public bool inserttypecar(typecars objtype)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                TypeCars objtypecar = new TypeCars();

                objtypecar.typeCar = objtype.typecar;
                objtypecar.price = Convert.ToDecimal(objtype.price);
                objtypecar.carRegistration = objtype.carregistration;
                

                model.TypeCars.Add(objtypecar);
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

        public bool updatetypecar(typecars objtype)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                TypeCars objtyp = (from objt in model.TypeCars
                                   where objt.idCar == objtype.id
                                    select objt).FirstOrDefault();

                objtyp.idCar = objtype.id;
                objtyp.typeCar = objtype.typecar;
                objtyp.price = Convert.ToDecimal(objtype.price);
                objtyp.carRegistration = objtype.carregistration;

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

        public bool deletetypecar(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                TypeCars objtyp = (from objt in model.TypeCars
                                   where objt.idCar == id
                                   select objt).FirstOrDefault();

                model.TypeCars.Remove(objtyp);
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

        public typecars gettypecarById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            typecars objtype = new typecars();

            try
            {
                TypeCars objtyp = (from objt in model.TypeCars
                                   where objt.idCar == id
                                   select objt).FirstOrDefault();

                objtype.id = objtyp.idCar;
                objtype.typecar= objtyp.typeCar;
                objtype.price = Convert.ToDouble(objtyp.price);
                objtype.carregistration = objtyp.carRegistration;
                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objtype;
        }
    }
}

