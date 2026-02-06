namespace Invitaciones.Entidades
{
    public class Invitacion
    {
        public int Id { get; set; }
        public string NombreAnfitrion { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;

        // ¡Aquí es donde debe estar! Una invitación tiene un invitado asignado.
        public Invitado InvitadoPrincipal { get; set; } = new Invitado();
    }
}