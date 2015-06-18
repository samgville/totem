﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using ExcepcionesTotem.Modulo6.ExcepcionesComando;
using ExcepcionesTotem.Modulo6.ExcepcionesDAO;
using ExcepcionesTotem; 
using DAO.DAO.Modulo6;
 
  

namespace Comandos.Comandos.Modulo6
{
   public class ComandoAgregarActor : Comando<Entidad,bool>
    {
       /// <summary>
       /// Comando que se ejecuta para agregar un actor de caso de uso
       /// a Base de Datos, recibe el actor como parámetro y retorna
       /// true si lo insertó y false en caso contrario.
       /// </summary>
       /// <param name="parametro">Entidad de tipo Actor a insertar</param>
       /// <returns>True si la inserción fue éxitosa, false en caso
       /// contrario</returns>
       public override bool Ejecutar(Entidad parametro)
       {
           try
           {
               DAO.Fabrica.FabricaAbstractaDAO fabricaDaoSqlServer = DAO.Fabrica.FabricaAbstractaDAO.ObtenerFabricaSqlServer();

               DAO.DAO.Modulo6.DAOActor daoActor = (DAO.DAO.Modulo6.DAOActor)fabricaDaoSqlServer.ObtenerDAOActor();
               bool resultado = daoActor.Agregar(parametro);
               return resultado;
           }

           catch (AgregarActorBDDAOException ex)
           {

              AgregarActorComandoBDException exComandoAgregarActor = new AgregarActorComandoBDException(
                   RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorBD,
                   RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorBD,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                  exComandoAgregarActor);

              throw exComandoAgregarActor; 

           }


           catch (AgregarActorNuloDAOException ex) 
           {
               AgregarActorComandoNullException exComandoAgregarActor = new AgregarActorComandoNullException(
                   RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorNulo,
                   RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorNulo,
                   ex);

               Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                 exComandoAgregarActor);

               throw exComandoAgregarActor; 

           }

           catch (AgregarActorDAOException ex)
           {
              AgregarActorComandoException exComandoAgregarActor =  new AgregarActorComandoException(
                   RecursosComandosModulo6.CodigoExcepcionComandoAgregarActorError,
                   RecursosComandosModulo6.MensajeExcepcionComandoAgregarActorError,
                   ex);

              Logger.EscribirError(RecursosComandosModulo6.ClaseComandoAgregarActor,
                 exComandoAgregarActor);

              throw exComandoAgregarActor; 

           }
       }
    }
}