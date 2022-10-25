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
            Cartilla1 cartilla = new Cartilla1();
            cartilla.Especialidad = txtEspecialidad.Text;
            cartilla.Medico = txtMedico.Text;

            cartillas.CargarCartilla(cartilla);
            LimpiarPantalla();
        }
        private void LimpiarPantalla()
        {
            txtEspecialidad.Text = "";
            txtMedico.Text = "";

            txtEspecialidad.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cartilla1 cartilla = new Cartilla1();
            cartillas.BuscarCartilla(txtEspecialidad.Text);
             
            if(cartilla.Especialidad != null)
            {
                txtEspecialidad.Text=cartilla.Especialidad; 
                txtMedico.Text=cartilla.Medico;
            }

            txtEspecialidad.Focus();
            txtEspecialidad.SelectAll();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            bool res = cartillas.BorrarCartilla(txtEspecialidad.Text);
            if (res)
            {
                LimpiarPantalla();
            }
            else
            {
                txtEspecialidad.Focus();
                txtEspecialidad.SelectAll();
            }
          
        }

       // private void label8_Click(object sender, EventArgs e)
       // {

        //}



        private void dgCartilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                }

                sb.Append("Total: " + selectedRowCount.ToString());
                MessageBox.Show(sb.ToString(), "Selected Rows");
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

                    Cartilla1 cartilla = new Cartilla1();
                    //cartilla.Especialidad = dgCartilla.SelectedRows[i].Index["Especialidad"].ToString();
                    //cartilla.Medico = dgCartilla.SelectedRows[i].Index.Cells["Medico"].ToString();
                    cartilla.Especialidad = dgCartilla.SelectedRows[i].Cells[0].Value.ToString();
                    cartilla.Medico = dgCartilla.SelectedRows[i].Cells[1].Value.ToString();

                    //creo el objeto nuevo y paso un objeto 
                    Form2 turno = new Form2(cartilla);
                    turno.ShowDialog();
                }
            }
        }
    }
}
