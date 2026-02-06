using Invitaciones.Enums;

namespace Invitaciones.Entidades
{
    public class Invitado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contacto { get; set; } = string.Empty; // Corregí 'contacto' a 'Contacto' (C# prefiere mayúsculas)

        public EstadoInvitado Estado { get; set; } = EstadoInvitado.Pendiente;
        public MetodoContacto PreferenciaEnvio { get; set; }
    }
}