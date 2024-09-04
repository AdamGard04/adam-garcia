using Microsoft.EntityFrameworkCore;
using prueba3_Adam_Garcia.Dto;
using prueba3_Adam_Garcia.Models;

namespace prueba3_Adam_Garcia.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BlogContext _context;

        public UsuarioService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
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

        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDTO
            {
                Username = usuario.Username,
                Email = usuario.Email,
                PasswordHash = usuario.PasswordHash
            };
        }

        public async Task<UsuarioDTO> CreateUsuarioAsync(UsuarioDTO usuarioDto)
        {
            var usuario = new Usuario
            {
                Username = usuarioDto.Username,
                Email = usuarioDto.Email,
                PasswordHash = usuarioDto.PasswordHash
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuarioDto;
        }

        public async Task<bool> UpdateUsuarioAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return false;
            }

            usuario.Username = usuarioDto.Username;
            usuario.Email = usuarioDto.Email;
            usuario.PasswordHash = usuarioDto.PasswordHash;

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UserId == id);
        }
    }
}

