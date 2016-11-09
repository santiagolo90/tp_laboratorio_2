using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;

namespace TestUnitaria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AlumnoTest()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, EntidadesInstanciables.Alumno.EEstadoCuenta.MesPrueba);

            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Nacionalidad);

            


        }

        [TestMethod]
        public void InstructorTest()
        {
            Instructor i1 = new Instructor(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(i1.Nombre);
            Assert.IsNotNull(i1.Nombre);
            Assert.IsNotNull(i1.DNI);
            Assert.IsNotNull(i1.Nacionalidad);

        }
    }
}
