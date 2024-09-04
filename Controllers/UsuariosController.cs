using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba3_Adam_Garcia.Dto;
using prueba3_Adam_Garcia.Models;

namespace prueba3_Adam_Garcia.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly BlogContext _context;
        public UsuariosController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult GetUsuarios()
        {
            return View();
        }
        public async Task<IActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios()
        {
            return await _context.Usuarios
               .Select(u => new UsuarioDTO
               {
                   Username = u.Username,
                   Email = u.Email,
                   PasswordHash = u.PasswordHash
               })
               .ToListAsync();
        }
    }
}
