using Invitaciones.Entidades;
using Invitaciones.Interfaces;

namespace Invitaciones.Servicios
{
    public class MonitorAnfitrion : INotificadorAsistencia
    {
        // Este método se ejecuta automáticamente cuando el servicio "avisa"
        public void Actualizar(Invitado invitado)
        {
            Console.WriteLine("\n[NOTIFICACIÓN TIEMPO REAL]");
            Console.WriteLine($"Anfitrión, el invitado {invitado.Nombre} ha cambiado su estado a: {invitado.Estado}");

            if (invitado.Estado == Enums.EstadoInvitado.Confirmado)
            {
                Console.WriteLine("¡Prepara una silla extra! 🎉");
            }
        }
    }
}