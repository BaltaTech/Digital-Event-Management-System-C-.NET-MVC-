using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invitaciones.Interfaces
{
    public interface INotificadorStrategy
    {
        // El método que todas las estrategias deben implementar
        void Enviar(string mensaje, string destino);
    }
}