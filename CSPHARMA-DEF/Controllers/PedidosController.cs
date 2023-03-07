using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Modelo;
using WebApplication1.Controllers;

namespace CSPHARMA_DEF.Controllers
{
    /*
     * Controlador que gestiona los pedidos existentes
     * Busca por formulario
     * Elimina por id
     * @author Jmenabc
     */
    public class PedidosController : Controller
    {
        //añadimos nuestro archivo de configuracion json para recoger la cadena de conexion
        private readonly IConfiguration _config;
        //Recogemos el contexto de la aplicacion y lo inicializamos
        private readonly DAL.Modelo.CspharmaInformacionalContext _context;

        public PedidosController(IConfiguration config, DAL.Modelo.CspharmaInformacionalContext context)
        {
            _config = config;
            _context = context;
        }

        // Recogemos y enviamos la lista de pedidos a la vista
        public async Task<IActionResult> Index()
        {
            var cspharmaInformacionalContext = _context.TdcTchEstadoPedidos.Include(t => t.CodEstadoDevolucionNavigation).Include(t => t.CodEstadoEnvioNavigation).Include(t => t.CodEstadoPagoNavigation).Include(t => t.CodLineaNavigation);
            return View(await cspharmaInformacionalContext.ToListAsync());
        }

        // Recogemos el pedido que vamos a eliminar por su id
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }
            //Incluimos las foreign keys para que al eliminarlo la base de datos no reviente

            var tdcTchEstadoPedido = await _context.TdcTchEstadoPedidos
                .Include(t => t.CodEstadoDevolucionNavigation)
                .Include(t => t.CodEstadoEnvioNavigation)
                .Include(t => t.CodEstadoPagoNavigation)
                .Include(t => t.CodLineaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            //Una vez lo tenemos todo comprobamos si no hay algun valor a null,
            //En caso de que exista un valor nulo devolveremos la página de not found
            //Indicando que no existe
            if (tdcTchEstadoPedido == null)
            {
                return NotFound();
            }
            //En caso de que todo este correcto iremos a la vista del listado pero actualizada
            return View(tdcTchEstadoPedido);
        }

        // En este metodo es donde enviaremos la peticion de delete, donde se hara
        [HttpPost, ActionName("Delete")] //COn el actionname indicamos a que metodo ejerce el httPost
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //Si nuestro contexto esta vacio (null) directamente le enviaremos un problema a su ventana diciendo
            //que el pedido es null
            if (_context.TdcTchEstadoPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcTchEstadoPedidos'  is null.");
            }
            //En caso de que no sea nulo directamente lo recogeremos por su id
            var tdcTchEstadoPedido = await _context.TdcTchEstadoPedidos.FindAsync(id);
            //hacemos una comprobacion de que no sea nulo
            if (tdcTchEstadoPedido != null)
            {
                //si no es nulo directamente lo eliminamos de la lista
                _context.TdcTchEstadoPedidos.Remove(tdcTchEstadoPedido);
            }
            //Acto despues guardamos el contexto de la aplicacion y volvemos directamente a la vista de la lista (Index)            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
