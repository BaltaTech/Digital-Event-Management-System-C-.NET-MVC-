using Invitaciones.Entidades;

namespace Invitaciones.Interfaces
{
    public interface IInvitadoRepository
    {
        void Guardar(Invitacion invitacion);

        // Añadimos estos dos métodos obligatorios
        void Actualizar(Invitado invitado);
        IEnumerable<Invitado> ObtenerTodos();
    }
}