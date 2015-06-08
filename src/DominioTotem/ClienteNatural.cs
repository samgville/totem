﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DominioTotem
{
   public class ClienteNatural
    {

        #region Atributos
        private int cliNat_Id;
        private String cliNat_Cedula;
        private String cliNat_Nombre;
        private String cliNat_Apellido;
        private String cliNat_Correo;
        
        private Telefono cliNat_Telefono;
        private Direccion cliNat_Direccion;

        #endregion
        #region Propiedades
        public int Nat_Id
        {
            get { return cliNat_Id;  }
            set { cliNat_Id = value; }
        }
        public String Nat_Cedula
        {
            get { return cliNat_Cedula; }
            set { cliNat_Cedula = value; }
        }
        public String Nat_Nombre
        {
            get { return cliNat_Nombre; }
            set { cliNat_Nombre = value; }
        }
        public String Nat_Apellido
        {
            get { return cliNat_Apellido; }
            set { cliNat_Apellido = value; }
        }
        public String Nat_Correo
        {
            get { return cliNat_Correo; }
            set { cliNat_Correo = value; }
        }
        public Telefono Nat_Telefono
        {
            get { return cliNat_Telefono; }
            set { cliNat_Telefono = value; }
        }
        public Direccion Nat_Direccion
        {
            get { return cliNat_Direccion; }
            set { cliNat_Direccion = value; }
        }

        #endregion


       /// <summary>
       /// Constructor de la Clase Cliente Natural 
       /// </summary>
        public ClienteNatural() 
        {
            Nat_Id = -1;
            Nat_Nombre = String.Empty;
            Nat_Apellido = String.Empty;
            Nat_Correo = String.Empty;
            Nat_Direccion = null;
            Nat_Telefono = null;
        
        }

       /// <summary>
       /// Constructor de la Clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente </param>
       /// <param name="apellido">Apellido del Cliente</param>
        public ClienteNatural(int id, String nombre, String apellido)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = String.Empty;
            Nat_Direccion = null;
            Nat_Telefono = null;

        }

       /// <summary>
       /// Constructor de la clase Cliente Natural
       /// </summary>
       /// <param name="id">Número de Cédula o Identificador del Cliente</param>
       /// <param name="nombre">Nombre del Cliente</param>
       /// <param name="apellido">Apellido del Cliente</param>
       /// <param name="correo">Correo del Cliente</param>
        public ClienteNatural(int id, String nombre, String apellido, String correo, Direccion dir)
        {
            Nat_Id = id;
            Nat_Nombre = nombre;
            Nat_Apellido = apellido;
            Nat_Correo = correo;
            Nat_Direccion = dir;
            Nat_Telefono = null;

        }
       
        public override bool Equals(object obj)
        {
            bool esIgual = false;
            ClienteNatural client = (obj as ClienteNatural);

            if (this.Nat_Id == (client).Nat_Id
                && this.Nat_Nombre == (client).Nat_Nombre
                && this.Nat_Apellido == (client).Nat_Apellido)
                esIgual = true;

            return esIgual;
        }


    }
}
