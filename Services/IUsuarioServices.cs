using prueba3_Adam_Garcia.Dto;
using prueba3_Adam_Garcia.Models;

namespace prueba3_Adam_Garcia.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync();
        Task<UsuarioDTO> GetUsuarioByIdAsync(int id);
        Task<UsuarioDTO> CreateUsuarioAsync(UsuarioDTO usuarioDto);
        Task<bool> UpdateUsuarioAsync(int id, UsuarioDTO usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);
    }
}
