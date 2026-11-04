using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class NoEstaLogueadoAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var id = context.HttpContext.Session.GetInt32("IdLogueado");
        var rol = context.HttpContext.Session.GetString("RolLogueado");

        // si ROL es Nulo o "" > accede al if > redirige al Login
        if (string.IsNullOrEmpty(rol))
        {
            // de no estar Logueado, no debe acceder al Controller
            context.Result = new RedirectToActionResult("Login", "Acceso", null);
        }

        base.OnActionExecuting(context);
    }
}