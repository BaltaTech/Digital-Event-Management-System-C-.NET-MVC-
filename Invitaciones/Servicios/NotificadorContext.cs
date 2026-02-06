using Invitaciones.Interfaces;

namespace Invitaciones.Servicios
{
    public class NotificadorContext
    {
        private INotificadorStrategy? _strategy;

        // 1. Aquí definimos qué estrategia usar (WhatsApp o Email)
        public void SetStrategy(INotificadorStrategy strategy)
        {
            _strategy = strategy;
        }

        // 2. Aquí ejecutamos el envío
        public void EnviarNotificacion(string mensaje, string destino)
        {
            if (_strategy == null)
            {
                throw new InvalidOperationException("No se ha seleccionado una estrategia de envío.");
            }
            _strategy.Enviar(mensaje, destino);
        }
    }
}