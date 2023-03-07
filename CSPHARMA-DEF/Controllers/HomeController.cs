using DAL.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using WebApplication1.Models;
using WebApplication1.Models.ConsultasPostgreSQL;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.DTOs.DataToList;
/*
* Controlador de la vista de Login
* @author Jmenabc
*/
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //añadimos nuestro archivo de configuracion json para recoger la cadena de conexion
        private readonly IConfiguration _config;
        //Recogemos el contexto de la aplicacion y lo inicializamos
        private readonly DAL.Modelo.CspharmaInformacionalContext _context;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, DAL.Modelo.CspharmaInformacionalContext context)
        {
            _logger = logger;
            _config = config;
            _context = context;
        }

        //Pagina de logueo

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomePage()
        {
            return View();
        }


        //Metodo post para comprobar si los credenciales de inicio de sesión son correctos

        [HttpPost]    
        public IActionResult Index(string name, string password)
        {
            //Hacemos la consulta y comprobamos si tiene resultados
            List<DlkCatAccEmpleadoDTOcs> resultadoConsulta = ConsultasPostgreSQLcs.listaDeEmpleadosLogin(_config, name, password);
            //Despues de hacer la consulta guardamos sus datos en una lista para poder leer el rol de usuario que tienen 
            if (resultadoConsulta.Count() == 1)
            {
                //Metemos los valores en ViewBags para pasarlos a la vista
                String Rol = resultadoConsulta[0].NivelAccesoEmpleado.ToString();
                //Guardamos el nombre del usuario en la session y su rol para poder reusarlo en toda la aplicacion
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("_User")))
                {
                    HttpContext.Session.SetString("_User", name);
                }
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
                {
                    HttpContext.Session.SetString("_Rol",Rol);
                }
                return View("HomePage");
            }
            else
            {
                Console.WriteLine("Recuerde sus credenciales");
                return View("Index");
            }
            return View();
        }

        
        
    }
}