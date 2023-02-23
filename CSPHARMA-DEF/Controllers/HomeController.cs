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

        public IActionResult Index()
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
                ViewBag.IsAdmin = resultadoConsulta[0].NivelAccesoEmpleado.ToString();
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("_User")))
                {
                    HttpContext.Session.SetString("_User", name);
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

        // GET: RegisterController
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(String name, String password)
        {
            //Recogemos la información de la vista
            ViewBag.Name = name;
            ViewBag.Password = password;
            //Comparamos si la contraseña tiene menos de 7 caracteres
            bool mayuscula = false, minuscula = false, numero = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsUpper(password, i))
                {
                    ViewBag.NotLower = "Al menos tiene que tener una minúscula";
                    ViewBag.NotDigit = "Al menos debe de tener un número";
                    mayuscula = true;
                    return View("Register");
                }
                else if (Char.IsLower(password, i))
                {
                    ViewBag.NotUpper = "Al menos tiene que tener una mayúscula";
                    ViewBag.NotDigit = "Al menos debe de tener un número";
                    minuscula = true;
                    return View("Register");
                }
                else if (Char.IsDigit(password, i))
                {
                    ViewBag.NotUpper = "Al menos tiene que tener una mayúscula";
                    ViewBag.NotLower = "Al menos tiene que tener una minúscula";
                    numero = true;
                    return View("Register");
                } 
            }
            if (mayuscula && minuscula && numero && password.Length >= 7)
            {

                Console.WriteLine("La contraseña cumple los requisitos minimos");
                ConsultasPostgreSQLcs.registrarUsuario(_config, name, password);
                Console.WriteLine("Se ha registrado con exito");
                return View("HomePage");
            }
            else
            {
                ViewBag.Lenght = "La longitud minima debe ser de 7 caracteres";
                Console.WriteLine("La contraseña no cumple los requisitos minimos");
                return View("Register");
            }
            return View();
        }

        //Controlador para listar los empleados
        public IActionResult verEmpleados()
        {
            //Declaramos la lista
            //Hacemos la consulta y metemos sus datos en la lista
            List<DlkCatAccEmpleadoDTOcs> resultadoConsulta = ConsultasPostgreSQLcs.listaDeEmpleados(_config);
            //Devolvemos los datos a la vista
            return View("verEmpleados",resultadoConsulta);
        }

        //Ventana de editar usuario
        // GET: DlkCatAccEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {

            var dlkCatAccEmpleado = await _context.DlkCatAccEmpleados.FindAsync(id);
            return View("editarEmpleado", dlkCatAccEmpleado);
        }

        // POST: DlkCatAccEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MdUuid,MdDate,CodEmpleado,ClaveEmpleado,NivelAccesoEmpleado")] DlkCatAccEmpleado dlkCatAccEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Update(dlkCatAccEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(verEmpleados));
            }
            return View("editarEmpleado", dlkCatAccEmpleado);
        }
        //public IActionResult editarEmpleado(long id)
        //{
        //    List<DlkCatAccEmpleadoDTOcs> usuarioAEditar = ConsultasPostgreSQLcs.listaEmpleadoCODEMP(_config, id);
        //    Console.WriteLine(usuarioAEditar.Count());

        //    return View("editarEmpleado",usuarioAEditar);
        //}

        //[HttpPost,ActionName("editarEmpleado")]
        //public IActionResult editar(long rol, String clave)
        //{
        //    long id = 32;

        //    ConsultasPostgreSQLcs.editarUsuario(_config, rol, clave, id);

        //    return View("editarEmpleado");
        //}



    }
}