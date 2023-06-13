using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
    public class AppService : IAppService
    {
        private string _baseUrl = "https://localhost:7215";
        public async Task<string> AuthenticateUser(LoginModel login)
        {
            string returnStr=string.Empty;
            using(var client=new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.AuthenticateUser}";
                var serializedStr=JsonConvert.SerializeObject(login) ;

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    returnStr = await response.Content.ReadAsStringAsync();
                }
            }
            return returnStr;
        }
        public async Task<(bool IsSuccess,string ErrorMessage)> RegisterUser(RegistrationModel registration)
        {
            string errorMessage = string.Empty;
            bool isSuccess=false;
            using (var client = new HttpClient())
            {
                var url = $"{_baseUrl}{APIs.AuthenticateRegister}";
                var serializedStr = JsonConvert.SerializeObject(registration);

                var response = await client.PostAsync(url, new StringContent(serializedStr, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    isSuccess = true;
                }
                else
                {
                    errorMessage = await response.Content.ReadAsStringAsync();
                }
            }
            return (isSuccess, errorMessage);
        }
    }
}
