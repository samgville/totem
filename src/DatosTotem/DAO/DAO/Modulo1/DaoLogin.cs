﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Dominio;
using Dominio.Entidades;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using DAO.IntefazDAO.Modulo1;


namespace DAO.DAO.Modulo1
{
    public class DaoLogin : DAO,IDaoLogin
    {
        private Entidad _usuario = FabricaEntidades.ObtenerUsuario();

        #region Metodos IDAOLogin
        public Entidad ValidarUsuarioLogin(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;

            if (usuario.Username != null && usuario.Clave != null && usuario.Username != "" && usuario.Clave != "")
            {
                try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_ValidarLogin, Conectar());
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Username, usuario.Username));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave, usuario.Clave));

                    SqlDataReader leer;
                    Conectar().Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        _usuario = FabricaEntidades.ObtenerUsuario(usuario.Username, usuario.Clave,
                            leer[RecursosDaoModulo1.Parametro_Output_Usu_nombre].ToString(),
                            leer[RecursosDaoModulo1.Parametro_Output_Usu_apellido].ToString(),
                            leer[RecursosDaoModulo1.Parametro_Output_Usu_rol].ToString(),
                            leer[RecursosDaoModulo1.Parametro_Output_Usu_correo].ToString(),
                            null, null,
                            leer[RecursosDaoModulo1.Parametro_Output_Usu_cargo].ToString());

                        return _usuario;
                    }
                    else
                    {
                        ExcepcionesTotem.Modulo1.LoginErradoException excep = new ExcepcionesTotem.Modulo1.LoginErradoException(
                            RecursosDaoModulo1.Codigo_Login_Errado,
                            RecursosDaoModulo1.Mensaje_Login_Errado, new Exception());
                        ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                        throw excep;
                    }
                }
                 catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.LoginErradoException excep= new ExcepcionesTotem.Modulo1.LoginErradoException(
                        ex.Codigo,
                        ex.Mensaje, ex);

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(
                        RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                finally
                {
                    Desconectar();
                }
            }
            else
            {
                UsuarioVacioException excep=  new UsuarioVacioException(
                    RecursosDaoModulo1.Codigo_Usuario_Vacio, 
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio, new Exception());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
        }

        public Entidad ObtenerPreguntaSeguridad(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            if (usuario != null && usuario.Correo != null && usuario.Correo != "")
            {
                try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Obtener_Pregunta_Seguridad, Conectar());
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, usuario.Correo));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Output_PreguntaSeguridad, SqlDbType.VarChar));

                    SqlDataReader leer;
                    Conectar().Open();

                    leer = sqlcom.ExecuteReader();
                    if(leer!= null)
                    {
                        usuario.PreguntaSeguridad = leer[RecursosDaoModulo1.Parametro_Output_PreguntaSeguridad].ToString();
                    }
                    return usuario;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            else
            {
                UsuarioVacioException excep= new UsuarioVacioException(RecursosDaoModulo1.Codigo_Usuario_Vacio,
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                    new UsuarioVacioException());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            
        }

        public bool ValidarRespuestaSeguridad(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool ValidarCorreoExistente(string correo)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metodos IDao

        public bool Modificar(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;

            try
            {
                if (usuario.Username != null && usuario.Clave != null && usuario.Username 
                    != "" && usuario.Clave != "" && usuario.Correo != "")
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Cambiar_Clave, Conectar());
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave,
                        SqlDbType.VarChar));

                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Correo].Value = usuario.Correo;
                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Clave].Value = usuario.Clave;

                    SqlDataReader leer;
                    Conectar().Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
             else
                {
                    ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosDaoModulo1.Codigo_Usuario_Vacio,
                        RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar();
            }
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}
