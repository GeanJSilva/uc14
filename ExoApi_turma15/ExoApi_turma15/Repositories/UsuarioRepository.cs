using ExoApi_turma15.Contexts;
using ExoApi_turma15.Interfaces;
using ExoApi_turma15.Models;

namespace ExoApi_turma15.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;

        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }



        public void Atualizar(int id, Usuario usuario)
        {
            Usuario UsuarioBuscado = _context.Usuarios.Find(id);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.Email= usuario.Email;
                UsuarioBuscado.Senha = usuario.Senha;
                UsuarioBuscado.Tipo = usuario.Tipo;

                _context.Update(UsuarioBuscado);
                _context.SaveChanges();
            }
        }



        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.First(u=>u.Email == email && u.Senha ==senha);
        }
    }
}
