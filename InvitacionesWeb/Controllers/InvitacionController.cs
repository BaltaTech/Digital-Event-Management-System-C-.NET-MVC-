using Invitaciones.Enums;
using Invitaciones.Servicios;
using Microsoft.AspNetCore.Mvc;

public class InvitacionController : Controller
{
    private readonly InvitacionService _invitacionService;

    public InvitacionController(InvitacionService invitacionService)
    {
        _invitacionService = invitacionService;
    }

    // GET: /Invitacion 📊
    public IActionResult Index()
    {
        // Llamamos al método que trae la lista completa 
        var listaInvitados = _invitacionService.ObtenerTodosLosInvitados();

        // Pasamos la lista a la vista para evitar el NullReferenceException
        return View(listaInvitados);
    }

    // GET: /Invitacion/Detalles?nombre=... ✉️
    public IActionResult Detalles(string nombre)
    {
        var invitado = _invitacionService.ObtenerPorNombre(nombre);
        if (invitado == null) return NotFound("No se encontró al invitado.");
        return View(invitado);
    }

    // POST: /Invitacion/ConfirmarAsistencia 🛡️
    [HttpPost]
    public IActionResult ConfirmarAsistencia(string nombre, bool confirmar)
    {
        var invitado = _invitacionService.ObtenerPorNombre(nombre);

        // Capa de seguridad: Solo procesamos si el invitado existe y está Pendiente
        if (invitado != null && invitado.Estado == EstadoInvitado.Pendiente)
        {
            EstadoInvitado nuevoEstado = confirmar ? EstadoInvitado.Confirmado : EstadoInvitado.NoAsistira;
            _invitacionService.ConfirmarAsistencia(invitado, nuevoEstado);
        }

        return RedirectToAction("Detalles", new { nombre = nombre });
    }
}