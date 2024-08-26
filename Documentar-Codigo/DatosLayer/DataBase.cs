using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {

        // Clase que maneja la configuración de la conexión a la base de datos.
        public static class DataBase
        {
            // Propiedad estática que devuelve la cadena de conexión para la base de datos.
            public static string ConnectionString
            {
                get
                {
                    // Obtiene la cadena de conexión de la configuración (app.config o web.config) usando el nombre "NWConnection".
                    string CadenaConexion = ConfigurationManager
                        .ConnectionStrings["NWConnection"]
                        .ConnectionString;

                    // Crea un SqlConnectionStringBuilder a partir de la cadena de conexión obtenida.
                    SqlConnectionStringBuilder conexionBuilder =
                        new SqlConnectionStringBuilder(CadenaConexion);

                    // Establece el nombre de la aplicación en la cadena de conexión, si se ha definido uno.
                    // Si ApplicationName es null, se conserva el nombre de la aplicación original en la cadena de conexión.
                    conexionBuilder.ApplicationName =
                        ApplicationName ?? conexionBuilder.ApplicationName;

                    // Establece el tiempo de espera de conexión en segundos, si ConnectionTimeout es mayor que 0.
                    // Si ConnectionTimeout es 0 o menor, se conserva el valor original en la cadena de conexión.
                    conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                        ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                    // Devuelve la cadena de conexión actualizada como una cadena de texto.
                    return conexionBuilder.ToString();
                }
            }

            // Propiedad estática que define el tiempo de espera de conexión en segundos.
            // Se puede establecer externamente y se aplica a la cadena de conexión.
            public static int ConnectionTimeout { get; set; }

            // Propiedad estática que define el nombre de la aplicación que se usará en la cadena de conexión.
            // Se puede establecer externamente y se aplica a la cadena de conexión.
            public static string ApplicationName { get; set; }

            // Método estático que devuelve una nueva instancia de SqlConnection.
            // La conexión se abre automáticamente al crear la instancia.
            public static SqlConnection GetSqlConnection()
            {
                // Crea una nueva instancia de SqlConnection usando la cadena de conexión actual.
                SqlConnection conexion = new SqlConnection(ConnectionString);

                // Abre la conexión a la base de datos.
                conexion.Open();

                // Devuelve la conexión abierta.
                return conexion;
            }
        }

    }
}
