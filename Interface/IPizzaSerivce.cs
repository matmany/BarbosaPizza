using BarbosaPizza.Models;

namespace BarbosaPizza.Interface
{
    public interface IPizzaService 
    {
        List<Pizza> GetAll();
        Pizza? GetById(int id);
        void Add(PizzaDto pizza);
        PizzaDto Update(PizzaDto pizza, int id);
        void Delete(int name);
    }
}