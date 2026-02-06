using Invitaciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitaciones.Servicios
{
    public class WhatsappNotificador : INotificadorStrategy
    {
        public void Enviar(string mensaje, string destino)
            => Console.WriteLine($"Enviando WhatsApp a {destino}: {mensaje}");
    }
}
