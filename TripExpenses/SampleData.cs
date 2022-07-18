using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripExpenses.Models;

namespace TripExpenses
{
    public class SampleData
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Rates.Any())
            {
                context.Rates.AddRange(
                    new Rate { Rate_name = "USD", Val = 28.05 },
                    new Rate { Rate_name = "EUR", Val = 34.25 },
                    new Rate { Rate_name = "GBP", Val = 39.50 },
                    new Rate { Rate_name = "PLN", Val = 7.90 }
                );
                context.SaveChanges();
            }
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                    new Status { Status_name = "A", daily = 5000, mobile = 1000, hospitality = 2000, transport = 5000, residence = 1000, unexpected = 10000 },
                    new Status { Status_name = "B", daily = 500, mobile = 300, hospitality = 1000, transport = 2500, residence = 700, unexpected = 2000 },
                    new Status { Status_name = "C", daily = 300, mobile = 300, hospitality = 500, transport = 1000, residence = 500, unexpected = 500 },
                    new Status { Status_name = "D", daily = 200, mobile = 100, hospitality = 100, transport = 1000, residence = 300, unexpected = 200 }
                );
                context.SaveChanges();
            }
            if (!context.Countrys.Any())
            {
                context.Countrys.AddRange(
                    new Country { Country_name = "Україна", RateId = 0 },
                    new Country { Country_name = "Німеччина", RateId = 2 },
                    new Country { Country_name = "Польща", RateId = 4 },
                    new Country { Country_name = "Америка", RateId = 1 },
                    new Country { Country_name = "Франція", RateId = 2 }
                );
                context.SaveChanges();
            }
            if (!context.Citys.Any())
            {
                context.Citys.AddRange(
                    new City { CountryId = 1, City_name = "Київ", Transp_ratio = 1.5, Count_people = "2 954 564", Lat = 50.4501, Lng = 30.5234 },
                    new City { CountryId = 1, City_name = "Харків", Transp_ratio = 1.5, Count_people = "1 430 885", Lat = 49.9935, Lng = 36.23038 },
                    new City { CountryId = 1, City_name = "Львів", Transp_ratio = 1.5, Count_people = "721 301", Lat = 49.8397, Lng = 24.0297 },
                    new City { CountryId = 5, City_name = "Париж", Transp_ratio = 1.5, Count_people = "2 175 601", Lat = 48.8566, Lng = 2.3522 },
                    new City { CountryId = 3, City_name = "Варшава", Transp_ratio = 1.5, Count_people = "1 790 658", Lat = 52.2297, Lng = 21.0122 },
                    new City { CountryId = 2, City_name = "Берлін", Transp_ratio = 1.5, Count_people = "3 664 088", Lat = 52.5200, Lng = 13.4050 }
                );
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Last_name = "Сорокін", First_name = "Андрій", Patronymic_name = "Олександрович",
                               Sam_name = "adm", Password = "adm", Position = "Системний адміністратор",
                               Telephone_number = "+380687777720", Email = "sorokinol@gmail.com", Role = 3, Status = ""
                    },
                    new User
                    {
                        Last_name = "Іванов",
                        First_name = "Іван",
                        Patronymic_name = "Іванович",
                        Sam_name = "ivan",
                        Password = "ivan",
                        Position = "Менеджер",
                        Telephone_number = "+380686789820",
                        Email = "ivanovivan@gmail.com",
                        Role = 1,
                        Status = "C"
                    },
                    new User
                    {
                        Last_name = "Петров",
                        First_name = "Андрій",
                        Patronymic_name = "Олександрович",
                        Sam_name = "petr",
                        Password = "petr",
                        Position = "Консультант",
                        Telephone_number = "+380635878920",
                        Email = "zaikinev@gmail.com",
                        Role = 1,
                        Status = "B"
                    },
                    new User
                    {
                        Last_name = "Шаповалова",
                        First_name = "Карина",
                        Patronymic_name = "Данилівна",
                        Sam_name = "bux",
                        Password = "bux123",
                        Position = "Бухгалтер",
                        Telephone_number = "+380687874520",
                        Email = "karinchik20000@gmail.com",
                        Role = 2,
                        Status = ""
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
