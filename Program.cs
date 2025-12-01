using Microsoft.EntityFrameworkCore;
using DreamQuest.Data;
using DreamQuest.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar a Sessão
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 2. Configurar a Base de Dados
builder.Services.AddDbContext<AgenciaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AgenciaDbConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. CONFIGURAÇÃO AUTOMÁTICA DA BASE DE DADOS E ADMIN
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AgenciaDbContext>();

        // A. Cria a Base de Dados se não existir
        context.Database.Migrate();

        // B. --- CRIAR ADMIN ---
        // Verifica se já existe algum utilizador com este email
        if (!context.Utilizadores.Any(u => u.Email == "admin@dreamquest.com"))
        {
            // Se não existir, cria o Administrador
            var admin = new Utilizador
            {
                Nome = "Administrador Principal",
                Email = "admin@dreamquest.com",
                Password = "123", // A password
                Role = "Administrador"
            };

            context.Utilizadores.Add(admin);
            context.SaveChanges(); 
            Console.WriteLine(">>> ADMIN CRIADO COM SUCESSO! <<<");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao configurar BD: " + ex.Message);
    }
}


app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();