using System;
using System.Data;

namespace Cartillas.Back
{
    public class CartillaModel
    {
        public string Especialidad { get; set; }
        public string Medico { get; set; }
    }

    public class TurnoModel
    {
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public string Fecha { get; set; }
    }

    public class Turno
    {
        public DataTable DT { get; set; } = new DataTable();

        public Turno()
        {
            DT.TableName = "Turnos";
            DT.Columns.Add("Especialidad", typeof(String));
            DT.Columns.Add("Medico", typeof(String));
            DT.Columns.Add("Fecha"); 

            //Metodo leer el arquivo si existe y carga los datos dt=la misma estructura
            Leer_DT();
        }

        public bool CargarTurnos(TurnoModel turno) 
        {
            bool res = false;
            DT.Rows.Add();
            int i = DT.Rows.Count - 1;

            DT.Rows[i]["Especialidad"] = turno.Especialidad;
            DT.Rows[i]["Medico"] = turno.Medico;
            DT.Rows[i]["Fecha"] = turno.Fecha;

            DT.WriteXml("Turnos.xml");
            return res;
        }

        //metodo buscar
        public bool BorrarTurnos(string especialidad)
        {
            bool res = false;
            int fila = BuscarFilaTurnos(especialidad);

            if (fila != -1)
            {
                DT.Rows[fila].Delete();
                DT.WriteXml("Turnos.xml");
                res = true;
            }
            return res;
        }

        public int BuscarFilaTurnos(string especialidad)
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
        public TurnoModel BuscarTurnos(string especialidad)
        {
            TurnoModel turno = new TurnoModel();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (DT.Rows[i]["especialidad"].ToString() == especialidad)
                {
                    turno.Especialidad = DT.Rows[i]["especialidad"].ToString();
                    turno.Medico = DT.Rows[i]["medico"].ToString();
                    turno.Medico = DT.Rows[i]["fecha"].ToString();
                    break;
                }
            }

            return turno;
        }

        //metodoDT
        private void Leer_DT()
        //lee un archivo
        {
            //io=entradasalida
            if (System.IO.File.Exists("Turnos.xml")) ///me devuelve un booleano
            {
                DT.ReadXml("Turnos.xml");
            }
        }
    }
}
