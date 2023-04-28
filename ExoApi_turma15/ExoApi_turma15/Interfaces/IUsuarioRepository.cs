using ExoApi_turma15.Models;
using System.ComponentModel.DataAnnotations;

namespace ExoApi_turma15.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar(int id);

        Usuario Login(String Email, String Senha);

    }
}
