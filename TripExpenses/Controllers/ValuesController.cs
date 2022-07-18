using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TripExpenses.Models;

namespace TripExpenses.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : Controller
    {
        DataContext db;
        public ValuesController(DataContext context)
        {
            db = context;
        }
        private MyType GetParamFromReq<MyType>(Stream body)
        {
            string param_str = null;
            Object obj = null;

            using (StreamReader reader = new StreamReader(body, Encoding.UTF8))
            {
                param_str = reader.ReadToEnd();
            }

            if (!(param_str == null || string.IsNullOrEmpty(param_str)))
            {
                try
                {
                    Stream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(param_str));
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(MyType));
                    obj = jsonFormatter.ReadObject(ms);
                    ms.Close();
                }
                catch //(Exception ex)
                {
                    obj = param_str;
                }
            }

            return (MyType)obj;
        }
        private static string To_Upper(string str)
        {
            if (str.Length > 0) { return Char.ToUpper(str[0]) + str.Substring(1); }
            return "";
        }
        private void AddDb(string table, dynamic row)
        {
            switch (table)
            {
                case "User_List":
                    User user = new User();
                    foreach (dynamic field in row)
                    {
                        switch (To_Upper(field.Name))
                        {
                            case "Last_name":
                                user.Last_name = field.Value;
                                break;
                            case "First_name":
                                user.First_name = field.Value;
                                break;
                            case "Patronymic_name":
                                user.Patronymic_name = field.Value;
                                break;
                            case "Sam_name":
                                user.Sam_name = field.Value;
                                break;
                            case "Password":
                                user.Password = field.Value;
                                break;
                            case "Position":
                                user.Position = field.Value;
                                break;
                            case "Telephone_number":
                                user.Telephone_number = field.Value;
                                break;
                            case "Email":
                                user.Email = field.Value;
                                break;
                            case "Role":
                                user.Role = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Status":
                                user.Status = (field.Value == "" ? 0 : field.Value);
                                break;
                        }
                    }
                    db.Users.Add(user);
                    db.SaveChanges();
                    break;
                case "country_List":
                    Country country = new Country();
                    foreach (dynamic field in row)
                    {
                        switch (To_Upper(field.Name))
                        {
                            case "Country_name":
                                country.Country_name = field.Value;
                                break;
                            case "RateId":
                                country.RateId = (field.Value == "" ? 0 : field.Value);
                                break;
                        }
                    }
                    db.Countrys.Add(country);
                    db.SaveChanges();
                    break;
                case "city_List":
                    City city = new City();
                    foreach (dynamic field in row)
                    {
                        switch (To_Upper(field.Name))
                        {
                            case "CountryId":
                                city.CountryId = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "City_name":
                                city.City_name = field.Value;
                                break;
                            case "Transp_ratio":
                                city.Transp_ratio = (field.Value == "" ? 0 : field.Value);
                                break;
                        }
                    }
                    db.Citys.Add(city);
                    db.SaveChanges();
                    break;
                case "rate_List":
                    Rate rate = new Rate();
                    foreach (dynamic field in row)
                    {
                        switch (To_Upper(field.Name))
                        {
                            case "City_name":
                                rate.Rate_name = field.Value;
                                break;
                            case "Transp_ratio":
                                rate.Val = (field.Value == "" ? 0 : field.Value);
                                break;
                        }
                    }
                    db.Rates.Add(rate);
                    db.SaveChanges();
                    break;
                case "status_List":
                    Status stat = new Status();
                    foreach (dynamic field in row)
                    {
                        switch (To_Upper(field.Name))
                        {
                            case "Status_name":
                                stat.Status_name = field.Value;
                                break;
                            case "Daily":
                                stat.daily = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Mobile":
                                stat.mobile = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Hospitality":
                                stat.hospitality = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Transport":
                                stat.transport = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Residence":
                                stat.residence = (field.Value == "" ? 0 : field.Value);
                                break;
                            case "Unexpected":
                                stat.unexpected = (field.Value == "" ? 0 : field.Value);
                                break;
                        }
                    }
                    db.Statuses.Add(stat);
                    db.SaveChanges();
                    break;
            }
        }

        private void UpdatedDb(string table, dynamic row)
        {
            User user = null;
            Country country = null;
            City city = null;
            Rate rate = null;
            Status stat = null;
            foreach (dynamic par in row)
            {
                if (par.Name == "id") {
                    int curId = par.Value;
                    switch (table)
                     {
                         case "User_List":
                             user = db.Users.Where(u => u.UserId == curId).FirstOrDefault(); 
                             break;
                        case "country_List":
                            country = db.Countrys.Where(u => u.CountryId == curId).FirstOrDefault();
                            break;
                        case "city_List":
                            city = db.Citys.Where(u => u.CityId == curId).FirstOrDefault();
                            break;
                        case "rate_List":
                            rate = db.Rates.Where(r => r.RateId == curId).FirstOrDefault();
                            break;
                        case "status_List":
                            stat = db.Statuses.Where(s => s.StatusId == curId).FirstOrDefault();
                            break;
                    }
                }
                if (par.Name == "updated")
                {
                    dynamic cur = par.Value;
                    switch (table)
                    {
                        case "User_List":
                            foreach (dynamic field in cur)
                            {
                                switch (To_Upper(field.Name))
                                {
                                    case "Last_name":
                                        user.Last_name = field.Value;
                                        break;
                                    case "First_name":
                                        user.First_name = field.Value;
                                        break;
                                    case "Patronymic_name":
                                        user.Patronymic_name = field.Value;
                                        break;
                                    case "Sam_name":
                                        user.Sam_name = field.Value;
                                        break;
                                    case "Password":
                                        user.Password = field.Value;
                                        break;
                                    case "Position":
                                        user.Position = field.Value;
                                        break;
                                    case "Telephone_number":
                                        user.Telephone_number = field.Value;
                                        break;
                                    case "Email":
                                        user.Email = field.Value;
                                        break;
                                    case "Role":
                                        user.Role = field.Value;
                                        break;
                                    case "Status":
                                        user.Status = field.Value;
                                        break;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case "country_List":
                            foreach (dynamic field in cur)
                            {
                                switch (To_Upper(field.Name))
                                {
                                    case "Country_name":
                                        country.Country_name = field.Value;
                                        break;
                                    case "RateId":
                                        country.RateId = (field.Value == "" ? 0 : field.Value);
                                        break;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case "city_List":
                            foreach (dynamic field in cur)
                            {
                                switch (To_Upper(field.Name))
                                {
                                    case "CountryId":
                                        city.CountryId = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "City_name":
                                        city.City_name = field.Value;
                                        break;
                                    case "Transp_ratio":
                                        city.Transp_ratio = (field.Value == "" ? 0 : field.Value) ;
                                        break;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case "rate_List":
                            foreach (dynamic field in cur)
                            {
                                switch (To_Upper(field.Name))
                                {
                                    case "Rate_name":
                                        rate.Rate_name = field.Value;
                                        break;
                                    case "Val":
                                        rate.Val = (field.Value == "" ? 0 : field.Value);
                                        break;
                                }
                            }
                            db.SaveChanges();
                            break;
                        case "status_List":
                            foreach (dynamic field in cur)
                            {
                                switch (To_Upper(field.Name))
                                {
                                    case "Status_name":
                                        stat.Status_name = field.Value;
                                        break;
                                    case "Daily":
                                        stat.daily = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "Mobile":
                                        stat.mobile = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "Hospitality":
                                        stat.hospitality = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "Transport":
                                        stat.transport = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "Residence":
                                        stat.residence = (field.Value == "" ? 0 : field.Value);
                                        break;
                                    case "Unexpected":
                                        stat.unexpected = (field.Value == "" ? 0 : field.Value);
                                        break;
                                }
                            }
                            db.SaveChanges();
                            break;
                    }
                }
              }
          }
        private void DelDb(string table, dynamic row)
        {
            switch (table)
            {
                case "User_List":
                    foreach (dynamic field in row)
                    {
                        if (To_Upper(field.Name) == "UserId")
                        {
                            int fieldId = field.Value;
                            User user = db.Users.Where(u => u.UserId == fieldId).FirstOrDefault();
                            if (user != null)
                            {
                                db.Users.Remove(user);
                                db.SaveChanges();
                            }
                        }
                    }
                    break;
                case "country_List":
                    foreach (dynamic field in row)
                    {
                        if (To_Upper(field.Name) == "CountryId")
                        {
                            int fieldId = field.Value;
                            Country countr = db.Countrys.Where(c => c.CountryId == fieldId).FirstOrDefault();
                            if (countr != null)
                            {
                                db.Countrys.Remove(countr);
                                db.SaveChanges();
                            }
                        }
                    }
                    break;
                case "city_List":
                    foreach (dynamic field in row)
                    {
                        if (To_Upper(field.Name) == "CityId")
                        {
                            int fieldId = field.Value;
                            City city = db.Citys.Where(c => c.CityId == fieldId).FirstOrDefault();
                            if (city != null)
                            {
                                db.Citys.Remove(city);
                                db.SaveChanges();
                            }
                        }
                    }
                    break;
                case "rate_List":
                    foreach (dynamic field in row)
                    {
                        if (To_Upper(field.Name) == "RateId")
                        {
                            int fieldId = field.Value;
                            Rate rate = db.Rates.Where(r => r.RateId == fieldId).FirstOrDefault();
                            if (rate != null)
                            {
                                db.Rates.Remove(rate);
                                db.SaveChanges();
                            }
                        }
                    }
                    break;
                case "status_List":
                    foreach (dynamic field in row)
                    {
                        if (To_Upper(field.Name) == "StatusId")
                        {
                            int fieldId = field.Value;
                            Status stat = db.Statuses.Where(s => s.StatusId == fieldId).FirstOrDefault();
                            if (stat != null)
                            {
                                db.Statuses.Remove(stat);
                                db.SaveChanges();
                            }
                        }
                    }
                    break;
            }
        }

        private void SavetoDb(string table, string action, dynamic collect) {
            foreach (var row in collect)
            {
                switch (action)
                {
                    case "added":
                        AddDb(table, row);
                        break;
                    case "updated":
                        UpdatedDb(table, row);
                        break;
                    case "deleted":
                        DelDb(table, row);
                        break;
                }

            }

        }

        [Route("[action]"), HttpPost]
        public JsonResult GetUsersList()
        {
            dynamic listdata = db.Users.ToList();
            return Json(listdata);
        }

        [Route("[action]"), HttpPost]
        public JsonResult GetMainData()
        {
            dynamic countrylist = db.Countrys.ToList();
            dynamic citylist = db.Citys.ToList();
            dynamic ratelist = db.Rates.ToList();
            dynamic statuslist = db.Statuses.ToList();
            dynamic requestlist = db.Requests.ToList();
            return Json(new { Country_List = countrylist,
                              City_List = citylist,
                              Rate_List = ratelist,
                              Status_List = statuslist,
                              Requests = requestlist
            });
        }

        //SaveDict => {"table":"User_List","data":{"added":[{"userId":6,"last_name":"","first_name":"","patronymic_name":"","sam_name":"","password":"","telephone_number":"","position":""}],"updated":[{"id":6,"updated":{"last_name":"wedwed","first_name":"wdewed","patronymic_name":"wedwed","sam_name":"4","password":"4","telephone_number":"3434344","position":"ferferferferferferferf"}}],"deleted":[]}}
        // {"table":"User_List","data":{"added":[],"updated":[{"id":1,"updated":{"password":"2"}}],"deleted":[]}}
        [Route("[action]"), HttpPost]
        public JsonResult SaveDict()
        {
            string param_str = "";
            string error_text = "";
            string Table = "";
            int is_error = 0;
            Dictionary<string, dynamic> Params = new Dictionary<string, dynamic>();

            if (Request.Body != null)
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    param_str = reader.ReadToEnd();
                }
            }
            var dict = JsonConvert.DeserializeAnonymousType(param_str, new Dictionary<string, object>());

            foreach (KeyValuePair<string, object> kp in dict)
            {
                if (kp.Key == "table")
                {
                    Table = kp.Value.ToString();
                }
                else if (kp.Key == "data" && Params.Count() == 0)
                {
                    Params = Params.Concat(JObject.Parse(kp.Value.ToString()).ToObject<Dictionary<string, dynamic>>()).ToDictionary(x => x.Key, x => x.Value);
                }
            }
            foreach (KeyValuePair<string, dynamic> kp in Params)
            {
                if (kp.Value.Count > 0)
                {
                    SavetoDb(Table, kp.Key, kp.Value);
                }
            }

            //  if (Table == "User_List") {
            //
            //  }

            if (!(string.IsNullOrEmpty(error_text)))
            {
                is_error = 1;
                return Json(new { is_error, error_text});
            }
            if (Table == "User_List")
            {
                return Json(db.Users.ToList());
            }
            else
            {
                dynamic countrylist = db.Countrys.ToList();
                dynamic citylist = db.Citys.ToList();
                dynamic ratelist = db.Rates.ToList();
                dynamic statuslist = db.Statuses.ToList();
                dynamic requestlist = db.Requests.ToList();
                return Json(new
                {
                    Country_List = countrylist,
                    City_List = citylist,
                    Rate_List = ratelist,
                    Status_List = statuslist,
                    Requests = requestlist
                });
            }


        }
        [Route("[action]"), HttpPost]
        public JsonResult SaveReq()
        {
            try
            {
                dynamic countrylist = db.Countrys.ToList();
                dynamic citylist = db.Citys.ToList();
                dynamic ratelist = db.Rates.ToList();
                dynamic statuslist = db.Statuses.ToList();
                AllParams reqData = GetParamFromReq<AllParams>(Request.Body);
                switch (reqData.action) {
                    case "Insert":
                          Request req = new Request();
                          req.user = reqData.user;
                          if (!String.IsNullOrEmpty(reqData.country)){
                            string country_name = db.Countrys.Where(c => c.CountryId == Int32.Parse(reqData.country)).FirstOrDefault().Country_name;
                            req.country = country_name;
                          }
                          if (!String.IsNullOrEmpty(reqData.country))
                          {
                            string city_name = db.Citys.Where(c => c.CityId == Int32.Parse(reqData.city)).FirstOrDefault().City_name;
                            req.city = city_name;
                          }
                          req.date_begin = DateTime.ParseExact(reqData.date_begin, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                          req.date_end = DateTime.ParseExact(reqData.date_end, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                          req.summaAll = reqData.summaAll;
                          req.valutaAll = reqData.valutaAll;
                          req.daily = reqData.daily;
                          req.mobile = reqData.mobile;
                          req.hospitality = reqData.hospitality;
                          req.transport = reqData.transport;
                          req.residence = reqData.residence;
                          req.unexpected = reqData.unexpected;
                          db.Requests.Add(req);
                          db.SaveChanges();
                        break;
                    case "Update":
                        Request req2 = db.Requests.Where(r => r.RequestId == reqData.requestId).FirstOrDefault();
                        if (req2 != null) {
                            req2.summaAll = reqData.summaAll;
                            req2.valutaAll = reqData.valutaAll;
                            req2.daily = reqData.daily;
                            req2.mobile = reqData.mobile;
                            req2.hospitality = reqData.hospitality;
                            req2.transport = reqData.transport;
                            req2.residence = reqData.residence;
                            req2.unexpected = reqData.unexpected;
                            db.SaveChanges();
                        }
                        break;

                }
                dynamic requestlist = db.Requests.ToList();
                return Json(new
                {
                    Country_List = countrylist,
                    City_List = citylist,
                    Rate_List = ratelist,
                    Status_List = statuslist,
                    Requests = requestlist
                });
            }
            catch (Exception ex)
            {
                return Json(new { is_error = 1, error_text = ex.Message});
            }

        }
        [Route("[action]"), HttpPost]
        public JsonResult EmailDict()
        {
            string param_str = "";
            string error_text = "";
            string EmailAddress = "";
            string FIO = "";
            int is_error = 0;
            Dictionary<string, dynamic> Params = new Dictionary<string, dynamic>();

            if (Request.Body != null)
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    param_str = reader.ReadToEnd();
                }
            }
            var dict = JsonConvert.DeserializeAnonymousType(param_str, new Dictionary<string, object>());

            foreach (KeyValuePair<string, object> kp in dict)
            {
                if (kp.Key == "email")
                {
                    EmailAddress = kp.Value.ToString();
                }
                else if (kp.Key == "user")
                {
                    FIO = kp.Value.ToString();
                }
            }
            

            EmailService emailService = new EmailService();
            emailService.SendEmail(EmailAddress, "Заявка на відрядження узгоджена", "<div><b>Шановний " + FIO + "! </b></div> <div>Ваша заявка за відрядження узгоджена.</div>");

            if (!(string.IsNullOrEmpty(error_text)))
            {
                is_error = 1;
                return Json(new { is_error, error_text });
            }
            
                return Json(db.Users.ToList());
            
            }


        }

    }

