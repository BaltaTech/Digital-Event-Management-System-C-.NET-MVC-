using Invitaciones.Entidades;
using Invitaciones.Repositorios;
using Invitaciones.Servicios;
using Invitaciones.Enums;

// 1. Configuramos el sistema
var repositorios = new InvitadoRepository();
var contexto = new NotificadorContext();
var service = new InvitacionService(repositorios, contexto);

// 2. Creamos y suscribimos al observador (El Anfitrión que escucha) 👂
var monitor = new MonitorAnfitrion();
service.Suscribir(monitor);

// 3. Creamos un invitado de prueba
var invitadoReal = new Invitado
{
    Id = 1,
    Nombre = "Carlos Ruiz",
    contacto = "carlos@email.com"
};

Console.WriteLine("--- Iniciando Simulación de Evento Real ---");

// 4. El invitado decide confirmar (esto disparará el Patrón Observador) 🔔
service.ConfirmarAsistencia(invitadoReal, EstadoInvitado.Confirmado);

Console.WriteLine("\n--- Simulación Finalizada ---");