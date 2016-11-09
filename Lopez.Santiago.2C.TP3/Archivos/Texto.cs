using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto:IArchivo<string>//publica
    {
        public bool guardar(string archivo, string datos)
        {
            try
            {
                bool aux = false;
                StreamWriter sw;
                using (sw = new StreamWriter(archivo, true))
                {
                    sw.Write(datos);
                    aux = true;
                    //sw.Close();
                }
                return aux;
            }
            catch (Exception e)
            {
                //datos = null;
                
                throw new ArchivosException(e);
                //return false;
            }
        }

        public bool leer(string archivo, out string datos)
        {
            try
            {
                bool aux = false;
                StreamReader sr;
                using (sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                    aux = true;
                }
                return aux;
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
                //return false;
            }
        }
    }
}
