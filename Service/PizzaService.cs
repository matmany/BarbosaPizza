using AutoMapper;

using BarbosaPizza.Models;
using BarbosaPizza.Interface;

namespace BarbosaPizza.Service
{
    public class PizzaService: IPizzaService
    {
        
        static List<Pizza> Pizzas {get; set;} = new List<Pizza>
            {
                new Pizza { Id = 0, Nome = "Especial Barbosa", Sabor = "Calabresa", IsGlutenFree = true },
                new Pizza { Id = 1, Nome = "Barbosa raiz", Sabor = "portuguesa", IsGlutenFree = false },
            };
        private int index = 2;
        private readonly IMapper mapper;

        public PizzaService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<Pizza> GetAll()
        {
            return Pizzas;
        }

        public Pizza? GetById(int id)
        {
            return Pizzas.Find(p => p.Id == id);
        }

        public void Add(PizzaDto pizza)
        {
            var newPizza = mapper.Map<Pizza>(pizza);
            newPizza.Id = index++;
            Pizzas.Add(newPizza);
        }

        public PizzaDto? Update(PizzaDto pizza, int id)
        {
            var index = Pizzas.FindIndex(p=> p.Id == id);
            
            if(index == -1)
                return null;

            var updatedPizza = mapper.Map<Pizza>(pizza);
            updatedPizza.Id = id;
            Pizzas[index] = updatedPizza;

            return pizza;
        }

        public void Delete(int id)
        {
            var pizza = GetById(id);
            if(pizza == null)
                return;
            Pizzas.Remove(pizza);
        }
    }   
}