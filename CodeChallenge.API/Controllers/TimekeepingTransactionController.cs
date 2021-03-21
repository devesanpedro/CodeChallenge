using CodeChallenge.Service.Models;
using CodeChallenge.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimekeepingTransactionController : ApiControllerBase<TimekeepingTransactionController>
    {
        protected ITimeKeepingTransactionService _timeKeepingTransactionService;

        public TimekeepingTransactionController(ITimeKeepingTransactionService timeKeepingTransactionService)
        {
            _timeKeepingTransactionService = timeKeepingTransactionService;
        }

        [HttpGet("{EmployeeId}")]
        public async Task<ActionResult> GetEmployeeById(int EmployeeId)
        {
            return Ok(await _timeKeepingTransactionService.GetAllByEmployeeId(EmployeeId));
        }

        [HttpGet]
        public async Task<ActionResult> GetByEmployeeIdTransactionDateTime(int EmployeeId, string TransactionDateTime)
        {
            var transactionDateTime = DateTime.Parse(TransactionDateTime);
            return Ok(await _timeKeepingTransactionService.GetByEmployeeIdTransactionDateTime(EmployeeId, transactionDateTime));
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(TimekeepingTransactionModel model)
        {
            return Ok(await _timeKeepingTransactionService.Add(model));
        }
    }
}
