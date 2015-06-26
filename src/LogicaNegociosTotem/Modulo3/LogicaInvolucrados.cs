﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTotem;
using DatosTotem.Modulo3;


namespace LogicaNegociosTotem.Modulo3
{
    /// <summary>
    /// Clase que maneja la lógica de los involucrados en un proyecto
    /// </summary>
    public class LogicaInvolucrados
    {
        #region Atributos
        private DominioTotem.ListaInvolucradoContacto contactosInvolucrados;
        private DominioTotem.ListaInvolucradoUsuario usuariosInvolucrados;
        #endregion

        #region Getters y Setters
        public DominioTotem.ListaInvolucradoUsuario UsuariosInvolucrados
        {
            get { return usuariosInvolucrados; }
            set { usuariosInvolucrados = value; }
        }
        public DominioTotem.ListaInvolucradoContacto ContactosInvolucrados
        {
            get { return contactosInvolucrados; }
            set { contactosInvolucrados = value; }
        }

        #endregion
        /// <summary>
        /// Constructor de la logica de los involucrados, setea listas de usuarios y contactos
        /// </summary>
        /// <param name="elProyecto">proyecto al que estan asociadas las listas de involucrados que carga</param>
        #region Constructor
        public LogicaInvolucrados(DominioTotem.Proyecto elProyecto)
        {
            contactosInvolucrados = obtenerContactosInvolucradosProyecto(elProyecto);
            usuariosInvolucrados = obtenerUsuariosInvolucradosProyecto(elProyecto);
        }
        public LogicaInvolucrados()
        {

        }

