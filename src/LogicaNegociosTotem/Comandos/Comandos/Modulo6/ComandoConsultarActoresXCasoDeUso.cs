﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem;
using Datos.DAO.Modulo6;

namespace Comandos.Comandos.Modulo6
{
   public class ComandoConsultarActoresXCasoDeUso:Comando<int,List<string>>
    {
        /// <summary>
        /// Comando que se ejecuta para cargar el combo de listado de actores
        /// </summary>
        /// <param name="parametro">Código de Proyecto</param>
        /// <returns>Lista de Actores dado el código de proyecto</returns>
       public override List<string> Ejecutar(int parametro)
        {
            try
            {
                Datos.Fabrica.FabricaDAOSqlServer fabricaDaoSqlServer = new Datos.Fabrica.FabricaDAOSqlServer(); 

                DAOActor daoActor = (DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
                List<string> resultado = daoActor.ConsultarActoresXCasoDeUso(parametro);
                return resultado;
            }

            catch (BDDAOException ex)
            {

                ComandoBDException exComandoAgregarActor = new ComandoBDException(
                     RecursosComandosModulo6.CodigoExcepcionComandoBD,
                     RecursosComandosModulo6.MensajeExcepcionComandoBD,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActoresXCasoDeUso,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
            catch (TipoDeDatoErroneoDAOException ex)
            {
                TipoDeDatoErroneoComandoException exComandoAgregarActor = new TipoDeDatoErroneoComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoTipoDeDatoErroneo,
                     RecursosComandosModulo6.MensajeTipoDeDatoErroneoComandoExcepcion,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActoresXCasoDeUso,
                    exComandoAgregarActor);

                throw exComandoAgregarActor;
            }

            catch (ObjetoNuloDAOException ex)
            {
                ComandoNullException exComandoAgregarActor = new ComandoNullException(
                    RecursosComandosModulo6.CodigoExcepcionComandoObjetoNulo,
                    RecursosComandosModulo6.MensajeExcepcionComandoObjetoNulo,
                    ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActoresXCasoDeUso,
                  exComandoAgregarActor);

                throw exComandoAgregarActor;

            }

            catch (ErrorDesconocidoDAOException ex)
            {
                ComandoException exComandoAgregarActor = new ComandoException(
                     RecursosComandosModulo6.CodigoExcepcionComandoError,
                     RecursosComandosModulo6.MensajeExcepcionComandoError,
                     ex);

                Logger.EscribirError(RecursosComandosModulo6.ClaseComandoConsultarActoresXCasoDeUso,
                   exComandoAgregarActor);

                throw exComandoAgregarActor;

            }
        }
    }
}
