using Connection.Interfaces;
using Domain.Dto;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Connection.Services
{
    public class BoxTiApi : IBoxTiApi
    {
        private readonly IConfiguration _configuration;

        public BoxTiApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<CovidPaisRetornoApiDto>> BuscarTodos()
        {
            var url = _configuration.GetSection("ApiBoxTI").Get<string>();
            var chave = _configuration.GetSection("ApiBoxTiChave").Get<string>();
            var chaveValor = _configuration.GetSection("ApiBoxTiChaveValor").Get<string>();

            HttpClient http = new();
            http.DefaultRequestHeaders.Add(chave, chaveValor);
            var response = http.GetStreamAsync(url);

            return await JsonSerializer.DeserializeAsync<List<CovidPaisRetornoApiDto>>(await response);
        }

        public async Task<CovidPaisRetornoApiDto> BuscarPorPais(string pais)
        {
            var url = _configuration.GetSection("ApiBoxTI").Get<string>() + $"/{pais}";
            var chave = _configuration.GetSection("ApiBoxTiChave").Get<string>();
            var chaveValor = _configuration.GetSection("ApiBoxTiChaveValor").Get<string>();

            HttpClient http = new();
            http.DefaultRequestHeaders.Add(chave, chaveValor);
            var response = http.GetStreamAsync(url);
            return await JsonSerializer.DeserializeAsync<CovidPaisRetornoApiDto>(await response);
        }
    }
}