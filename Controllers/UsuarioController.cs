using BlackJack_Api.DataContext;
using BlackJack_Api.Results;
using BlackJack_Api.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private byte[] GetHash(string key)
        {
            var bytes = Encoding.UTF8.GetBytes(key);
            return new SHA256Managed().ComputeHash(bytes);
        }

        private readonly BlackJackContext context;

        public UsuarioController(BlackJackContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        [Route("getUsuarios")]
        public async Task<ActionResult> getUsuarios()
        {
            var lista = await context.Usuarios.ToListAsync();

            return Ok(lista);
        }

        [HttpPost]
        [Route("loginUsuario")]
        public async Task<ActionResult<ResultadoBase>> postLogin([FromBody] LoginComando comando)
        {
            ResultadoBase resultado = new ResultadoBase();
            var usuario = await context.Usuarios.Where(c => c.Email.Equals(comando.Email) && c.Clave.Equals(comando.Clave)).FirstOrDefaultAsync();
            if (usuario != null)
            {
                resultado.setOk();
                return Ok(resultado);
            }
            else
            {
                resultado.setError("Usuario no encontrado");
                return BadRequest(resultado);
            }
        }

    }
}
