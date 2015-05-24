﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DominioTotem;
using LogicaNegociosTotem.Modulo6;

namespace PruebasUnitariasTotem.Modulo6
{
    /// <summary>
    /// Prueba unitaria que trabaja sobre la clase PruebaLogicaActor
    /// </summary>
    [TestFixture]
    public class PruebaLogicaActor
    {
        //Atributo para probar clase LogicaActor
        LogicaActor logica;

        /// <summary>
        /// Inicialicializa la clase que probaremos
        /// </summary>
        [SetUp]
        public void Init()
        {
            logica = new LogicaActor();
        }

        /// <summary>
        /// Se prueba que la clase pueda agregar actores
        /// </summary>
        [Test]
        public void PruebaAgregar()
        {
            Assert.IsTrue(logica.AgregarActor("prueba", "prueba", 0));
        }

        /// <summary>
        /// Se prueba que la clase pueda modificar actores
        /// </summary>
        [Test]
        public void PruebaLeer()
        {
            List<Actor> listaActores = logica.ListarActor(0);

            /*Probamos que la lista devuelta no es nula y a su vez
            que nos devuelva un actor de predeterminado de prueba*/
            Assert.IsNotNull(listaActores);
            Assert.AreEqual(listaActores[listaActores.Count - 1].NombreActor, "prueba");
            Assert.AreEqual(listaActores[listaActores.Count - 1].DescripcionActor, "prueba");
        }

        /// <summary>
        /// Se prueba que la clase pueda modificar actores
        /// </summary>
        [Test]
        public void PruebaModificar()
        {
            Assert.IsTrue(logica.ModificarActor(-1, "prueba", "prueba", 0));
        }

        /// <summary>
        /// Se prueba que la clase pueda eliminiar actores
        /// </summary>
        [Test]
        public void PruebaEliminar()
        {
            Assert.IsTrue(logica.EliminarActor("prueba", "prueba", 0));
        }

        /// <summary>
        /// Se prueba que la clase pueda agregar un actor siempre y cuando ya no exista en ese proyecto
        /// </summary>
        [Test]
        public void PruebaAgregarListar()
        {
            ///Creo unos valores aleatorios para simular un actor
            Random aleatorio = new Random();
            String valorPrueba = aleatorio.Next().ToString();

            //Si ese usuario ya existe en la Base de Datos me debe retornar falso
            Assert.IsTrue(!logica.AgregarListarActor("prueba", "prueba", 0));

            //Si no existe debe retornarme verdadero indicando que la insercion fue exitosa
            Assert.IsTrue(logica.AgregarListarActor(valorPrueba, valorPrueba, 0));
        }

        /// <summary>
        /// Se deja en vacio el atributo creado para ser limpiada por el Garbage Collector
        /// </summary>
        [TearDown]
        public void Limpiar()
        {
            logica = null;
        }
    }
}

