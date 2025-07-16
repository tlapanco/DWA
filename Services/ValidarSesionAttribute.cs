using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ProyectoMongoDB.Services;

public class ValidarSesionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext contexto)
    {
        var userId = contexto.HttpContext.Session.GetString("IdUsuario");
        /*En caso de no existir usuario en la sesión, redirigir al log in*/
        if (string.IsNullOrEmpty(userId)) contexto.Result = new RedirectToActionResult("Index", "Login", null);
    }
}
