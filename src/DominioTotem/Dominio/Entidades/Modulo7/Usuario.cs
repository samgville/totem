﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Dominio.Entidades.Modulo7
{
    /// <summary>
    /// Clase que representa al Usuario y contiene todos sus atributos heredando de Entidad lo correspondiente al ID
    /// </summary>
    public class Usuario:Entidad
    {
        #region Atributos
        //Atributos de la Clase Usuario
        private int idUsuario;
		private int idCargo;
        private string username;
        private string clave;
        private string nombre;
        private string apellido;
        private string rol;
        private string correo;
        private string preguntaSeguridad;
        private string respuestaSeguridad;
        private string cargo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor vacio de la clase Usuario
        /// </summary>
        ///
        public Usuario():base()
        {

        }
        
        /// <summary>
        /// Constructor de la clase Usuario que contiene el id de la Base de Datos
        /// </summary>
        /// <param name="idUsuario">su ID en la Base de Datos</param>
        /// <param name="username">Username del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="rol">Rol que ocupa</param>
        /// <param name="correo">Correo del Usuario</param>
        /// <param name="preguntaSeguridad">Pregunta de seguridad si olvida su clave</param>
        /// <param name="respuestaSeguridad">Respuesta a la pregunta de seguridad</param>
        /// <param name="cargo">Cargo que ocupa</param>
        public Usuario(int idUsuario, string username, string clave, string nombre, string apellido, string rol,
            string correo, string preguntaSeguridad, string respuestaSeguridad, string cargo):base(idUsuario)
        {
            this.idUsuario = idUsuario;
            this.username = username;
            this.clave = clave;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.correo = correo;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.cargo = cargo;
        }

        /// <summary>
        /// Constructor de la clase Usuario que no contiene el id de la Base de Datos
        /// </summary>
        /// <param name="username">Username del usuario</param>
        /// <param name="clave">Clave del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="rol">Rol que ocupa</param>
        /// <param name="correo">Correo del Usuario</param>
        /// <param name="preguntaSeguridad">Pregunta de seguridad si olvida su clave</param>
        /// <param name="respuestaSeguridad">Respuesta a la pregunta de seguridad</param>
        /// <param name="cargo">Cargo que ocupa</param>
        public Usuario(string username, string clave, string nombre, string apellido, string rol, string correo, 
            string preguntaSeguridad, string respuestaSeguridad, string cargo):base()
        {
            this.username = username;
            this.clave = clave;
            this.nombre = nombre;
            this.apellido = apellido;
            this.rol = rol;
            this.correo = correo;
            this.preguntaSeguridad = preguntaSeguridad;
            this.respuestaSeguridad = respuestaSeguridad;
            this.cargo = cargo;
        }

        /// <summary>
        /// Constructor de la clase Usuario que contiene su informacion basica
        /// </summary>
        /// <param name="username">Username del usuario</param>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="apellido">Apellido del usuario</param>
        /// <param name="cargo">Cargo que ocupa</param>
        public Usuario(string username, string nombre, string apellido, string cargo):base()
        {
            this.username = username;
            this.nombre = nombre;
            this.apellido = apellido;
            this.cargo = cargo;
            
        }

		/// <summary>
		/// Constructor de la clase Usuario que contiene el id de la Base de Datos y el id del cargo
		/// </summary>
		/// <param name="idUsuario">su ID en la Base de Datos</param>
		/// <param name="idCargo">su ID en la Base de Datos</param>
		/// <param name="username">Username del usuario</param>
		/// <param name="clave">Clave del usuario</param>
		/// <param name="nombre">Nombre del usuario</param>
		/// <param name="apellido">Apellido del usuario</param>
		/// <param name="rol">Rol que ocupa</param>
		/// <param name="correo">Correo del Usuario</param>
		/// <param name="preguntaSeguridad">Pregunta de seguridad si olvida su clave</param>
		/// <param name="respuestaSeguridad">Respuesta a la pregunta de seguridad</param>
		/// <param name="cargo">Cargo que ocupa</param>
		public Usuario(int idUsuario, int idCargo, string username, string clave, string nombre, string apellido,
			string rol, string correo, string preguntaSeguridad, string respuestaSeguridad, string cargo)
			: base(idUsuario)
		{
			this.idCargo = idCargo;
			this.idUsuario = idUsuario;
			this.username = username;
			this.clave = clave;
			this.nombre = nombre;
			this.apellido = apellido;
			this.rol = rol;
			this.correo = correo;
			this.preguntaSeguridad = preguntaSeguridad;
			this.respuestaSeguridad = respuestaSeguridad;
			this.cargo = cargo;
		}

		/// <summary>
		/// Constructor de la clase Usuario que contiene solo el username
		/// </summary>
		/// <param name="username"></param>
		public Usuario(string username)
		{
			this.username = username;
		}

		/// <summary>
		/// Constructor de la clase Usuario que contiene solo el username y el rol
		/// </summary>
		/// <param name="username"></param>
		/// <param name="rol"></param>
		public Usuario(string username, string rol)
		{
		    this.username = username;
		    this.rol = rol;
		}
        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna el ID del usuario y tambien permite asignarle un ID nuevo
        /// </summary>
        public int IdUsuario 
        {
            get { return this.idUsuario; }
            set { this.idUsuario = value; } 
        }

		/// <summary>
		/// Retorna el ID del cargo del usuario y tambien permite asignarle un ID nuevo
		/// </summary>
		public int IdCargo
		{
			get { return this.idCargo; }
			set { this.idCargo = value; }
		}

        /// <summary>
        /// Returna el username del usuario y tambien permite asignar un username nuevo
        /// </summary>
        public string Username
        { 
            get { return this.username; }
            set { this.username = value; }
        }

        /// <summary>
        /// Retorna la clave del usuario y tambien permite asignarle una clave nueva
        /// </summary>
        public string Clave 
        {
            get { return this.clave; }
            set { this.clave = value; } 
        }

        /// <summary>
        /// Retorna el nombre del usuario y tambien permite asignarle un nombre nuevo
        /// </summary>
        public string Nombre 
        {
            get { return this.nombre; }
            set { this.nombre = value; } 
        }

        /// <summary>
        /// Retorna el apellido del usuario y tambien permite asigrnale un apellido nuevo
        /// </summary>
        public string Apellido 
        {
            get { return this.apellido; }
            set { this.apellido = value; } 
        }

        /// <summary>
        /// Retorna el Rol del usuario y tambien permite asignarle un rol nuevo
        /// </summary>
        public string Rol 
        {
            get { return this.rol; }
            set { this.rol = value; } 
        }

        /// <summary>
        /// Retorna el Correo del usuario y tambien permite asignarle un correo nuevo
        /// </summary>
        public string Correo 
        {
            get { return this.correo; }
            set { this.correo = value; } 
        }

        /// <summary>
        /// Retorna la Pregunta de Seguridad y tambien permite asignarle una pregunta de seguridad nueva
        /// </summary>
        public string PreguntaSeguridad 
        {
            get { return this.preguntaSeguridad; }
            set { this.preguntaSeguridad = value;} 
        }

        /// <summary>
        /// Retorna la Respuesta de Seguridad y tambien permite asignarle una respuest ade seguridad nueva
        /// </summary>
        public string RespuestaSeguridad 
        {
            get { return this.respuestaSeguridad; }
            set { this.respuestaSeguridad = value ;} 
        }

        /// <summary>
        /// Retorna el cargo y tambien permite asignarle un cargo nuevo
        /// </summary>
        public string Cargo 
        {
            get { return this.cargo; }
            set { this.cargo = value; } 
        }
        #endregion

        #region MetodosEspeciales
        /// <summary>
        /// Metodo que permite validar si el correo ingresado es correcto
        /// </summary>
        /// <param name="correoValidar"></param>
        /// <returns>Verdadero si lo es o falso sino lo es </returns>
        public Boolean ValidarCorreo(String correoValidar)
        {
            if (this.correo == correoValidar)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que le calcula el hash a la clave actual del usuario y se la cambia al objeto con 
        /// la nueva clave creada
        /// </summary>
        public void CalcularHash()
        {
            if (this.clave != null)
            {
                byte[] claveEnBytes = new byte[this.clave.Length * sizeof(char)];
                System.Buffer.BlockCopy(this.clave.ToCharArray(), 0, claveEnBytes, 0, claveEnBytes.Length);
                SHA256 shaM = new SHA256Managed();
                byte[] hashClave = shaM.ComputeHash(claveEnBytes);
                this.clave = BitConverter.ToString(hashClave);
            }
        }
        #endregion
    }
}