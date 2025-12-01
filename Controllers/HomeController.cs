using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DreamQuest.Data;
using DreamQuest.Models;
using System.Linq;

namespace DreamQuest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgenciaDbContext _context;

        public HomeController(AgenciaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Se for Administrador, vai buscar os voos para mostrar na Home
            if (HttpContext.Session.GetString("UserRole") == "Administrador")
            {
                var voos = _context.Voos.ToList();
                return View(voos); // Envia a lista para a View
            }

            // Se for Passageiro ou Visitante, não envia voos (envia null)
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}