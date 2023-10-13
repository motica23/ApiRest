using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;

        Context _context;
        public HelloWorldController(IHelloWorldService helloWorld, Context context)
        {
            helloWorldService = helloWorld;
            _context = context;
        }
[HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDataBase()
        {
            _context.Database.EnsureCreated();

            return Ok();
        }
    }
}