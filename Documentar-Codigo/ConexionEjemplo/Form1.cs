using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Instancia del repositorio que maneja las operaciones de los clientes.
        CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            // Constructor del formulario que inicializa los componentes.
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en el botón de cargar.
            // Obtiene todos los clientes del repositorio y los asigna como fuente de datos del DataGridView.
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Manejador del evento de cambio de texto en textBox1.
            // Obtiene todos los clientes y los asigna como fuente de datos del DataGridView.
            var custo = customerRepository.ObtenerTodos();
            dataGrid.DataSource = custo;

            // Filtra la lista de clientes cuyo nombre de la empresa comienza con el texto introducido en tbFiltro.
            var filtro = custo.FindAll(X => X.CompanyName.StartsWith(tbFiltro.Text));
            // Actualiza la fuente de datos del DataGridView con los clientes filtrados.
            dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Manejador del evento de carga del formulario.
            // Comentado: se refiere a la configuración de la base de datos, pero está desactivado en este código.
            /*
            DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            DatosLayer.DataBase.ConnectionTimeout = 30;

            string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            var conxion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en el botón de búsqueda.
            // Obtiene un cliente por su ID del repositorio y llena los controles de texto con la información del cliente.
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en label4. Actualmente vacío.
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en el botón de insertar.
            var resultado = 0;

            // Crea una nueva instancia de cliente basada en los datos introducidos en los controles de texto.
            var nuevoCliente = ObtenerNuevoCliente();

            // Valida que no haya campos vacíos en el nuevo cliente.
            if (!validarCampoNull(nuevoCliente))
            {
                // Inserta el nuevo cliente en la base de datos y muestra el número de filas modificadas.
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                // Muestra un mensaje de error si hay campos vacíos.
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Valida si alguno de los campos del objeto es una cadena vacía.
        // Retorna true si encuentra algún campo vacío, false si todos los campos están completos.
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if ((string)value == "")
                {
                    return true;
                }
            }
            return false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en label5. Actualmente vacío.
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en el botón de modificar.
            // Obtiene el cliente actualizado basado en los datos en los controles de texto.
            var actualizarCliente = ObtenerNuevoCliente();
            // Actualiza el cliente en la base de datos y muestra el número de filas actualizadas.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        private Customers ObtenerNuevoCliente()
        {
            // Crea y retorna una nueva instancia de un cliente usando los datos introducidos en los controles de texto.
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Manejador del evento de clic en el botón de eliminar.
            // Elimina el cliente basado en el ID introducido en tboxCustomerID y muestra el número de filas eliminadas.
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + eliminadas);
        }
    }
}
