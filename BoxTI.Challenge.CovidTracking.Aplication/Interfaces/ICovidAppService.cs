
using Domain.Dto;
using Domain.Entidades;
using System.Collections.Generic;

namespace Aplication.Interfaces
{
    public interface ICovidAppService
    {
        List<CovidPaisRetornoApiDto> BuscarTodos();
        CovidPaisRetornoApiDto BuscarPorPais(string pais);
        void Cadastrar();
        void Alterar(CovidPaisDto dto);
        void Remover(string pais);

        List<DiferencaCovidPaisDto> PaisesMaisAfetados();
    }
}
