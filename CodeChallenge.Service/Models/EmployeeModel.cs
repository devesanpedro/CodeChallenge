using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static CodeChallenge.Persistence.Enums;

namespace CodeChallenge.Service.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTime DateHired { get; set; } = DateTime.Now;
    }
}
