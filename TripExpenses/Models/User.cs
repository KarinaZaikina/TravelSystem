using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripExpenses.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string Patronymic_name { get; set; }
        public string Sam_name { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Telephone_number { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string Status { get; set; }
    }
}
