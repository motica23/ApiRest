using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Services;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;
namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
       private readonly ITareaService _tareaService;
        
        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tareaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Tarea tarea)
        {
            _tareaService.Save(tarea);
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id,[FromBody]Tarea tarea)
        {
            _tareaService.Update(Id,tarea);

            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            _tareaService.Delete(Id);
            return Ok();
        }
    }
}