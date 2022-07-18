using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripExpenses.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Status_name { get; set; }
        public double daily { get; set; }
        public double mobile { get; set; }
        public double hospitality { get; set; }
        public double transport { get; set; }
        public double residence { get; set; }
        public double unexpected { get; set; }
    }
}
