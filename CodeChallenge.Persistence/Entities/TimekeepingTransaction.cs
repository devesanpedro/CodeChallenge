using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Persistence.Entities
{
    public class TimekeepingTransaction : EntityBase<int>
    {
        public int EmployeeId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
