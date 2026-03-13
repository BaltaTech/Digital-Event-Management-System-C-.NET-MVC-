namespace Invitaciones.Entidades
{
    public class Invitacion
    {
        public int Id { get; set; }
        public string NombreAnfitrion { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;
        public Invitado InvitadoPrincipal { get; set; } = new Invitado();
    }
}
