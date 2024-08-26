using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Este método se llama cuando el usuario hace clic en el botón de guardar del BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida los controles en el formulario.
            this.Validate();

            // Finaliza la edición en el BindingSource.
            this.customersBindingSource.EndEdit();

            // Actualiza todos los cambios en la base de datos a través del TableAdapterManager.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Este método se llama cuando se carga el formulario.
        private void Form2_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla 'Customers' del DataSet 'northwindDataSet'.
            // Este código puede ser movido o eliminado si no se requiere cargar los datos en el momento de la carga del formulario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Este método se llama cuando se hace clic en el control 'cajaTextoID'.
        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            // Actualmente vacío; podrías agregar funcionalidad aquí si es necesario.
        }

        // Este método se llama cuando se presiona una tecla mientras 'cajaTextoID' tiene el foco.
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es 'Enter' (código ASCII 13).
            if (e.KeyChar == (char)13)
            {
                // Busca el índice del cliente basado en el ID introducido en 'cajaTextoID'.
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text);

                // Si se encuentra el índice (es decir, el cliente existe), posiciona el BindingSource en esa posición.
                if (index > -1)
                {
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    // Si no se encuentra el cliente, muestra un mensaje de error.
                    MessageBox.Show("Elemento no encontrado");
                }
            }
        }
    }

}
