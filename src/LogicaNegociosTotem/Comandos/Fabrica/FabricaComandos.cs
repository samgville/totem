﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using Comandos.Comandos.Modulo6;
using Comandos.Comandos.Modulo2;
using Comandos.Comandos.Modulo7;

namespace Comandos.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        public static Comando<Entidad, bool> CrearComandoAgregarClienteJuridico()
        {
            return new ComandoAgregarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoAgregarClienteNatural()
        {
            return new ComandoAgregarClienteNatural();
        }
        public static Comando<String, List<String>> CrearComandoConsultarCiudadPorEstado()
        {
            return new ComandoConsultarCiudadPorEstado();
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarClienteJurXID()
        {
            return new ComandoConsultarClienteJurXID(); 
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarDatosContactoID()
        {
            return new ComandoConsultarDatosContactoID();
        }
        public static Comando<String, List<String>> CrearComandoConsultarEstadosPorPais()
        {
            return new ComandoConsultarEstadosPorPais();
        }
        public static Comando<Entidad,List<Entidad>> CrearComandoConsultarListaContactos()
        {
            return new ComandoConsultarListaContactos();
        }
        public static Comando<Boolean,List<String>> CrearComandoConsultarListaPaises()
        {
            return new ComandoConsultarListaPaises();
        } 
        public static Comando<bool, List<Entidad>> CrearComandoConsultarTodosClienteJuridico()
        {
            return new ComandoConsultarTodosClienteJuridico();
        }
        public static Comando<bool, List<Entidad>> CrearComandoConsultarTodosClienteNatural()
        {
            return new ComandoConsultarTodosClienteNatural();
        }
        public static Comando<Entidad, Entidad> CrearComandoConsultarXIDClienteNatural()
        {
            return new ComandoConsultarXIDClienteNatural();
        }

        public static Comando<Entidad, bool> CrearComandoEliminarClienteJuridico()
        {
            return new ComandoEliminarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoEliminarClienteNatural()
        {
            return new ComandoEliminarClienteNatural();
        }
        public static Comando<Entidad,bool> CrearComandoEliminarContacto()
        {
            return new ComandoEliminarContacto();
        }
        public static Comando<Entidad, bool> CrearComandoModificarClienteJuridico()
        {
            return new ComandoModificarClienteJuridico();
        }
        public static Comando<Entidad, bool> CrearComandoModificarClienteNatural()
        {
            return new ComandoModificarClienteNatural();
        }
        public static Comando<bool, List<String>> CrearComandoConsultarListaCargos()
        {
            return new ComandoConsultarListaCargos();
        }
        #endregion

        #region Modulo 3
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarContactosInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarContactosInvolucrados();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarUsuarioInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarUsuariosInvolucrados();
        }
        public static Comando<Dominio.Entidad, List<Dominio.Entidad>> CrearConsultarCargosContactos()
        {
            return new Comandos.Modulo3.ComandoConsultarCargosContactos();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoConsultarContactoInvolucrados()
        {
            return new Comandos.Modulo3.ComandoAgregarContactosInvolucrados();
        }
        public static Comando<Dominio.Entidad, List<Dominio.Entidad>> CrearComandoConsultarUsuariosInvolucrados()
        {

            return new Comandos.Modulo3.ComandoConsultarUsuariosInvolucradosPorProyecto();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> CrearComandoDatosContactoID()
        {

            return new Comandos.Modulo3.ComandoDatosContactoID();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> CrearComandoDatosUsuariosUsername()
        {

            return new Comandos.Modulo3.ComandoDatosUsuarioUsername();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarContactoDeInvolucradosEnProyecto()
        {

            return new Comandos.Modulo3.ComandoEliminarContactoDeIvolucradosEnProyecto();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarUsuariosDeInvolucradosEnProyecto()
        {

            return new Comandos.Modulo3.ComandoEliminarUsuariosDeIvolucradosEnProyecto();
        }
        public static Comando<Entidad, List<Dominio.Entidad>> CrearComandoListarContactosPorCargoEmpresa()
        {

            return new Comandos.Modulo3.ComandoListarContactosPorCargoEmpresa();
        }
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        public static Comando<Dominio.Entidad, Boolean> CrearComandoAgregarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoAgregarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoEliminarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoEliminarRequerimiento();
        }
        public static Comando<Dominio.Entidad, Dominio.Entidad> 
            CrearComandoConsultarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimiento();
        }
        public static Comando<String,
        List<Dominio.Entidad>> CrearComandoConsultarRequerimientosProyecto()
        {
            return new Comandos.Modulo5.ComandoConsultarRequerimientosProyecto();
        }
        public static Comando<Dominio.Entidad, Boolean> CrearComandoModificarRequerimiento()
        {
            return new Comandos.Modulo5.ComandoModificarRequerimiento();
        }
        #endregion

        #region Modulo 6

        public static Comando<Entidad, bool> CrearComandoAgregarActor() 
        {
            return new ComandoAgregarActor(); 
        }

        #endregion

        #region Modulo 7
        /// <summary>
        /// Metodo que Instancia el Comando de Agregar Usuario
        /// </summary>
        /// <returns>El comando Agregar Usuario</returns>
        public static Comando<Entidad,bool> CrearComandoAgregarUsuario()
        {
            return new ComandoAgregarUsuario();
        }

        /// <summary>
        /// Metodo que Instancia el comando de validar Username Unico
        /// </summary>
        /// <returns></returns>
        public static Comando<String,bool> CrearComandoValidarUsernameUnico()
        {
            return new ComandoValidarUsernameUnico();
        }

        /// <summary>
        /// Metodo que instancia el comando de validar Correo unico
        /// </summary>
        /// <returns></returns>
        public static Comando<String, bool> CrearComandoValidarCorreoUnico()
        {
            return new ComandoValidarCorreoUnico();
        }
        #endregion

        #region Modulo 8
        #endregion
    }
}