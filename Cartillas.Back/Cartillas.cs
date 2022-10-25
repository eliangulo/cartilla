using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;




namespace Cartillas.Back
{
    public class Cartillas
    {
        public DataTable DT { get; set; } = new DataTable();
        //ctor construir la tala de datos
        public Cartillas()
        {
            DT.TableName = "Cartillas";
            DT.Columns.Add("Especialidad", typeof(String));
            DT.Columns.Add("Medico", typeof(String));

            Leer_DT();
        }

        public bool CargarCartilla(CartillaModel cartilla) {
            bool res = false;
            DT.Rows.Add();
            int i = DT.Rows.Count - 1;

            DT.Rows[i]["Especialidad"] = cartilla.Especialidad;
            DT.Rows[i]["Medico"] = cartilla.Medico;

            DT.WriteXml("Cartillas.xml");
            return res;
        }

        //metodo buscar
        public bool BorrarCartilla(string especialidad)
        {
            bool res = false;
            int fila = BuscarFilaCartilla(especialidad);  
            
            if (fila != -1)
            { 
                DT.Rows[fila].Delete();
                DT.WriteXml("Cartillas.xml");
                res = true; 
            }
            return res;
        }

        public int BuscarFilaCartilla(string especialidad)
        {
            int fila = -1;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["especialidad"].ToString() == especialidad)
                {
                    fila = i;
                    break;
                }
            }

            return fila;
        }

        //metodo buscar
        public CartillaModel BuscarCartilla(string especialidad)
        {
            CartillaModel cartilla = new CartillaModel();   
           for(int i= 0; i < DT.Rows.Count; i++)
           {
                if (DT.Rows[i]["especialidad"].ToString() == especialidad)
                {
                    cartilla.Especialidad = DT.Rows[i]["especialidad"].ToString();
                    cartilla.Medico = DT.Rows[i]["medico"].ToString();
                    break;
                }
           }
                
            return cartilla;    
        }

        //metodoDT
        private void Leer_DT()
            //lee un archivo
        {
            //io=entradasalida
           if (System.IO.File.Exists("Cartillas.xml")) ///me devuelve un booleano
           {
                DT.ReadXml("Cartillas.xml");
           }
        }
    }
}
