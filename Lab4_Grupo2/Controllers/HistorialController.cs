using Lab4_Grupo2.Models.Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Grupo2.Controllers
{
    public class HistorialController : Controller
    {
        // GET: HistorialController
        public ActionResult Index()
        {
            return View(Singleton.Instance.Historial);
        }
    }
}
