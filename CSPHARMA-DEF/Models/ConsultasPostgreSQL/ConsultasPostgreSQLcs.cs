using DAL.Modelo;
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

        //Metodo para loguearte en la aplicacion

        public static List<DlkCatAccEmpleadoDTOcs> listaDeEmpleadosLogin(IConfiguration _config, string name, string password)
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
            
           
        }

        //Metodo para crear usuarios

        public static void registrarUsuario(IConfiguration _config, string name, string password)
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
            NpgsqlCommand consulta = new NpgsqlCommand($"INSERT INTO \"public\".\"users\" (usuario_nick, usuario_password) VALUES('{name}','{password}')", connection);
            Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: ejecutando consulta");
            NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
            //Ejecutamos la consulta
            Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Cerrando conexion");
            Console.WriteLine("[Modelos-ConsultasPostgreSQL-ConsultasPostgreSQL-registrarUsuario]: Saliendo del metodo");
        }

        //Metodo para recoger todos los empleados

        public static List<DlkCatAccEmpleadoDTOcs> listaDeEmpleados(IConfiguration _config)
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


        }
    }
    
}
