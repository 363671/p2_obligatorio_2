using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class RedirigirSiLogueadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("RolLogueado");
            var id= context.HttpContext.Session.GetInt32("IdLogueado");

            // se verifica si existe un Usuario Logueado
            if (!string.IsNullOrEmpty(rol))
            {
                // de estar Logueado, no debe acceder al Login, al Registro ni a la Bienvenida
                context.Result = new RedirectToActionResult("Index", "Investigador", null);
            }

            base.OnActionExecuting(context);
        }
    }

}