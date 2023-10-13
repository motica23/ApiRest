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
    public class CategoriaController : ControllerBase
    {
         private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok (_categoriaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria )
        {
            _categoriaService.Save(categoria);

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid Id, [FromBody] Categoria categoria)
        {
            _categoriaService.Update(Id,categoria);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            _categoriaService.Delete(Id);
            return Ok();
        }
    }
}