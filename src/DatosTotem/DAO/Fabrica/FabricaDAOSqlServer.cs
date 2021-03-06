﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.Fabrica
{
    public class FabricaDAOSqlServer 
    {
        #region Modulo 1
        public IntefazDAO.Modulo1.IDaoLogin ObtenerDaoLogin()
        {
            return new DAO.Modulo1.DaoLogin();
        }
        #endregion

        #region Modulo 2
        public IntefazDAO.Modulo2.IDaoClienteJuridico ObtenerDaoClienteJuridico()
        {
            return new DAO.Modulo2.DaoClienteJuridico();
        }
        public IntefazDAO.Modulo2.IDaoClienteNatural ObtenerDaoClienteNatural()
        {
            return new DAO.Modulo2.DaoClienteNatural();
        }
        public IntefazDAO.Modulo2.IDaoContacto ObtenerDaoContacto()
        {
            return new DAO.Modulo2.DaoContacto();
        }

        #endregion

        #region Modulo 3
        public IntefazDAO.Modulo3.IDaoInvolucrados ObtenerDaoInvolucrados()
        {
            return new DAO.Modulo3.DAOInvolucrados();
        }
        #endregion

        #region Modulo 4
        public IntefazDAO.Modulo4.IDaoProyecto ObtenerDAOProyecto()
        {
            return new DAO.Modulo4.DAOProyecto();
        }
        #endregion

        #region Modulo 5
        public IntefazDAO.Modulo5.IDaoRequerimiento ObtenerDAORequerimiento()
        {
            return new DAO.Modulo5.DAORequerimiento();
        }
        #endregion

        #region Modulo 6
        public IntefazDAO.Modulo6.IDaoActor ObtenerDAOActor() 
        {
            return new DAO.Modulo6.DAOActor(); 
        }

        public IntefazDAO.Modulo6.IDaoCasoDeUso ObtenerDAOCasoDeUso()
        {
            return new DAO.Modulo6.DAOCasoDeUso(); 
        }

        #endregion

        #region Modulo 7
        /// <summary>
        /// Metodo sobreescrito de la Fabrica Abstracta para crear el objeto concreto DAOUsuario
        /// </summary>
        /// <returns>El objeto concreto DAOUsuario</returns>
        public IntefazDAO.Modulo7.IDaoUsuario ObtenerDAOUsuario()
        {
            return new DAO.Modulo7.DAOUsuario();
        }
        #endregion

        #region Modulo 8
        /// <summary>
        /// Metodo para crear un DaoAcuerdo
        /// </summary>
        /// <returns>La instancia del DaoAcuerdo </returns>
        public IntefazDAO.Modulo8.IDaoAcuerdo ObtenerDAOAcuerdo()
        {
            return new DAO.Modulo8.DaoAcuerdo();
        }
        /// <summary>
        /// Metodo para crear un DaoMinuta
        /// </summary>
        /// <returns>La instancia del DaoMinuta </returns>
        public IntefazDAO.Modulo8.IDaoMinuta ObtenerDAOMinuta()
        {
            return new DAO.Modulo8.DaoMinuta();
        }
        /// <summary>
        /// Metodo para crear un DaoPunto
        /// </summary>
        /// <returns>La instancia del DaoPunto </returns>
        public IntefazDAO.Modulo8.IDaoPunto ObtenerDAOPunto()
        {
            return new DAO.Modulo8.DaoPunto();
        }
        /// <summary>
        /// Metodo para crear un DaoInvolucradosMinuta
        /// </summary>
        /// <returns>La instancia del DaoInvolucradosMinuta </returns>
        public IntefazDAO.Modulo8.IDaoInvolucradosMinuta ObtenerDAOInvolucradosMinuta()
        {
            return new DAO.Modulo8.DaoInvolucradosMinuta();
        }
        #endregion

    }
}
