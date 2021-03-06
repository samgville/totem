﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace Comandos.Comandos.Modulo5
{
    public class ComandoModificarRequerimiento: Comando<Dominio.Entidad, Boolean>
    {
        /// <summary>
        /// Comando que modifica la informacion de un requerimiento
        /// </summary>
        /// <param name="parametro">Requerimiento a editar</param>
        /// <returns>true si se logro editar</returns>
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            try
            {
                Datos.IntefazDAO.Modulo5.IDaoRequerimiento daoRequerimiento;
                Datos.Fabrica.FabricaDAOSqlServer fabricaDao = new Datos.Fabrica.FabricaDAOSqlServer();
                daoRequerimiento = fabricaDao.ObtenerDAORequerimiento();
                bool resultado = daoRequerimiento.Modificar(parametro);
                return resultado;
            }
            #region Capturar Excepciones
            catch (ExcepcionesTotem.Modulo1.ParametroInvalidoException ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoInvalidoException ex)
            {

                throw ex;
            }
            catch (ExcepcionesTotem.Modulo5.RequerimientoNoModificadoException ex)
            {

                throw ex;
            }
            #endregion

        }
    }
}
