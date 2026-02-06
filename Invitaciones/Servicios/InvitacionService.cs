using Invitaciones.Entidades;
using Invitaciones.Interfaces;
using Invitaciones.Enums;

namespace Invitaciones.Servicios
{
    public class InvitacionService
    {
        private readonly IInvitadoRepository _repository;
        private readonly NotificadorContext _notificador;
        private readonly List<INotificadorAsistencia> _observadores = new();

        public InvitacionService(IInvitadoRepository repository, NotificadorContext notificador)
        {
            _repository = repository;
            _notificador = notificador;
            Suscribir(new MonitorAnfitrion());
        }

        // --- MÉTODOS DE CONSULTA  ---

        // Nuevo método para el panel del anfitrión
        public IEnumerable<Invitado> ObtenerTodosLosInvitados()
        {
            return _repository.ObtenerTodos();
        }

        public Invitado? ObtenerPorNombre(string nombre)
        {
            return _repository.ObtenerTodos().FirstOrDefault(i => i.Nombre == nombre);
        }

        // --- MÉTODOS DE ACCIÓN  ---

        public void ConfirmarAsistencia(Invitado invitado, EstadoInvitado nuevoEstado)
        {
            invitado.Estado = nuevoEstado;
            _repository.Actualizar(invitado);
            NotificarObservadores(invitado);
        }

        public void ProcesarNuevaInvitacion(Invitacion invitacion, string contacto)
        {
            if (string.IsNullOrWhiteSpace(invitacion.NombreAnfitrion) || string.IsNullOrWhiteSpace(invitacion.Lugar))
            {
                throw new ArgumentException("Error: Datos obligatorios faltantes.");
            }

            ValidarYConfigurarNotificador(contacto);
            _repository.Guardar(invitacion);
            _notificador.EnviarNotificacion($"Invitación para: {invitacion.Lugar}", contacto);
        }

        // --- GESTIÓN DE OBSERVADORES Y LÓGICA INTERNA ⚙ ---

        public void Suscribir(INotificadorAsistencia observador)
        {
            if (!_observadores.Contains(observador)) _observadores.Add(observador);
        }

        private void NotificarObservadores(Invitado invitado)
        {
            foreach (var observador in _observadores) observador.Actualizar(invitado);
        }

        private void ValidarYConfigurarNotificador(string contacto)
        {
            if (contacto.Contains("@")) _notificador.SetStrategy(new EmailNotificador());
            else _notificador.SetStrategy(new WhatsappNotificador());
        }
    }
}