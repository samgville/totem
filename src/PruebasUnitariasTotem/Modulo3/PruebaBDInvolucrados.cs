﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace PruebasUnitariasTotem.Modulo3
{

    /// <summary>
    /// Grupo de pruebas unitarias para la clase BDInvolucrados
    /// </summary>
    [TestFixture]
    public class PruebaBDInvolucrados
    {/*
        private ListaInvolucradoContacto laLista;
        private Proyecto elProyecto;
        private Contacto elContacto;

        #region SetUp y TearDown
        [SetUp]
        public void init()
        {
            elProyecto = new Proyecto("FB", "Totem", true, "asd", "$", 1234);
            laLista = new ListaInvolucradoContacto(elProyecto);
            elContacto = new Contacto();
            elContacto.Con_Id = 1;
            laLista.agregarContactoAProyecto(elContacto);
            elContacto = new Contacto();
            elContacto.Con_Id = 2;
            laLista.agregarContactoAProyecto(elContacto);
        }
        [TearDown]
        public void clean()
        {
            laLista = null;
            elProyecto = null;
            elContacto = null;
        }
        #endregion
        [Test]
        public void pruebaAgregarContactosInvolucrados()
        {
            Assert.IsTrue(BDInvolucrados.agregarContactosInvolucrados(laLista));
        }
        [Test]
        public void pruebaConsultarContactosInvolucrados()
        {
            int cont = 1;
            ListaInvolucradoContacto lC = BDInvolucrados.consultarContactosInvolucradosPorProyecto(elProyecto);
            foreach (Contacto elC in lC.Lista)
            {
                Assert.AreEqual(cont, elC.Con_Id);
                System.Console.WriteLine(elC.Con_Id + elC.Con_Nombre + elC.Con_Apellido + elC.ConCargo);
                cont++;
            }
        }
        [Test]
        public void pruebaEliminarEliminarContactoInvolucrado()
        {
            int numFilasAnt, numFilasDesp;
            elContacto = new Contacto();
            elContacto.Con_Id = 3;
            ListaInvolucradoContacto laLista2 = new ListaInvolucradoContacto(elProyecto);
            laLista2.agregarContactoAProyecto(elContacto);
            BDInvolucrados.agregarContactosInvolucrados(laLista2);
            numFilasAnt = BDInvolucrados.consultarContactosInvolucradosPorProyecto(elProyecto).Lista.ToArray().Length;

            BDInvolucrados.eliminarContactoDeIvolucradosEnProyecto(elContacto, laLista2);

            numFilasDesp = BDInvolucrados.consultarContactosInvolucradosPorProyecto(
                elProyecto).Lista.ToArray().Length;
            //Assert.IsTrue(BDInvolucrados.eliminarContactoDeIvolucradosEnProyecto(elContacto, laLista));
            Assert.AreEqual(numFilasAnt - 1, numFilasDesp);
        }*/
    }
}
