using Invitaciones.Entidades;
using Invitaciones.Interfaces;

namespace Invitaciones.Repositorios
{
    public class InvitadoRepository : IInvitadoRepository
    {
        // Simulamos deu una base de datos con una lista de invitados
        private readonly List<Invitado> _invitados = new List<Invitado>();

        public void Guardar(Invitacion invitacion)
        {
         
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
