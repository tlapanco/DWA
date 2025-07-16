using Microsoft.AspNetCore.Mvc;
using ProyectoMongoDB.Models;
using ProyectoMongoDB.Services;
using MongoDB.Driver;

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
        public async Task<IActionResult> PanelInicio ()
        {
            string? idUsuario = HttpContext.Session.GetString("IdUsuario");
            var usuariosColeccion = mongoService.ObtenerColeccion<Usuario>("usuarios");
            var usuario = await usuariosColeccion.Find(usuario => usuario.IdUsuario == idUsuario).FirstOrDefaultAsync();
            ViewBag.Usuario = usuario.Nombre;

            var autosColeccion = mongoService.ObtenerColeccion<Auto>("autos");
            var autos = await autosColeccion.Find(auto => true).ToListAsync();
            

            return View(autos);
        }
        
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
        [HttpDelete]
        public async Task<ActionResult> BorrarAuto(string idAuto)
        {
            var autosColeccion = mongoService.ObtenerColeccion<Auto>("autos");

            var autoFiltrado = Builders<Auto>.Filter.Eq(auto => auto.ID, idAuto);
            
            var resultado = await autosColeccion.DeleteOneAsync(autoFiltrado);

            return RedirectToAction("PanelInicio", "Login");
        }

    }
}
