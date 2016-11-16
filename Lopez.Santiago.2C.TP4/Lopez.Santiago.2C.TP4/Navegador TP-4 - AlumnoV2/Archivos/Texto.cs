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
        string aux;//"historial.dat"

        public Texto(string archivo)
        {
            this.aux = archivo;
        }

        public bool guardar(string datos)
        {
            bool aux = false;
            StreamWriter sw;
            //using (sw = new StreamWriter((datos), true))
            using (sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ this.aux ,true,Encoding.UTF8))
            {
                sw.Write(datos);
                aux = true;
            }
            return aux; ;
        }

        public bool leer(out List<string> datos)
        {
            
            bool aux = false;
            datos = new List<string>();
            StreamReader sr;
            using (sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ this.aux))
            {

                //datos.Add = sr.ReadToEnd();
                datos.Add(sr.ReadToEnd());

                aux = true;

            }
            return aux;
        }
    }
}
