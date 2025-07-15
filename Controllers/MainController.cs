using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProyectoMongoDB.Services;
using ProyectoMongoDB.Models;

namespace ProyectoMongoDB.Controllers
{
	public class MainController : Controller
	{
        private readonly MongoDbService mongoService;        
		public MainController (MongoDbService mongoDbService)
		{
			mongoService = mongoDbService;			
		}

        public async Task<IActionResult> Index()
		{
            var autosColeccion = mongoService.ObtenerColeccion<Auto>("autos");

            var autos = await autosColeccion.Find(auto => true).ToListAsync();

            return View(autos);
        }

		public ActionResult Motos()
		{
            return View();
        }

	}
}
