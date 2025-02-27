﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlDataReader lector { get; set; }
        public SqlConnection conexion { get; }
        public SqlCommand comando { get; set; }
        private int affectedRows;

        public AccesoDatos()
        {
            conexion = new SqlConnection("data source=localhost\\SQLEXPRESS; initial catalog=TP_WEB; integrated security=sspi");
            comando = new SqlCommand();
            comando.Connection = conexion;
            affectedRows = 0;
        }

        public void setearQuery(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void prepareStatement(string statement)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = statement;
        }
        public SqlDataReader getReader()
        {
            return lector;
        }

        public int getAffectedRows()
        {
            return affectedRows;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre,valor);
        }

        public void ejecutarLector()
        {
                conexion.Open();
                lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            conexion.Close();
        }

        public void ejecutarAccion()
        {
                conexion.Open();
                comando.ExecuteNonQuery();
        }
    }
}
