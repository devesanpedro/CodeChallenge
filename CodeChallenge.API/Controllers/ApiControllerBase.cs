using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.API.Controllers
{
    [EnableCors("AllowOrigin")]
    public class ApiControllerBase<T> : ControllerBase where T : ApiControllerBase<T>
    {
    }
}
