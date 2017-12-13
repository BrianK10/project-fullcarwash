using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WCFServicesTest
{
    [TestClass]
    public class UnitTestEmployees
    {
        [TestMethod]
        public void Test1GetEmployees()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            List<EmployeesWS.employees> employeesObt = new List<EmployeesWS.employees>(proxy.getemployees());
            //se ingresa el numero de empleados que hay en la db
            Assert.AreEqual(1, employeesObt.Count);
        }

        [TestMethod]
        public void Test2InsertEmployee()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            EmployeesWS.employees employeeCre = new EmployeesWS.employees();
            employeeCre.firstname = "Jose";
            employeeCre.lastname = "Rosas";
            employeeCre.fullname = "Jose Rosas";
            employeeCre.gender = true;
            employeeCre.email = "jose@email.com";
            employeeCre.numberdni = "68473372";
            employeeCre.password = "password";
            proxy.insertemployee(employeeCre).Equals(true);

            Assert.AreEqual("Jose", employeeCre.firstname);
            Assert.AreEqual("Rosas", employeeCre.lastname);
            Assert.AreEqual("Jose Rosas", employeeCre.fullname);
            Assert.AreEqual(true, employeeCre.gender);
            Assert.AreEqual("jose@email.com", employeeCre.email);
            Assert.AreEqual("68473372", employeeCre.numberdni);
            Assert.AreEqual("password", employeeCre.password);
        }

        [TestMethod]
        public void Test3UpdateEmployee()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            EmployeesWS.employees employeeUpd = new EmployeesWS.employees();
            //se ingresa el id del empleado de prueba
            employeeUpd.id = 1;
            employeeUpd.firstname = "Jose";
            employeeUpd.lastname = "Modificado";
            employeeUpd.fullname = "Jose Modificado";
            employeeUpd.gender = true;
            employeeUpd.email = "jose@email.com";
            employeeUpd.numberdni = "68473372";
            employeeUpd.password = "password";
            proxy.updateemployee(employeeUpd).Equals(true);

            Assert.AreEqual("Jose", employeeUpd.firstname);
            Assert.AreEqual("Modificado", employeeUpd.lastname);
            Assert.AreEqual("Jose Modificado", employeeUpd.fullname);
            Assert.AreEqual(true, employeeUpd.gender);
            Assert.AreEqual("jose@email.com", employeeUpd.email);
            Assert.AreEqual("68473372", employeeUpd.numberdni);
            Assert.AreEqual("password", employeeUpd.password);
        }

        [TestMethod]
        public void Test4GetEmployeeById()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            //se ingresa el id del empleado de prueba
            EmployeesWS.employees employeeObt = proxy.getemployeeById(1);

            Assert.AreEqual("Jose", employeeObt.firstname);
            Assert.AreEqual("Modificado", employeeObt.lastname);
            Assert.AreEqual("Jose Modificado", employeeObt.fullname);
            Assert.AreEqual(true, employeeObt.gender);
            Assert.AreEqual("jose@email.com", employeeObt.email);
            Assert.AreEqual("68473372", employeeObt.numberdni);
            Assert.AreEqual("password", employeeObt.password);
        }

        [TestMethod]
        public void Test5GetEmployeeLogin()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            //se ingresa email y contraseña del empleado de prueba
            EmployeesWS.employees employeeLog = proxy.getemployeeLogin("jose@email.com", "password");

            Assert.AreEqual("jose@email.com", employeeLog.email);
            Assert.AreEqual("password", employeeLog.password);
        }


        [TestMethod]
        public void Test6DeleteEmployee()
        {
            EmployeesWS.ServiceEmployeesClient proxy = new EmployeesWS.ServiceEmployeesClient();
            //se ingresa el id del empleado de prueba
            EmployeesWS.employees employeeDel = proxy.getemployeeById(1);
            proxy.deleteemployee(1).Equals(true);

            Assert.IsNull(employeeDel);
        }
    }
}
