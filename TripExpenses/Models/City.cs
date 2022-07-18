using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripExpenses.Models
{
    public class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string City_name { get; set; }
        public double Transp_ratio { get; set; }
        public string Count_people { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
