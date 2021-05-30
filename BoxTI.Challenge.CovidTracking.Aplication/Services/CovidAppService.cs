using Aplication.Interfaces;
using Connection.Interfaces;
using Domain.Dto;
using Domain.Entidades;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplication.Services
{
    public class CovidAppService : ICovidAppService
    {
        private readonly IBoxTiApi _boxTiApi;
        private readonly ICovidRepository _covidRepository;
        public CovidAppService(IBoxTiApi boxTiApi,
            ICovidRepository covidRepository)
        {
            _boxTiApi = boxTiApi;
            _covidRepository = covidRepository;
        }

        public List<CovidPaisRetornoApiDto> BuscarTodos() =>
            _boxTiApi.BuscarTodos().Result;

        public CovidPaisRetornoApiDto BuscarPorPais(string pais) =>
            _boxTiApi.BuscarPorPais(pais).Result;

        public void Cadastrar()
        {
            var PaisesCovid = BuscarTodos();

            foreach (var paisCovid in PaisesCovid)
            {
                if (paisCovid.Country_text != null)
                {
                    if (!_covidRepository.PaisJaRegistrado(paisCovid.Country_text))
                    {
                    CovidPais covidPais = new(ConverterDto(paisCovid));
                    _covidRepository.Cadastrar(covidPais);
                    }
                }
            }
        }

        public void Alterar(CovidPaisDto dto)
        {
            var paisCovid = RegistroPais(dto.Country_text);
            paisCovid.Alterar(dto);
            _covidRepository.GravarAlteracao(paisCovid);
        }

        public void Remover(string pais) =>
            _covidRepository.Remover(RegistroPais(pais));

        public List<DiferencaCovidPaisDto> PaisesMaisAfetados()
        {
            var covidPaises = _covidRepository.BuscarTodos().OrderByDescending(x => x.Active_Cases_text).ToList();

            var dto = new List<DiferencaCovidPaisDto>();

            var contador = 0;

            foreach (var pais in covidPaises)
            {
                if (pais.Country_text != null)
                {
                    var diferencaCovid = new DiferencaCovidPaisDto();
                    int cemPorCento = 0;

                    if (pais.Country_text == covidPaises[0].Country_text)
                        cemPorCento = Convert.ToInt32(pais.Active_Cases_text);
                    else
                        cemPorCento = Convert.ToInt32(covidPaises[contador - 1].Active_Cases_text);

                    if (cemPorCento == 0)
                        cemPorCento = 1;

                    diferencaCovid.Pais = pais.Country_text;
                    diferencaCovid.ValorDosCasos = Convert.ToInt32(pais.Active_Cases_text);
                    diferencaCovid.Diferenca = (double)(covidPaises[contador].Active_Cases_text * 100) / (double)cemPorCento;
                    
                    dto.Add(diferencaCovid);
                    contador++;
                }
            }
            return dto;
        }
        private CovidPais RegistroPais(string pais)
        {
            var paisCovid = _covidRepository.BuscarPorPais(pais);
            if (paisCovid == null)
                throw new ArgumentException($"Não encontrado o pais: {pais} na base de dados para seguir a operação");

            return paisCovid;
        }
        private static CovidPaisDto ConverterDto(CovidPaisRetornoApiDto dto)
        {
            CovidPaisDto covidPais = new();

            covidPais.Active_Cases_text = (!string.IsNullOrWhiteSpace(dto.Active_Cases_text)) ?
                int.Parse(dto.Active_Cases_text.Replace(",", "")) : 0;
            covidPais.Country_text = dto.Country_text;
            covidPais.New_Cases_text = dto.New_Cases_text;
            covidPais.New_Deaths_text = dto.New_Deaths_text;
            covidPais.Total_Cases_text = (!string.IsNullOrWhiteSpace(dto.Total_Cases_text)) ?
                int.Parse(dto.Total_Cases_text.Replace(",", "")) : 0;
            covidPais.Total_Deaths_text = (!string.IsNullOrWhiteSpace(dto.Total_Deaths_text)) ?
                int.Parse(dto.Total_Deaths_text.Replace(",", "")) : 0;
            covidPais.Total_Recovered_text = (!string.IsNullOrWhiteSpace(dto.Total_Recovered_text)) ?
                int.Parse(dto.Total_Recovered_text.Replace(",", "")) : 0;
            if (!string.IsNullOrWhiteSpace(dto.Last_Update))
                covidPais.Last_Update = DateTime.Parse(dto.Last_Update);

            return covidPais;
        }
    }
}
