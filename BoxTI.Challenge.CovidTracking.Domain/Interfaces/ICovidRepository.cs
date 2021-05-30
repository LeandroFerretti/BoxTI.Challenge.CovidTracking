
using Domain.Entidades;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ICovidRepository
    {
        IEnumerable<CovidPais> BuscarTodos();
        CovidPais BuscarPorPais(string pais);

        bool PaisJaRegistrado(string pais);
        void Cadastrar(CovidPais pais);
        void GravarAlteracao(CovidPais pais);
        void Remover(CovidPais pais);
    }
}
