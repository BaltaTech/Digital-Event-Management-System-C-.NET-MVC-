using Invitaciones.Entidades;

namespace Invitaciones.Interfaces
{
    // Esta es la base para cualquier "Observador" que quiera saber si alguien confirmó
    public interface INotificadorAsistencia
    {
        void Actualizar(Invitado invitado);
    }
}