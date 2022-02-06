using Newtonsoft.Json;
using SchoolMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SchoolMS_API.Providers
{
    public class TokenHelper
    {
        public static string GenerateToken(Cls_Contacts userData)
        {
            Dictionary<string, string> Token = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var login = new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "username", userData.Email },
                        { "password", userData.Password }
                    };
                    
                    var resp = client.PostAsync("http://localhost:15918/token", new FormUrlEncodedContent(login));
                    var JsonResult = resp.Result.Content.ReadAsStringAsync().Result;
                    if (resp.IsCompleted)
                    {
                        var result = resp.Result.Content.ReadAsStringAsync().Result;
                        if (result.Contains("access_token"))
                        {
                            Token = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return Token["access_token"];
        }
    }
}
