using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSPHARMA_DEF.Controllers
{
    public class PedidosController : Controller
    {
        // GET: PedidosController
        public ActionResult ListaPedidos()
        {
            return View("ListaPedidos");
        }

        
    }
}
