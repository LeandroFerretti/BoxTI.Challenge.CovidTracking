
using Domain.Interfaces;
using Domain.Entidades;
using Infra.Context;
using System.Linq;
using System.Collections.Generic;

namespace Infra.Repositorios
{
    public class CovidRepository : ICovidRepository
    {
        private readonly ContextBase _context;
        public CovidRepository(ContextBase context)
        {
            _context = context;
        }
      
        public IEnumerable<CovidPais> BuscarTodos() =>
            _context.Covid;

        public CovidPais BuscarPorPais(string pais) =>
                    _context.Covid.FirstOrDefault(x => x.Country_text == pais);

        public bool PaisJaRegistrado(string pais) => _context.Covid.Any(x => x.Country_text == pais);

        public void Cadastrar(CovidPais pais)
        {
            _context.Covid.Add(pais);
            _context.SaveChanges();
        }

        public void GravarAlteracao(CovidPais pais)
        {
            _context.Covid.Update(pais);
            _context.SaveChanges();
        }

        public void Remover(CovidPais pais)
        {
            _context.Covid.Remove(pais);
            _context.SaveChanges();
        }

    }
}
