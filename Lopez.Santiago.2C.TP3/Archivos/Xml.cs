using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>//public
    {
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser;
                XmlTextWriter writer;
                bool aux = false;
                using (writer = new XmlTextWriter(archivo, System.Text.Encoding.UTF8))
                {
                    ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                    aux = true;
                }
                return aux;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
                //return false;

            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlTextReader reader;
                XmlSerializer ser;
                bool aux = false;
                using (reader = new XmlTextReader(archivo))
                {
                    ser = new XmlSerializer(typeof(Xml<T>));
                    datos = (T)ser.Deserialize(reader);
                    aux = true;
                }
                return aux;
            }
            catch (Exception e)
            {
                
                //datos = null;
                datos = default(T);
                throw new ArchivosException(e);
                //return false;

            }
        }
    }
}
