
using System.Text.Json.Serialization;

namespace Domain.Dto
{
    public class CovidPaisRetornoApiDto
    {
        [JsonPropertyName("Active Cases_text")]
        public string Active_Cases_text { get; set; }
        [JsonPropertyName("Country_text")]
        public string Country_text { get; set; }
        [JsonPropertyName("Last Update")]
        public string Last_Update { get; set; }
        [JsonPropertyName("New Cases_text")]
        public string New_Cases_text { get; set; }
        [JsonPropertyName("New Deaths_text")]
        public string New_Deaths_text { get; set; }
        [JsonPropertyName("Total Cases_text")]
        public string Total_Cases_text { get; set; }
        [JsonPropertyName("Total Deaths_text")]
        public string Total_Deaths_text { get; set; }
        [JsonPropertyName("Total Recovered_text")]
        public string Total_Recovered_text { get; set; }

    }
}
