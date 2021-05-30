using Aplication.Interfaces;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CovidController : ControllerBase
    {
        private readonly ICovidAppService _covidAppService;

        public CovidController(ICovidAppService covidAppService)
        {
            _covidAppService = covidAppService;
        }

        [HttpGet("Buscar-todos")]
        public IActionResult BuscarTodos()
        {
            return Ok(_covidAppService.BuscarTodos());

        }
        [HttpGet("Buscar-por-pais")]
        public IActionResult BuscarPorPais(string pais)
        {
            return Ok(_covidAppService.BuscarPorPais(pais));
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar()
        {
            try
            {
                _covidAppService.Cadastrar();
                return Ok();
            }
                catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar([FromQuery] CovidPaisDto dto)
        {
            try
            {
                _covidAppService.Alterar(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Remover")]
        public IActionResult Remover(string pais)
        {
            try
            {
                _covidAppService.Remover(pais);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Paises-mais-afetados")]
        public IActionResult PaisesMaisAfetados()
        {
            return Ok(_covidAppService.PaisesMaisAfetados());
        }
    }
}
