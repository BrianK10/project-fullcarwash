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
    public class ServiceLocal : IServiceLocal
    {
        bool value;
        public List<locals> getlocals()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<locals> objlstlocal = new List<locals>();

            try
            {
                var query = model.SP_SELECT_LOCALS();
                foreach (var result in query)
                {
                    locals objlocal = new locals();

                    objlocal.id = result.idLocal;
                    objlocal.name = result.name;
                    objlocal.address = result.address;
                    objlocal.schedules = result.schedules;

                    objlstlocal.Add(objlocal);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlstlocal;
        }

        public Boolean insertlocal(locals objloc)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Local objlocal = new Local();
                                
                objlocal.name = objloc.name;
                objlocal.address = objloc.address;
                objlocal.schedules = objloc.schedules;

                model.Local.Add(objlocal);
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

        public Boolean updatelocal(locals objlocal)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                Local objloc = (from objl in model.Local
                                where objl.idLocal == objlocal.id
                                select objl).FirstOrDefault();

                objloc.name = objlocal.name;
                objloc.address = objlocal.address;
                objloc.schedules = objlocal.schedules;
                

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

        public Boolean deletelocal(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Local objloc = (from objl in model.Local
                                     where objl.idLocal == id
                                     select objl).FirstOrDefault();

                model.Local.Remove(objloc);
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

        public locals getlocalById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            locals objlocal = new locals();

            try
            {
                Local objloc = (from objl in model.Local
                                         where objl.idLocal == id
                                         select objl).FirstOrDefault();

                objlocal.id = objloc.idLocal;
                objlocal.name = objloc.name;
                objlocal.address = objloc.address;
                objlocal.schedules = objloc.schedules;                
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objlocal;
        }
    }
}
