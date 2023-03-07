using DAL.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Models.ConsultasPostgreSQL;
using WebApplication1.Models.DTOs;

namespace CSPHARMA_DEF.Controllers
{
    /*
     * Controlador que contiene los metodos de listar todos los empleados y su edicion
     * @author Jmenabc
     */
    public class AdministrarEmpleadosController1 : Controller
    {

        //añadimos nuestro archivo de configuracion json para recoger la cadena de conexion
        private readonly IConfiguration _config;
        //Recogemos el contexto de la aplicacion y lo inicializamos
        private readonly DAL.Modelo.CspharmaInformacionalContext _context;

        public AdministrarEmpleadosController1(IConfiguration config, DAL.Modelo.CspharmaInformacionalContext context)
        {
            _config = config;
            _context = context;
        }

        //Controlador para listar los empleados
        public IActionResult verEmpleados()
        {
            //Declaramos la lista
            //Hacemos la consulta y metemos sus datos en la lista
            List<DlkCatAccEmpleadoDTOcs> resultadoConsulta = ConsultasPostgreSQLcs.listaDeEmpleados(_config);
            //Devolvemos los datos a la vista
            return View("verEmpleados", resultadoConsulta);
        }

        //Controlador de editar usuario
        public async Task<IActionResult> Editar(long? id)
        {
            //Nos creamos una variable donde vamos a guardar el id del usuario seleccionado para 
            //Que cuando le demos al boton de editar estemos seguros de que es el usuario que queremos editar
            //Este valor lo pasamos por url en asp-route-id en "verEmpleados"
            var dlkCatAccEmpleado = await _context.DlkCatAccEmpleados.FindAsync(id);
            return View("editarEmpleado", dlkCatAccEmpleado);
        }

        //Controlador que emite la accion de editar 
        //Es decir es el controlador que hace el edit a la base de datos y guarda los cambios
        [HttpPost]
        //Metodo HttpPost dado que estamos haciendo un envio de datos
        //Metodo async para que no se salte procesos en cola y pueda llevar a errores
        public async Task<IActionResult> Editar(long id, DlkCatAccEmpleado dlkCatAccEmpleado)
        {
            _context.Update(dlkCatAccEmpleado);
            await _context.SaveChangesAsync();
            //Una vez terminada la accion devolvemos al usuario a la vista verEmpleados
            return RedirectToAction(nameof(verEmpleados));
            //Pasamos a la vista nuestro modelo de dlkCatAccEmpleado para poder mostrar los valores ya establecidos anteriormente
            return View("editarEmpleado", dlkCatAccEmpleado);
        }
    }
}
