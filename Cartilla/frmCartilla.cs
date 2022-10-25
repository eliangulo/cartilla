using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cartillas.Back; //relacionado con back end para que me tome cartilla


namespace Cartilla
{
    public partial class Medicine : Form
    {
        private Cartillas.Back.Cartillas cartillas = new Cartillas.Back.Cartillas();
      

        public Medicine()
        {
            InitializeComponent();
            dgCartilla.DataSource = cartillas.DT;
            LimpiarPantalla();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CartillaModel cartilla = new CartillaModel();
            cartilla.Especialidad = cbEspecialidades.SelectedItem.ToString();
            cartilla.Medico = txtMedico.Text;

            cartillas.CargarCartilla(cartilla);
            LimpiarPantalla();
        }
        private void LimpiarPantalla()
        {
           // txtEspecialidad.Text = "";
            txtMedico.Text = "";

            //txtEspecialidad.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CartillaModel cartilla = new CartillaModel();
            cartillas.BuscarCartilla(cbEspecialidades.SelectedItem.ToString());
             
            if(cartilla.Especialidad != null)
            {
                cbEspecialidades.Text=cartilla.Especialidad; 
                txtMedico.Text=cartilla.Medico;
            }

           // txtEspecialidad.Focus();
           // txtEspecialidad.SelectAll();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            bool res = cartillas.BorrarCartilla(cbEspecialidades.SelectedItem.ToString());
            if (res)
            {
                LimpiarPantalla();
            }
            else
            {
               // txtEspecialidad.Focus();
                //txtEspecialidad.SelectAll();
            }
          
        }

        private void btnVerTurno_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
            dgCartilla.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                for (int i = 0; i < selectedRowCount; i++)
                {
                    sb.Append("Row: ");
                    sb.Append(dgCartilla.SelectedRows[i].Index.ToString());
                    sb.Append(Environment.NewLine);

                    CartillaModel cartilla = new CartillaModel();
                    cartilla.Especialidad = dgCartilla.SelectedRows[i].Cells[0].Value.ToString(); // Especialidad
                    cartilla.Medico = dgCartilla.SelectedRows[i].Cells[1].Value.ToString(); // Medico

                    //creo el objeto nuevo y paso un objeto 
                    Form2 turno = new Form2(cartilla);
                    turno.ShowDialog();
                }
            }
        }

    }
}
