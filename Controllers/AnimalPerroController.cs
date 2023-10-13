using ApiRest.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace ApiRest.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class AnimalPerroController : ControllerBase
{
    IAnimalPerroService animalPerroService;

    public AnimalPerroController(IAnimalPerroService animalPerro)
    {
        animalPerroService = animalPerro;
    }
[HttpGet]
    public IActionResult Get()
    {
        return Ok(animalPerroService.GetAnimalPerroService());
    }

}
}