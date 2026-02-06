using Invitaciones.Interfaces;
using Invitaciones.Repositorios;
using Invitaciones.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<InvitacionService>();
builder.Services.AddSingleton<IInvitadoRepository, InvitadoRepository>(); builder.Services.AddSingleton<NotificadorContext>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var repo = scope.ServiceProvider.GetRequiredService<IInvitadoRepository>();

    // Creamos la invitación y el invitado que usaremos para probar
    var prueba = new Invitaciones.Entidades.Invitacion
    {
        NombreAnfitrion = "Gemini",
        Lugar = "La Nube",
        InvitadoPrincipal = new Invitaciones.Entidades.Invitado
        {
            Nombre = "Programador",
            Estado = Invitaciones.Enums.EstadoInvitado.Pendiente
        }
    };

    repo.Guardar(prueba);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Invitacion}/{action=Index}/{id?}");

app.Run();
