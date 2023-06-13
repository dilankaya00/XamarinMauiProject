using Newtonsoft.Json;
using SQLite;
using System.Net.Http.Headers;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
	public class LoginService : ILoginService
	{

		private SQLiteAsyncConnection _dbConnection;
		public LoginService()
		{
			SetUpDb();
		}
		private async void SetUpDb()
		{

			if (_dbConnection == null)
			{
				string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3");
				_dbConnection = new SQLiteAsyncConnection(dbPath);
				await _dbConnection.CreateTableAsync<LoginModel>();
			}
		}
		public async Task<int> AddUser(LoginModel user)
		{
			return await _dbConnection.InsertAsync(user);

			//using var client = new HttpClient();
			//var myContent = JsonConvert.SerializeObject(user);
			//var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
			//var byteContent = new ByteArrayContent(buffer);
			//byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			//var response = await client.PostAsync("https://localhost:7215/api/Auth/Login", byteContent);

			//if (response.IsSuccessStatusCode)
			//{
			//	return await response.Content.ReadAsStringAsync();
			//}
			//else
			//{
			//	return await response.Content.ReadAsStringAsync();
			//}
		}
		public async Task<int> DeleteUser(LoginModel user)
		{
			return await _dbConnection.DeleteAsync(user);
		}

		public async Task<List<LoginModel>> GetAllUsers()
		{
			return await _dbConnection.Table<LoginModel>().ToListAsync();
		}

		public async Task<int> UpdateUser(LoginModel user)
		{
			return await _dbConnection.UpdateAsync(user);
		}


	}
}
