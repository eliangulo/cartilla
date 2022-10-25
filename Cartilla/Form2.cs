using Cartillas.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cartilla
{
    public partial class Form2 : Form
    {
        private Cartilla1 cartilla;

        //metodo para cuando llame al formulario desde form1(cartilla)
        public Form2(Cartilla1 cartilla)
        {
            InitializeComponent();
            this.cartilla = cartilla;//argumento
            textBox1.Text = cartilla.Especialidad;
        }
    }
}
