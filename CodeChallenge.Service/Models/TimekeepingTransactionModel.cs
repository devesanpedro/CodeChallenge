using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Service.Models
{
    public class TimekeepingTransactionModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }
        public DateTime TransactionDateTime { get; set; }
    }
}
