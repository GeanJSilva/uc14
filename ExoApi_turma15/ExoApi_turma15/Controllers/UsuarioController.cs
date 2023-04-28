using ExoApi_turma15.Models;
using ExoApi_turma15.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi_turma15.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult BuscaPorId(int id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                    if (usuarioBuscado == null)
                   {
                        return NotFound();
                    }
                    return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpDelete("{id}")]

        public IActionResult Deletar(int id) 
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return Ok("Usuario Deletado!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPut ("{id}")]

        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario Atualizado!");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





    }
}
