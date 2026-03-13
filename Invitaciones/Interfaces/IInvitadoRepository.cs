using Invitaciones.Entidades;

namespace Invitaciones.Interfaces
{
    public interface IInvitadoRepository
    {
        void Guardar(Invitacion invitacion);
        void Actualizar(Invitado invitado);
        IEnumerable<Invitado> ObtenerTodos();
    }
}
