
using Domain.Dto;
using System;

namespace Domain.Entidades

{
    public class CovidPais
    {
        public long Id { get; set; }
        public int Active_Cases_text { get; set; }
        public string Country_text { get; set; }
        public DateTime? Last_Update { get; set; }
        public string New_Cases_text { get; set; }
        public string New_Deaths_text { get; set; }
        public int? Total_Cases_text { get; set; }
        public int? Total_Deaths_text { get; set; }
        public int? Total_Recovered_text { get; set; }

        protected CovidPais() { }
        public CovidPais(CovidPaisDto dto)
        {
            Active_Cases_text = dto.Active_Cases_text;
            Country_text = dto.Country_text;
            Last_Update = dto.Last_Update;
            New_Cases_text = dto.New_Cases_text;
            New_Deaths_text = dto.New_Deaths_text;
            Total_Cases_text = dto.Total_Cases_text;
            Total_Deaths_text = dto.Total_Deaths_text;
            Total_Recovered_text = dto.Total_Recovered_text;
        }
        public void Alterar(CovidPaisDto dto)
        {

            if (dto.Active_Cases_text != null)
                Active_Cases_text = dto.Active_Cases_text;
            if (dto.Last_Update != null)
                Last_Update = dto.Last_Update;
            if (dto.New_Cases_text != null)
                New_Cases_text = dto.New_Cases_text;
            if (dto.New_Deaths_text != null)
                New_Deaths_text = dto.New_Deaths_text;
            if (dto.Total_Cases_text != null)
                Total_Cases_text = dto.Total_Cases_text;
            if (dto.Total_Deaths_text != null)
                Total_Deaths_text = dto.Total_Deaths_text;
            if (dto.Total_Recovered_text != null)
                Total_Recovered_text = dto.Total_Recovered_text;
        }

    }
}