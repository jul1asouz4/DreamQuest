using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore; 
using DreamQuest.Data;
using DreamQuest.Models;
using System.Linq;
using System;

namespace DreamQuest.Controllers
{
    public class VoosController : Controller
    {
        private readonly AgenciaDbContext _context;

        public VoosController(AgenciaDbContext context)
        {
            _context = context;
        }

        // ÁREA PÚBLICA (CATÁLOGO)

        // GET: Lista de Voos (Aba "Destinos")
        public IActionResult Index()
        {
            var voos = _context.Voos.ToList();
            return View(voos);
        }

        // ÁREA DE ADMINISTRADOR (GESTÃO)

        // GET: Criar Voo
        public IActionResult Criar()
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Criar Voo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Voo voo)
        {
            if (ModelState.IsValid)
            {
                _context.Voos.Add(voo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Volta ao catálogo
            }
            return View(voo);
        }

        // GET: Editar Voo
        public IActionResult Editar(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
                return RedirectToAction("Index");

            var voo = _context.Voos.Find(id);
            if (voo == null) return NotFound();

            return View(voo);
        }

        // POST: Editar Voo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Voo voo)
        {
            if (id != voo.VooId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(voo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(voo);
        }

        // GET: Apagar Voo
        public IActionResult Apagar(int id)
        {
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
                return RedirectToAction("Index");

            var voo = _context.Voos.Find(id);
            if (voo == null) return NotFound();

            return View(voo);
        }

        // POST: Confirmar Apagar
        [HttpPost, ActionName("Apagar")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarApagar(int id)
        {
            var voo = _context.Voos.Find(id);
            if (voo != null)
            {
                _context.Voos.Remove(voo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // ÁREA DE PASSAGEIRO (RESERVAS)
       
        // Ação: Reservar Voo
        public IActionResult Reservar(int id)
        {
            // 1. Verifica se está logado
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Conta");

            // 2. Verifica se o voo existe
            var voo = _context.Voos.Find(id);
            if (voo == null) return NotFound();

            // 3. Cria a reserva
            var novaReserva = new Reserva
            {
                VooId = id,
                UtilizadorId = (int)userId,
                DataReserva = DateTime.Now
            };

            _context.Reservas.Add(novaReserva);

            // 4. Retira um lugar disponível
            if (voo.LugaresDisponiveis > 0) voo.LugaresDisponiveis--;

            _context.SaveChanges();

            // 5. Manda para a página "Minhas Viagens"
            return RedirectToAction("MinhasReservas");
        }

        // GET: Histórico (Aba "Minhas Viagens")
        public IActionResult MinhasReservas()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return RedirectToAction("Login", "Conta");

            var reservas = _context.Reservas
                .Include(r => r.Voo)
                .Where(r => r.UtilizadorId == userId)
                .ToList();

            return View(reservas);
        }
    }
}