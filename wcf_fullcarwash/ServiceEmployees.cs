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
    public class ServiceEmployees : IServiceEmployees
    {
        bool value;

        public List<employees> getemployees()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<employees> objlsttypecar = new List<employees>();

            try
            {
                var query = model.SP_SELECT_EMPLOYEES();
                foreach (var result in query)
                {
                    employees objemployee = new employees();

                    objemployee.id = result.idEmployee;
                    objemployee.firstname = result.firstName;
                    objemployee.lastname = result.lastName;
                    objemployee.fullname = result.fullName;
                    objemployee.gender = result.gender;
                    objemployee.email = result.email;
                    objemployee.numberdni = result.number_dni;
                    objemployee.password = result.password;

                    objlsttypecar.Add(objemployee);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlsttypecar;
        }

        public bool insertemployee(employees objemp)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Employees objemployee = new Employees();

                objemployee.firstName = objemp.firstname;
                objemployee.lastName = objemp.lastname;
                objemployee.fullName = objemp.fullname;
                objemployee.gender = objemp.gender;
                objemployee.email = objemp.email;
                objemployee.number_dni = objemp.numberdni;
                objemployee.password = objemp.password;

                model.Employees.Add(objemployee);
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

        public bool updateemployee(employees objem)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                Employees objemp = (from objt in model.Employees
                                    where objt.idEmployee == objem.id
                                    select objt).FirstOrDefault();

                objemp.idEmployee = objem.id;
                objemp.firstName = objem.firstname;
                objemp.lastName = objem.lastname;
                objemp.fullName = objem.fullname;
                objemp.gender = objem.gender;
                objemp.email = objem.email;
                objemp.number_dni = objem.numberdni;
                objemp.password = objem.password;

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

        public bool deleteemployee(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Employees objemp = (from obje in model.Employees
                                    where obje.idEmployee == id
                                    select obje).FirstOrDefault();

                model.Employees.Remove(objemp);
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

        public employees getemployeeById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            employees objemployee = new employees();

            try
            {
                Employees objemp = (from obje in model.Employees
                                    where obje.idEmployee == id
                                    select obje).FirstOrDefault();

                objemployee.id = objemp.idEmployee;
                objemployee.firstname = objemp.firstName;
                objemployee.lastname = objemp.lastName;
                objemployee.fullname = objemp.fullName;
                objemployee.gender = objemp.gender;
                objemployee.email = objemp.email;
                objemployee.numberdni = objemp.number_dni;
                objemployee.password = objemp.password;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objemployee;
        }

        public employees getemployeeLogin(string email, string password)
        {
            
            fullcarwashEntities model = new fullcarwashEntities();
            employees objemployee = new employees();

            try
            {
                Employees objemp = (from obje in model.Employees
                                    where obje.email.ToLower().Equals(email.ToLower()) && obje.password.Equals(password)
                                    select obje).FirstOrDefault();

                objemployee.id = objemp.idEmployee;
                objemployee.firstname = objemp.firstName;
                objemployee.lastname = objemp.lastName;
                objemployee.fullname = objemp.fullName;
                objemployee.gender = objemp.gender;
                objemployee.email = objemp.email;
                objemployee.numberdni = objemp.number_dni;
                objemployee.password = objemp.password;

             
            }
            catch (Exception ex)
            {                
                ex.Message.ToString();
            }
            return objemployee;
        }
    }
}

