﻿using Datos.Fabrica;
using Datos.IntefazDAO.Modulo3;
using Dominio.Entidades.Modulo3;
using ExcepcionesTotem.Modulo3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comandos.Comandos.Modulo3
{
    class ComandoAgregarUsuariosInvolucrados : Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando para agregar un usuario como involucrados
        /// </summary>
        /// <param name="parametro">Usuario aagregar</param>
        /// <returns>true si se puedo agergar correctamente</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool exito = false;
            try
            {
                Datos.IntefazDAO.Modulo3.IDaoInvolucrados daoInvolucrado;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDAO = new Datos.Fabrica.FabricaDAOSqlServer();
                daoInvolucrado = fabricaDAO.ObtenerDaoInvolucrados();
                exito = daoInvolucrado.AgregarUsuariosInvolucrados(parametro);
            }
            catch (ListaSinInvolucradosException)
            {
                exito = true;
            }
            catch (ListaSinProyectoException)
            {
                exito = false;
            }
            return exito;
        }
    }

}