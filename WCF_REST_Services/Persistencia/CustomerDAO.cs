using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_REST_Services.Dominio;

namespace WCF_REST_Services.Persistencia
{
    public class CustomerDAO
    {
        private string CadenaConexion = "Data Source=.;Initial Catalog=fullcarwash;Integrated Security=SSPI;";

        public Customer Crear(Customer customerACrear)
        {
            Customer customerCreado = null;
            string sql = "INSERT INTO Customers VALUES (@idempl, @firsname, @lastname, @fullname, @gender, @birth," +
                "@phone, @email, @dni, @address, @pass)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idempl", customerACrear.idcustomer));
                    comando.Parameters.Add(new SqlParameter("@firsname", customerACrear.firstname));
                    comando.Parameters.Add(new SqlParameter("@lastname", customerACrear.lastname));
                    comando.Parameters.Add(new SqlParameter("@fullname", customerACrear.firstname + " " +
                        customerACrear.lastname));
                    comando.Parameters.Add(new SqlParameter("@gender", customerACrear.gender));
                    comando.Parameters.Add(new SqlParameter("@birth", customerACrear.birthdate));
                    comando.Parameters.Add(new SqlParameter("@phone", customerACrear.phone));
                    comando.Parameters.Add(new SqlParameter("@email", customerACrear.email));
                    comando.Parameters.Add(new SqlParameter("@dni", customerACrear.numberdni));
                    comando.Parameters.Add(new SqlParameter("@address", customerACrear.address));
                    comando.Parameters.Add(new SqlParameter("@pass", customerACrear.password));
                    
                    comando.ExecuteNonQuery();
                }
            }
            customerCreado = Obtener(customerACrear.idcustomer);
            return customerCreado;
        }

        public Customer Obtener(int idCustomer)
        {
            Customer customerEncontrado = null;
            string sql = "SELECT * FROM Customers WHERE idCustomer=@id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", idCustomer));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            customerEncontrado = new Customer()
                            {
                                idcustomer = (int)resultado["idCustomer"],
                                firstname = (string)resultado["firstName"],
                                lastname = (string)resultado["lastName"],
                                fullname = (string)resultado["fullName"],
                                gender = (bool)resultado["gender"],
                                birthdate = (DateTime)resultado["birthdate"],
                                phone = (string)resultado["phone"],
                                email = (string)resultado["email"],
                                numberdni = (string)resultado["number_dni"],
                                address = (string)resultado["address"],
                                password = (string)resultado["password"]
                            };
                        }
                    }
                }
            }
            return customerEncontrado;
        }

        public Customer Modificar(Customer customerAModificar)
        {
            Customer customerModificado = null;
            string sql = "UPDATE Customers SET firstName=@firsname, lastName=@lastname, fullName=@fullname, gender=@gender, " +
                "birthdate=@birth, phone=@phone, email=@email, number_dni=@dni, address=@address, password=@pass WHERE idCustomer=@id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", customerModificado.idcustomer));
                    comando.Parameters.Add(new SqlParameter("@firsname", customerModificado.firstname));
                    comando.Parameters.Add(new SqlParameter("@lastname", customerModificado.lastname));
                    comando.Parameters.Add(new SqlParameter("@fullname", customerModificado.firstname + " " +
                        customerModificado.lastname));
                    comando.Parameters.Add(new SqlParameter("@gender", customerModificado.gender));
                    comando.Parameters.Add(new SqlParameter("@birth", customerModificado.birthdate));
                    comando.Parameters.Add(new SqlParameter("@phone", customerModificado.phone));
                    comando.Parameters.Add(new SqlParameter("@email", customerModificado.email));
                    comando.Parameters.Add(new SqlParameter("@dni", customerModificado.numberdni));
                    comando.Parameters.Add(new SqlParameter("@address", customerModificado.address));
                    comando.Parameters.Add(new SqlParameter("@pass", customerModificado.password));
                    comando.ExecuteNonQuery();
                }
            }
            customerModificado = Obtener(customerAModificar.idcustomer);
            return customerModificado;
        }

        public void Eliminar(int idCustomer)
        {
            string sql = "DELETE FROM Customers WHERE idCustomer=@id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", idCustomer));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Customer> Listar()
        {
            List<Customer> customersEncontrados = new List<Customer>();
            Customer customerEncontrado = null;
            string sql = "SELECT * FROM Customers";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            customerEncontrado = new Customer()
                            {
                                idcustomer = (int)resultado["idCustomer"],
                                firstname = (string)resultado["firstName"],
                                lastname = (string)resultado["lastName"],
                                fullname = (string)resultado["fullName"],
                                gender = (bool)resultado["gender"],
                                birthdate = (DateTime)resultado["birthdate"],
                                phone = (string)resultado["phone"],
                                email = (string)resultado["email"],
                                numberdni = (string)resultado["number_dni"],
                                address = (string)resultado["address"],
                                password = (string)resultado["password"]
                            };
                            customersEncontrados.Add(customerEncontrado);
                        }
                    }
                }
            }
            return customersEncontrados;
        }
    }
}