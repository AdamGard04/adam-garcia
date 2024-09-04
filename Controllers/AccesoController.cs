using Microsoft.AspNetCore.Mvc;
using prueba3_Adam_Garcia.Dto;
using prueba3_Adam_Garcia.Models;
using Microsoft.EntityFrameworkCore;

namespace prueba3_Adam_Garcia.Controllers
{
    public class AccesoController : Controller
    {
        private readonly BlogContext _context;
        public AccesoController(BlogContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioDTO usuarioDTO)
        {
            Usuario? usuario_encontrado = await _context.Usuarios
                                            .Where(u => u.Email == usuarioDTO.Email 
                                            && u.PasswordHash == usuarioDTO.PasswordHash)
                                            .FirstOrDefaultAsync();
            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontró al usuario solicitado";
                return View();
            }
            return View();
        }
    }
}
