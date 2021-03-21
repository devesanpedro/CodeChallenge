using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Persistence.Entities
{
    public class TransactionType : EntityBase<int>
    {
        public string Name { get; set; }
    }
}
