using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DreamQuest.Data;
using DreamQuest.Models;
using System.Linq;

namespace DreamQuest.Controllers
{
    public class ContaController : Controller
    {
        private readonly AgenciaDbContext _context;

        public ContaController(AgenciaDbContext context)
        {
            _context = context;
        }

        // GET: Registar
        public IActionResult Registar()
        {
            return View();
        }

        // POST: Registar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registar(Utilizador utilizador)
        {
            // Verifica se o email já existe
            if (_context.Utilizadores.Any(u => u.Email == utilizador.Email))
            {
                ModelState.AddModelError("Email", "Este email já está registado.");
                return View(utilizador);
            }

            if (ModelState.IsValid)
            {
                utilizador.Role = "Passageiro"; // Define padrão como Passageiro
                _context.Utilizadores.Add(utilizador);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(utilizador);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Utilizadores
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Guardar dados na Sessão
                HttpContext.Session.SetInt32("UserId", user.UtilizadorId);
                HttpContext.Session.SetString("UserName", user.Nome);
                HttpContext.Session.SetString("UserRole", user.Role);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Email ou password incorretos.";
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}