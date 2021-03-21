using CodeChallenge.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CodeChallenge.Web.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel> Add(EmployeeModel model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/employee", model).Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> Delete(int EmployeeId)
        {
            var result = await _httpClient.DeleteAsync($"api/employee/{EmployeeId}").Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> Edit(EmployeeModel model)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/employee", model).Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> GetAll()
        {
            var result = await _httpClient.GetAsync($"/api/employee").Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> GetById(int EmployeeId)
        {
            var result = await _httpClient.GetAsync($"/api/employee/{EmployeeId}").Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }
    }
}
