using Microsoft.AspNetCore.Mvc;
using ProyectoMongoDB.Models;
using ProyectoMongoDB.Services;

namespace ProyectoMongoDB.Controllers   
{
    public class LoginController : Controller
    {
        private readonly MongoDbService mongoService;        
		public LoginController (MongoDbService mongoDbService)
		{
			mongoService = mongoDbService;			
		}
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index (string idUsuario, string contrasena)
        {
            var usuario = await mongoService.ValidarCredencialesUsuario(idUsuario, contrasena);            

            if (usuario != null) {
                HttpContext.Session.SetString("IdUsuario", usuario.IdUsuario);                

                return RedirectToAction("PanelInicio", "Login");

            } else return RedirectToAction("Index", "Login");

        }
        [ValidarSesion]
        public ActionResult PanelInicio ()
        {
            return View();
        }

    }
}
