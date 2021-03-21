using System;
using System.Collections.Generic;
using System.Text;
using static CodeChallenge.Persistence.Enums;

namespace CodeChallenge.Persistence.Entities
{
    public class Employee : EntityBase<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateHired { get; set; }
    }
}
