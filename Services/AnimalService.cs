using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class AnimalService : IAnimalPerroService
    {
        public string GetAnimalPerroService()
        {
            return "Soy un perro!";
        }
    }

    public interface IAnimalPerroService
    {
        string GetAnimalPerroService();
    }
}