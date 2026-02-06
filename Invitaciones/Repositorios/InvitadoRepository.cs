using Invitaciones.Entidades;
using Invitaciones.Interfaces;

namespace Invitaciones.Repositorios
{
    public class InvitadoRepository : IInvitadoRepository
    {
        // Simulamos la base de datos con una lista de invitados 👥
        private readonly List<Invitado> _invitados = new List<Invitado>();

        public void Guardar(Invitacion invitacion)
        {
            // En una app real, aquí guardarías la invitación y sus invitados vinculados
            // Por ahora, si la invitación trae un invitado, lo sumamos a la lista
            if (invitacion.InvitadoPrincipal != null)
            {
                _invitados.Add(invitacion.InvitadoPrincipal);
            }
        }

        public IEnumerable<Invitado> ObtenerTodos()
        {
            return _invitados;
        }

        public void Actualizar(Invitado invitado)
        {
            // Buscamos al invitado existente para actualizar su estado (Confirmado/Rechazado)
            var invitadoExistente = _invitados.FirstOrDefault(i => i.Nombre == invitado.Nombre);

            if (invitadoExistente != null)
            {
                invitadoExistente.Estado = invitado.Estado;
            }
        }
    }
}