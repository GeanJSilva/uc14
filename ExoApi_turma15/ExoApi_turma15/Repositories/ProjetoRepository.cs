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

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Cadastrar(Projeto p)
        {
            _context.Projetos.Add(p);
            _context.SaveChanges();
        }

        public void Deletar(int id) 
        {
            Projeto p = _context.Projetos.Find(id); 
            _context.Projetos.Remove(p);    
            _context.SaveChanges();
        }

        public void Alterar(int id, Projeto p)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);

            if (projetoBuscado != null) 
            {
                projetoBuscado.NomeDoProjeto = p.NomeDoProjeto;
                projetoBuscado.Area = p.Area;
                projetoBuscado.Status = p.Status;

                _context.Update(projetoBuscado);
                _context.SaveChanges();
            }
        }
    }
}
