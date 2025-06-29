using Microsoft.AspNetCore.Mvc;

namespace ProyectoMongoDB.Controllers
{

	public class MainController : Controller
	{
		
		public ActionResult Index()
		{
			return View();
		}
	}
}
