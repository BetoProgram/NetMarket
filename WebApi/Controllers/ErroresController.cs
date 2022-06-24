using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Error;

namespace WebApi.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErroresController : BaseController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorMessage(code));
        }
    }
}
