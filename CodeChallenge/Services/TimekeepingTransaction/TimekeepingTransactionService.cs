using CodeChallenge.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CodeChallenge.Web.Services
{
    public class TimekeepingTransactionService : ITimekeepingTransactionService
    {
        private readonly HttpClient _httpClient;

        public TimekeepingTransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResultModel> Add(TimekeepingTransactionModel model)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/timekeepingtransaction", model).Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> GetAllByEmployeeId(int EmployeeId)
        {
            var result = await _httpClient.GetAsync($"/api/timekeepingtransaction/{EmployeeId}").Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }

        public async Task<ResultModel> GetByEmployeeIdTransactionDateTime(int EmployeeId, DateTime TransactionDateTime)
        {
            var result = await _httpClient.GetAsync($"/api/timekeepingtransaction/{EmployeeId}/{TransactionDateTime}").Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ResultModel>(result);
        }
    }
}
