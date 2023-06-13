using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
	public interface IAppService
	{
		public Task<string> AuthenticateUser(LoginModel login);
		Task<(bool IsSuccess, string ErrorMessage)> RegisterUser(RegistrationModel registration);

    }
}
