using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Definición de la clase Customers que representa la entidad "Customer" en la base de datos.
    public class Customers
    {
        // Identificador único del cliente. Normalmente es una cadena alfanumérica.
        public string CustomerID { get; set; }

        // Nombre de la empresa o compañía del cliente.
        public string CompanyName { get; set; }

        // Nombre de contacto del cliente dentro de la empresa.
        public string ContactName { get; set; }

        // Título o puesto del contacto dentro de la empresa (e.g., Gerente de Ventas).
        public string ContactTitle { get; set; }

        // Dirección física de la empresa o cliente.
        public string Address { get; set; }

        // Ciudad en la que se encuentra la empresa o cliente.
        public string City { get; set; }

        // Región o estado donde se encuentra la empresa o cliente.
        public string Region { get; set; }

        // Código postal para la dirección de la empresa o cliente.
        public string PostalCode { get; set; }

        // País en el que se encuentra la empresa o cliente.
        public string Country { get; set; }

        // Número de teléfono principal de la empresa o cliente.
        public string Phone { get; set; }

        // Número de fax de la empresa o cliente, si aplica.
        public string Fax { get; set; }
    }

}
