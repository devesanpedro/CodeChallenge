using CodeChallenge.Service.Models;
using CodeChallenge.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    public class EmployeeController : ApiControllerBase<EmployeeController>
    {
        protected IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpGet("{EmployeeId}")]
        public async Task<ActionResult> GetEmployeeById(int EmployeeId)
        {
            return Ok(await _employeeService.GetById(EmployeeId));
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(EmployeeModel model)
        {
            return Ok(await _employeeService.Add(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(EmployeeModel model)
        {
            return Ok(await _employeeService.Edit(model));
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<ActionResult> DeleteEmployee(int EmployeeId)
        {
            return Ok(await _employeeService.Delete(EmployeeId));
        }

    }
}
