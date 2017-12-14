using System;
using System.Collections.Generic;

using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_fullcarwash
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class ServiceCustomers : IServiceCustomers
    {
        Boolean value;
        public List<customer> getcustomers()
        {
            fullcarwashEntities model = new fullcarwashEntities();
            List<customer> objlstcustomer = new List<customer>();

            try
            {
                var query = model.SP_SELECT_CUSTOMERS();
                foreach (var result in query)
                {
                    customer objcustomer = new customer();

                    objcustomer.id = result.idCustomer;
                    objcustomer.firstname= result.firstName;
                    objcustomer.lastname = result.lastName;
                    objcustomer.fullname = result.fullName;
                    objcustomer.gender = result.gender;
                    objcustomer.birthdate = result.birthdate;
                    objcustomer.phone = result.phone;
                    objcustomer.email = result.email;
                    objcustomer.numberdni = result.number_dni;
                    objcustomer.address = result.address;
                    objcustomer.password = result.password;

                    objlstcustomer.Add(objcustomer);
                }
            }
            catch (EntityException exception)
            {
                throw new Exception(exception.Message);

            }
            return objlstcustomer;
        }

        public Boolean insertcustomer(customer objcustomer)
        {
            fullcarwashEntities model = new fullcarwashEntities();            
            
            try
            {
                Customers objcust = new Customers();

                objcust.firstName = objcustomer.firstname;
                objcust.lastName = objcustomer.lastname;
                objcust.fullName = objcust.firstName + " " + objcust.lastName;
                objcust.gender = objcustomer.gender;
                objcust.birthdate = objcustomer.birthdate;
                objcust.phone = objcustomer.phone;
                objcust.email = objcustomer.email;
                objcust.number_dni = objcustomer.numberdni;
                objcust.address = objcustomer.address;
                objcust.password = objcustomer.password;


                model.Customers.Add(objcust);
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

        public Boolean updatecustomer(customer objcustomer)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            try
            {
                Customers objcust = (from objc in model.Customers
                                     where objc.idCustomer == objcustomer.id
                                     select objc).FirstOrDefault();

                objcust.firstName = objcustomer.firstname;
                objcust.lastName = objcustomer.lastname;
                objcust.fullName = objcustomer.firstname + " " + objcustomer.lastname;
                objcust.gender = objcustomer.gender;
                objcust.birthdate = objcustomer.birthdate;
                objcust.phone = objcustomer.phone;
                objcust.email = objcustomer.email;
                objcust.number_dni = objcustomer.numberdni;
                objcust.address = objcustomer.address;
                objcust.password = objcustomer.password;
                
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

        public Boolean deletecustomer(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();

            try
            {
                Customers objcust = (from objc in model.Customers
                                     where objc.idCustomer == id
                                     select objc).FirstOrDefault();

                model.Customers.Remove(objcust);
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


        public customer getcustomerById(int id)
        {
            fullcarwashEntities model = new fullcarwashEntities();
            customer objcust = new customer();

            try
            {
                Customers objcustomer = (from objc in model.Customers
                                         where objc.idCustomer == id
                                         select objc).FirstOrDefault();

                objcust.id = objcustomer.idCustomer;
                objcust.firstname = objcustomer.firstName;
                objcust.lastname = objcustomer.lastName;
                objcust.fullname = objcustomer.fullName;
                objcust.gender = objcustomer.gender;
                objcust.birthdate = objcustomer.birthdate;
                objcust.phone = objcustomer.phone;
                objcust.email = objcustomer.email;
                objcust.numberdni = objcustomer.number_dni;
                objcust.address = objcustomer.address;
                objcust.password = objcustomer.password;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw ex;
            }
            return objcust;
        }
        public customer getcustomerLogin(string email, string password)
        {
            
            fullcarwashEntities model = new fullcarwashEntities();
            customer objcust = new customer();

            try
            {
                Customers objcustomer = (from objc in model.Customers
                                         where objc.email.ToLower().Equals(email.ToLower()) && objc.password .Equals(password)                                         
                                         select objc).FirstOrDefault();

                objcust.id = objcustomer.idCustomer;
                objcust.firstname = objcustomer.firstName;
                objcust.lastname = objcustomer.lastName;
                objcust.fullname = objcustomer.fullName;
                objcust.gender = objcustomer.gender;
                objcust.birthdate = objcustomer.birthdate;
                objcust.phone = objcustomer.phone;
                objcust.email = objcustomer.email;
                objcust.numberdni = objcustomer.number_dni;
                objcust.address = objcustomer.address;
                objcust.password = objcustomer.password;
                
                
            }
            catch (Exception ex)
            {                
                ex.Message.ToString();
            }
            return objcust;
        }
    }
}
