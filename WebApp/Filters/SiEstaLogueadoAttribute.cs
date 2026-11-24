using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class SiEstaLogueadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var id = context.HttpContext.Session.GetInt32("IdLogueado");
            var rol = context.HttpContext.Session.GetString("RolLogueado");

            // si ROL tiene Contenido > accede al if > redirige al Index del Investigador
            if (!string.IsNullOrEmpty(rol))
            {
                // de estar Logueado, no debe acceder al Login, al Registro ni a la Bienvenida
                context.Result = new RedirectToActionResult("Index", "Investigador", null);
            }

            base.OnActionExecuting(context);
        }
    }
}