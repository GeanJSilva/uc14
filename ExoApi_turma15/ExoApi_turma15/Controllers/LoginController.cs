using ExoApi_turma15.Interfaces;
using ExoApi_turma15.Models;
using ExoApi_turma15.Repositories;
using ExoApi_turma15.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExoApi_turma15.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public LoginController(IUsuarioRepository iusuarioRepository)
        {
            _iusuarioRepository = iusuarioRepository;
        }

        [HttpGet]

        public IActionResult login(LoginViewModel dadosLogin)
        {
            try
            {
                Usuario UsuarioBuscado = _iusuarioRepository.Login(dadosLogin.email, dadosLogin.senha);

                if (UsuarioBuscado == null)
                {
                    return Unauthorized(new {msg = "E-mail ou senha incorretos"});
                }

//TOKEN
                var minhasClains = new[]
                {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, UsuarioBuscado.Id.ToString()),
                new Claim(ClaimTypes.Role, UsuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao"));
                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
                var meuTokem = new JwtSecurityToken(

                    issuer:"exoapi",
                    audience:"exoapi",
                    claims:minhasClains,
                    expires:DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                    
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(meuTokem) });

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
