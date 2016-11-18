using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string lugar;//"historial.dat"

        public Texto(string archivo)
        {
            this.lugar = archivo;
        }

        public bool guardar(string datos)
        {
            bool aux = false;
            StreamWriter sw;
            //using (sw = new StreamWriter((datos), true))
            using (sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+ this.lugar,true))
            {
                sw.WriteLine(datos);
                aux = true;
            }
            return aux; ;
        }

        public bool leer(out List<string> datos)
        {
            
            bool aux = false;
            datos = new List<string>();
            StreamReader sr;
            using (sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+ this.lugar))
            {
                bool band = true;
                while (band == true)
                {
                    if (sr.EndOfStream)//si esta en el final de la lista cambia sale
                        band = false;
                    else
                        datos.Add(sr.ReadLine());

                }  
                aux = true;
            }
            return aux;
        }
    }
}
