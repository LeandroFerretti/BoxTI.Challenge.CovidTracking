
using Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connection.Interfaces
{
    public interface IBoxTiApi
    {
        Task<List<CovidPaisRetornoApiDto>> BuscarTodos();
        Task<CovidPaisRetornoApiDto> BuscarPorPais(string pais);

    }
}
