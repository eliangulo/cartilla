using Cartillas.Back;
using System;
using System.Data;
using System.Windows.Forms;

namespace Cartilla
{
    public partial class Form2 : Form
    {
        private CartillaModel cartilla;
        private Cartillas.Back.Turno turnos = new Cartillas.Back.Turno();

        //metodo para cuando llame al formulario desde form1(cartilla)
        public Form2(CartillaModel cartilla)
        {
            InitializeComponent();
            dgTurno.DataSource = turnos.DT;
            this.cartilla = cartilla; //argumento
            textBox1.Text = this.cartilla.Especialidad;
            //LimpiarPantalla();

            /*DataTable dt = turnos.DT.AsEnumerable()
                .Where(row => row.Field<String>("Especialidad") == cartilla.Especialidad &&
                              row.Field<String>("Medico") == cartilla.Medico)
                .CopyToDataTable();*/

            DataView dv = new DataView(turnos.DT);
            dv.RowFilter = "Especialidad = '" + cartilla.Especialidad + "'";
            dgTurno.DataSource = dv;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            TurnoModel turno = new TurnoModel();
            turno.Especialidad = cartilla.Especialidad;
            turno.Medico = cartilla.Medico;
            turno.Fecha = txtDia.Text + " " + cbHora.Text;

            turnos.CargarTurnos(turno);
            LimpiarPantalla();
        }

        private void LimpiarPantalla()
        {
            txtDia.Text = "";
            cbHora.Text = "";

            txtDia.Focus();
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDia.Text = e.Start.ToShortDateString();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            bool res = turnos.BorrarTurnos(textBox1.Text);
            if (res)
            {
                LimpiarPantalla();
            }
            else
            {
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }
    }
}
