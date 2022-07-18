using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripExpenses.Models
{
    public class AllParams
    {
        public string action { get; set; }
        public int requestId { get; set; }
        public string user { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string date_begin { get; set; }
        public string date_end { get; set; }
        public double summaAll { get; set; }
        public double valutaAll { get; set; }
        public double daily { get; set; }
        public double mobile { get; set; }
        public double hospitality { get; set; }
        public double transport { get; set; }
        public double residence { get; set; }
        public double unexpected { get; set; }
    }

    public class Request
    {
        public int RequestId { get; set; }
        public string user { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public DateTime date_begin { get; set; }
        public DateTime date_end { get; set; }
        public double summaAll { get; set; }
        public double valutaAll { get; set; }
        public double daily { get; set; }
        public double mobile { get; set; }
        public double hospitality { get; set; }
        public double transport { get; set; }
        public double residence { get; set; }
        public double unexpected { get; set; }
    }
}
