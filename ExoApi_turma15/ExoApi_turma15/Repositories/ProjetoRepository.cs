using ExoApi_turma15.Contexts;
using ExoApi_turma15.Models;

namespace ExoApi_turma15.Repositories
{
    public class ProjetoRepository
    {
        private readonly SqlContext _context;
        public ProjetoRepository(SqlContext context)
        {
            _context = context;

        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }
    }
}
