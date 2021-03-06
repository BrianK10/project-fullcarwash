﻿using System;
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