        #endregion
        /// <summary>
        /// Metodo que agrega contacto a lista de contactos involucrados a un proyecto
        /// </summary>
        /// <param name="elContacto">contacto a agregar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        public bool agregarContactoALista(DominioTotem.Contacto elContacto)
        {
            return contactosInvolucrados.agregarContactoAProyecto(elContacto);
        }
        /// <summary>
        /// Metodo que agrega contacto a lista de usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="elUsuario">usuario a agregar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        public bool agregarUsuarioALista(DominioTotem.Usuario elUsuario)
        {
            return usuariosInvolucrados.agregarUsuarioAProyecto(elUsuario);
        }
        /// <summary>
        /// Metodo que elimina un contacto involucrado a un proyecto (lista y bd)
        /// </summary>
        /// <param name="elContacto">contacto a eliminar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        /// 
        public bool eliminarContacto(DominioTotem.Contacto elContacto)
        {
            throw new NotImplementedException();
            //return contactosInvolucrados.eliminarContactoDeProyecto(elContacto);
        }
        /// <summary>
        /// Metodo que elimina un usuario invlocurado a un proyecto (lista y bd)
        /// </summary>
        /// <param name="elUsuario">usuario a eliminar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        public bool eliminarUsuario(DominioTotem.Usuario elUsuario)
        {
            throw new NotImplementedException();
            //return usuariosInvolucrados.eliminarUsuarioDeProyecto(elUsuario);
        }
        /// <summary>
        /// Metodo que agrega una lista de contactos involucrados a la base de datos
        /// </summary>
        /// <param name="laListaCont">lista de contactos a ingresar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        public bool agregarContactosEnBD(DominioTotem.ListaInvolucradoContacto laListaCont)
        {
            bool retorno = false;
            try
            {
                retorno = BDInvolucrados.agregarContactosInvolucrados(laListaCont);

            }
            catch (ExcepcionesTotem.Modulo3.ListaSinInvolucradosException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                    RecursosBDModulo3.Mensaje_ListaSinInv, ex);
            }
            catch (ExcepcionesTotem.Modulo3.ContactoSinIDException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ContactoSinIDException(
                            RecursosBDModulo3.Codigo_ContactoSinID, RecursosBDModulo3.Mensaje_ContactoSinID,
                            ex);
            }
            catch (ExcepcionesTotem.Modulo3.ListaSinProyectoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
             RecursosBDModulo3.Mensaje_ListaSinProy, ex);

            }
            catch (ExcepcionesTotem.Modulo3.InvolucradoRepetidoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                    RecursosBDModulo3.Codigo_Involucrado_Repetido,
                    RecursosBDModulo3.Mensaje_Involucrado_Repetido, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);

            }
            catch (ExcepcionesTotem.ExceptionTotem ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", ex);
            }
            return retorno;
        }
        /// <summary>
        /// Metodo que agrega una lista de usuarios involucrados a la base de datos
        /// </summary>
        /// <param name="laListaUsu">lista de usuarios a ingresar</param>
        /// <returns>Valor booleano que refleja exito o fallo de la operacion</returns>
        public bool agregarUsuariosEnBD(DominioTotem.ListaInvolucradoUsuario laListaUsu)
        {
            bool retorno = false;
            try
            {
                retorno = BDInvolucrados.agregarUsuariosInvolucrados(laListaUsu);

            }
            catch (ExcepcionesTotem.Modulo3.ProyectoSinCodigoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                ex);

            }
            catch (ExcepcionesTotem.Modulo3.ListaSinProyectoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ListaSinProyectoException(RecursosBDModulo3.Codigo_ListaSinProy,
                    RecursosBDModulo3.Mensaje_ListaSinProy, ex);
            }
            catch (ExcepcionesTotem.Modulo3.ListaSinInvolucradosException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ListaSinInvolucradosException(RecursosBDModulo3.Codigo_ListaSinInv,
                RecursosBDModulo3.Mensaje_ListaSinInv, ex);
            }
            catch (ExcepcionesTotem.Modulo3.InvolucradoRepetidoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.InvolucradoRepetidoException(
                        RecursosBDModulo3.Codigo_Involucrado_Repetido,
                        RecursosBDModulo3.Mensaje_Involucrado_Repetido, ex);
            }
            catch (ExcepcionesTotem.Modulo3.UsuarioSinUsernameException ex)
            {
                throw new ExcepcionesTotem.Modulo3.UsuarioSinUsernameException(RecursosBDModulo3.Codigo_UsuarioSinUsername,
                RecursosBDModulo3.Mensaje_UsuarioSinUsername, ex);

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotem ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", ex);
            }
            return retorno;
        }
        /// <summary>
        /// Metodo que carga la lista de los contactos involucrados a un proyecto
        /// </summary>
        /// <param name="elProyecto">proyecto del que se desean saber los contactos involucrados</param>
        /// <returns>lista de contactos involucrados</returns>
        public DominioTotem.ListaInvolucradoContacto obtenerContactosInvolucradosProyecto(
            DominioTotem.Proyecto elProyecto)
        {

            try
            {
                return BDInvolucrados.consultarContactosInvolucradosPorProyecto(elProyecto);

            }
            catch (ExcepcionesTotem.Modulo3.ProyectoSinCodigoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                        RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                        ex);

            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotem ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem("No se pudo completar la operacion", ex);
            }
        }
        /// <summary>
        /// Metodo que carga la lista de los usuarios involucrados a un proyecto
        /// </summary>
        /// <param name="elProyecto">lista de usuarios involucrados</param>
        /// <returns>lista de usuarios involucrados</returns>
        public DominioTotem.ListaInvolucradoUsuario obtenerUsuariosInvolucradosProyecto(
            DominioTotem.Proyecto elProyecto)
        {
            try
            {
             return BDInvolucrados.consultarUsuariosInvolucradosPorProyecto(elProyecto);

            }
            catch (ExcepcionesTotem.Modulo3.ProyectoSinCodigoException ex)
            {
                throw new ExcepcionesTotem.Modulo3.ProyectoSinCodigoException(
                        RecursosBDModulo3.Codigo_ProyectoSinCod, RecursosBDModulo3.Mensaje_ProyectoSinCod,
                        ex);
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExcepcionesTotem.ExceptionTotem ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Metodo que carga la lista de cargos de los contactos
        /// </summary>
        /// <param name="elProyecto">l</param>
        /// <returns>lista de los cargos de los contactos involucrados</returns>
        public List<String> ListarCargosEmpleados(DominioTotem.ClienteJuridico cli)
        {
            List<String> listaCargos = new List<String>();

            return DatosTotem.Modulo3.BDInvolucrados.consultarCargosContactos(cli);
        }

        /// <summary>
        /// Metodo que obtine los datos del usuario 
        /// </summary>
        /// <param name="elProyecto">username</param>
        /// <returns>usuario</returns>
        public DominioTotem.Usuario obtenerDatosUsuarioUsername(String username)
        {
            return BDInvolucrados.datosUsuarioUsername(username);
        }

        /// <summary>
        /// Metodo que carga los contactos por cargo
        /// </summary>
        /// <param name="elProyecto">cliente juridico y cargo</param>
        /// <returns>lista de contactos</returns>
        public List<DominioTotem.Contacto> ListarContactoCargoEmpresa(DominioTotem.ClienteJuridico jur, String cargo)
        {
            try
            {
                return DatosTotem.Modulo3.BDInvolucrados.listarContactosPorCargoEmpresa(jur, cargo);
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }
        }
        /// <summary>
        /// Metodo que carga los datos de un contacto
        /// </summary>
        /// <param name="elProyecto">id del contacto</param>
        /// <returns>datos del contacto</returns>
        public DominioTotem.Contacto obtenerDatosContactoID(int id)
        {
            try
            {
                return BDInvolucrados.datosContactoID(id);
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem();
            }
        }
        /// <summary>
        /// Metodo que carga los datos de un contacto
        /// </summary>
        /// <param name="elProyecto">usuario y lista de usuarios involucrados</param>
        /// <returns>datos del usuario</returns>
        public bool eliminarUsuarioDeBD(DominioTotem.Usuario u, DominioTotem.ListaInvolucradoUsuario lista)
        {
            try
            {
                return BDInvolucrados.eliminarUsuariosDeIvolucradosEnProyecto(u, lista);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo que elimina un cotacto involucrado 
        /// </summary>
        /// <param name="elProyecto">el contacto y la lista de contactos involucrados</param>
        /// <returns>datos del contacto</returns>
        public bool eliminarContactoDeBD(DominioTotem.Contacto c, DominioTotem.ListaInvolucradoContacto lista)
        {
            try
            {
                return BDInvolucrados.eliminarContactoDeIvolucradosEnProyecto(c, lista);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
