﻿using DAL.Modelo;
using Npgsql;
using System.Xml.Linq;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.DTOs.DataToList;
/*
 * Clase que contiene todas nuestras consultasSQL
 *@author Jmenabc 
 */

namespace WebApplication1.Models.ConsultasPostgreSQL
{
    public class ConsultasPostgreSQLcs
    {
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        //                                  CONSULTAS DE LOS USUARIOS
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------

        //Metodo para loguearte en la aplicacion

        public static List<DlkCatAccEmpleadoDTOcs> listaDeEmpleadosLogin(IConfiguration _config, string name, string password)
        {
            try
            {
                List<DlkCatAccEmpleadoDTOcs> usuarioData = new List<DlkCatAccEmpleadoDTOcs>();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Entrando al metodo");
                //Hacemos la conexion
                using var connection = new NpgsqlConnection(_config.GetConnectionString("EFCConexion"));
                connection.Open();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Abriendo conexion");
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Hacemos y ejecutamos la consulta");
                //ConsultaSQL
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Generando consulta");
                NpgsqlCommand consulta = new NpgsqlCommand($"SELECT * FROM \"dlk_informacional\".\"dlk_cat_acc_empleado\" WHERE cod_empleado='{name}' AND clave_empleado='{password}'", connection);
                Console.WriteLine(consulta.ToString());
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Ejecutando consulta");
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                Console.WriteLine(resultadoConsulta.ToString());
                //Cerramos la conexion
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleadosLogin]: Cerrando conexion");
                usuarioData = loginToList.ReaderToList(resultadoConsulta);
                connection.Close();
                //devolvemos el resultado
                return usuarioData;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        //Metodo para crear usuarios

        public static void registrarUsuario(IConfiguration _config, string name, string password)
        {
            try
            {
                //creamos la conexion
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Entrando al metodo");
                using var connection = new NpgsqlConnection(_config.GetConnectionString("EFCConexion"));
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Abriendo conexion");
                Console.WriteLine("HABRIENDO CONEXION");
                //Abrimos la conexion
                connection.Open();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Creando consulta");
                //Creamos la consulta
                NpgsqlCommand consulta = new NpgsqlCommand($"INSERT INTO \"public\".\"users\" (usuario_nick, usuario_password,nivel_acceso_empleado) VALUES('{name}','{password}',2)", connection);
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: ejecutando consulta");
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                //Ejecutamos la consulta
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Cerrando conexion");
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Saliendo del metodo");
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //Metodo para recoger todos los empleados
        public static List<DlkCatAccEmpleadoDTOcs> listaDeEmpleados(IConfiguration _config)
        {
           try
            {
                List<DlkCatAccEmpleadoDTOcs> usuarioData = new List<DlkCatAccEmpleadoDTOcs>();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Entrando al metodo");
                //Hacemos la conexion
                using var connection = new NpgsqlConnection(_config.GetConnectionString("EFCConexion"));
                connection.Open();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Abriendo conexion");
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Hacemos y ejecutamos la consulta");
                //ConsultaSQL
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Generando consulta");
                NpgsqlCommand consulta = new NpgsqlCommand($"SELECT * FROM \"dlk_informacional\".\"dlk_cat_acc_empleado\"", connection);
                Console.WriteLine(consulta.ToString());
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Ejecutando consulta");
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                Console.WriteLine(resultadoConsulta.ToString());
                //Cerramos la conexion
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaDeEmpleados]: Cerrando conexion");
                usuarioData = loginToList.ReaderToList(resultadoConsulta);
                connection.Close();
                //devolvemos el resultado
                return usuarioData;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        //Metodo para recoger los datos de un usuario con su codEmpleado
        public static List<DlkCatAccEmpleadoDTOcs> listaEmpleadoCODEMP(IConfiguration _config, long codEmp)
        {
            try
            {
                List<DlkCatAccEmpleadoDTOcs> usuarioData = new List<DlkCatAccEmpleadoDTOcs>();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Entrando al metodo");
                //Hacemos la conexion
                using var connection = new NpgsqlConnection(_config.GetConnectionString("EFCConexion"));
                connection.Open();
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Abriendo conexion");
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Hacemos y ejecutamos la consulta");
                //ConsultaSQL
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Generando consulta");
                NpgsqlCommand consulta = new NpgsqlCommand($"SELECT * FROM \"dlk_informacional\".\"dlk_cat_acc_empleado\" WHERE cod_empleado = '{codEmp}' ", connection);
                Console.WriteLine(consulta.ToString());
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Ejecutando consulta");
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                Console.WriteLine(resultadoConsulta.ToString());
                //Cerramos la conexion
                Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-listaEmpleadoCODEMP]: Cerrando conexion");
                usuarioData = loginToList.ReaderToList(resultadoConsulta);
                Console.WriteLine(usuarioData);
                connection.Close();
                //devolvemos el resultado
                return usuarioData;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
