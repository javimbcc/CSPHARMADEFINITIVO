using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models.ConsultasPostgreSQL;

namespace CSPHARMA_DEF.Controllers
{
    public class RegistroController : Controller
    {
        //añadimos nuestro archivo de configuracion json para recoger la cadena de conexion
        private readonly IConfiguration _config;
        public RegistroController(IConfiguration config)
        {
            _config = config;
        }
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(String name, String password)
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

    }
}
