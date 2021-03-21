using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Service.Models
{
    public class ResultModel
    {
        public bool IsSuccessful { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
