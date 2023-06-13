
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
    public interface ILoginService
	{ 
        Task<List<LoginModel>> GetAllUsers();
		Task<int> AddUser(LoginModel user);
        Task<int> UpdateUser(LoginModel user);
        Task<int> DeleteUser(LoginModel user);

    }
}
