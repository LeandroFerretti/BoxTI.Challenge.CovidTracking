
using System;

namespace Domain.Dto
{
    public class CovidPaisDto
    {
        public int Active_Cases_text { get; set; }
        public string Country_text { get; set; }
        public DateTime? Last_Update { get; set; }
        public string New_Cases_text { get; set; }
        public string New_Deaths_text { get; set; }
        public int? Total_Cases_text { get; set; }
        public int? Total_Deaths_text { get; set; }
        public int? Total_Recovered_text { get; set; }

    }
}
