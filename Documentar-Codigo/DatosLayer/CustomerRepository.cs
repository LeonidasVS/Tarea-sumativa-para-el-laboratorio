using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {

        public List<Customers> ObtenerTodos()
        {
            // Abre una conexión a la base de datos utilizando el método estático GetSqlConnection de la clase DataBase.
            using (var conexion = DataBase.GetSqlConnection())
            {

                // Construye la consulta SQL que selecciona todas las columnas de la tabla Customers.
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Crea un objeto SqlCommand con la consulta SQL y la conexión a la base de datos.
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    // Ejecuta el comando y obtiene un SqlDataReader para leer los datos de la base de datos.
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crea una lista para almacenar los objetos Customers que se leerán del SqlDataReader.
                    List<Customers> Customers = new List<Customers>();

                    // Lee cada fila de resultados del SqlDataReader.
                    while (reader.Read())
                    {
                        // Convierte la fila leída en un objeto Customers utilizando el método LeerDelDataReader.
                        var customers = LeerDelDataReader(reader);
                        // Añade el objeto Customers a la lista.
                        Customers.Add(customers);
                    }
                    // Retorna la lista completa de clientes leídos de la base de datos.
                    return Customers;
                }
            }
        }

        public Customers ObtenerPorID(string id)
        {
            // Abre una conexión a la base de datos utilizando el método estático GetSqlConnection de la clase DataBase.
            using (var conexion = DataBase.GetSqlConnection())
            {

                // Construye la consulta SQL para seleccionar un cliente específico por su ID.
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + "  FROM [dbo].[Customers] " + "\n";
                selectForID = selectForID + $"  WHERE CustomerID = @customerId"; // Utiliza un parámetro para evitar inyección SQL.

                // Crea un objeto SqlCommand con la consulta SQL y la conexión a la base de datos.
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    // Añade el parámetro @customerId al comando, con el valor del ID proporcionado.
                    comando.Parameters.AddWithValue("customerId", id);

                    // Ejecuta el comando y obtiene un SqlDataReader para leer los datos de la base de datos.
                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    // Lee el primer registro del SqlDataReader, si existe.
                    if (reader.Read())
                    {
                        // Convierte la fila leída en un objeto Customers utilizando el método LeerDelDataReader.
                        customers = LeerDelDataReader(reader);
                    }

                    // Retorna el objeto Customers encontrado, o null si no se encontró ningún registro.
                    return customers;
                }
            }
        }

        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            // Crea una nueva instancia de la clase Customers.
            Customers customers = new Customers();

            // Asigna el valor del campo CustomerID al atributo CustomerID del objeto Customers.
            // Si el valor es DBNull (es decir, el campo es nulo en la base de datos), asigna una cadena vacía.
            // De lo contrario, convierte el valor a una cadena.
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];

            // Asigna el valor del campo CompanyName al atributo CompanyName del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];

            // Asigna el valor del campo ContactName al atributo ContactName del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];

            // Asigna el valor del campo ContactTitle al atributo ContactTitle del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];

            // Asigna el valor del campo Address al atributo Address del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];

            // Asigna el valor del campo City al atributo City del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];

            // Asigna el valor del campo Region al atributo Region del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];

            // Asigna el valor del campo PostalCode al atributo PostalCode del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];

            // Asigna el valor del campo Country al atributo Country del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];

            // Asigna el valor del campo Phone al atributo Phone del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];

            // Asigna el valor del campo Fax al atributo Fax del objeto Customers.
            // Si el valor es DBNull, asigna una cadena vacía. De lo contrario, convierte el valor a una cadena.
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            // Retorna el objeto Customers completamente poblado con los datos leídos del SqlDataReader.
            return customers;
        }

        //-------------
        public int InsertarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos utilizando la configuración proporcionada en DataBase.GetSqlConnection().
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para insertar un nuevo cliente en la tabla [dbo].[Customers].
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Crea un comando SQL utilizando la consulta de inserción y la conexión.
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    // Llama al método que agrega los parámetros del cliente al comando y ejecuta la consulta.
                    int insertados = parametrosCliente(customer, comando);
                    // Retorna el número de filas afectadas por la consulta de inserción.
                    return insertados;
                }
            }
        }

        //-------------
        public int ActualizarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos utilizando la configuración proporcionada en DataBase.GetSqlConnection().
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para actualizar un cliente existente en la tabla [dbo].[Customers].
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID = @CustomerID";

                // Crea un comando SQL utilizando la consulta de actualización y la conexión.
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    // Llama al método que agrega los parámetros del cliente al comando y ejecuta la consulta.
                    int actualizados = parametrosCliente(customer, comando);
                    // Retorna el número de filas actualizadas por la consulta de actualización.
                    return actualizados;
                }
            }
        }


        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            // Agrega los parámetros al comando SQL. Cada parámetro representa un campo en la tabla Customers.
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactTitle); // Se corrigió: ContactTitle debe ser asignado, no ContactName.
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);

            // Ejecuta la consulta SQL y retorna el número de filas afectadas (insertadas o actualizadas).
            var insertados = comando.ExecuteNonQuery();
            return insertados;
        }


        public int EliminarCliente(string id)
        {
            // Abre una conexión a la base de datos utilizando la configuración proporcionada en DataBase.GetSqlConnection().
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para eliminar un cliente de la tabla [dbo].[Customers].
                String EliminarCliente = "";
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n";
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID";

                // Crea un comando SQL utilizando la consulta de eliminación y la conexión.
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    // Añade el parámetro para el CustomerID que se eliminará.
                    comando.Parameters.AddWithValue("@CustomerID", id);
                    // Ejecuta la consulta y retorna el número de filas eliminadas.
                    int eliminados = comando.ExecuteNonQuery();
                    return eliminados;
                }
            }
        }
    }
}
