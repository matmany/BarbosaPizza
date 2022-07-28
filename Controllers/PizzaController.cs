using Microsoft.AspNetCore.Mvc;
using BarbosaPizza.Models;
using BarbosaPizza.Interface;


namespace BarbosaPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        [HttpGet("pizzas")]
        public IEnumerable<Pizza> GetAll()
        {
            return pizzaService.GetAll();
        }

        [HttpGet("pizza/{id}")]
        public ActionResult<Pizza> GetById(int id) // ActionResult: Mapeira para codigo de status HTTP
        {
            var pizza = pizzaService.GetById(id);
            if(pizza == null)
            {
                return NotFound ();
            }
            return pizza;
        }

        [HttpPost("pizza")]
        public IActionResult Add(PizzaDto pizza) //Informa status da solicitação
        {
            pizzaService.Add(pizza);
            return CreatedAtAction(nameof(Add), new { name = pizza.Nome }, pizza);
        }

        [HttpDelete("pizza/{id}")]
        public void Delete(int id)
        {
            pizzaService.Delete(id);
        }

        [HttpPut("pizza/{id}")]
        public IActionResult Update(int id, PizzaDto pizza)
        {
            var updatedPizza = pizzaService.Update(pizza, id);
            if(updatedPizza == null)
            {
                return NotFound();
            }
            return Ok(updatedPizza);
        }

    }
}