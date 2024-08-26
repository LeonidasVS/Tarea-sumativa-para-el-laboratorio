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
    public partial class Form1 : Form
    {
        // Constructor de la clase Form1.
        public Form1()
        {
            InitializeComponent();
        }

        // Manejador de eventos para el botón de guardar en el BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos en los controles del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza cualquier edición en el BindingSource.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza todos los cambios en la base de datos.
        }

        // Este método parece ser una duplicación del anterior.
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos en los controles del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza cualquier edición en el BindingSource.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza todos los cambios en la base de datos.
        }

        // Este método parece ser una duplicación del anterior.
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();  // Valida los datos en los controles del formulario.
            this.customersBindingSource.EndEdit();  // Finaliza cualquier edición en el BindingSource.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);  // Actualiza todos los cambios en la base de datos.
        }

        // Manejador de eventos para cuando el formulario se carga.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla 'Customers' del DataSet 'northwindDataSet'.
            // Este código puede ser movido o eliminado según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Manejador de eventos para el clic en celdas del DataGridView.
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este método está vacío; puedes agregar funcionalidad aquí si es necesario.
        }
    }

}
