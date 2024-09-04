using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba3_Adam_Garcia.Models;

namespace prueba3_Adam_Garcia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly BlogContext _context;
        public ComentarioController(BlogContext context)
        {
            _context = context;
        }

    }
}
