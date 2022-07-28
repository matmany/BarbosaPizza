using AutoMapper;

namespace BarbosaPizza.Models;

public class Pizza
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Sabor { get; set;}
    public bool IsGlutenFree { get; set; }
}

public class PizzaDto
{
    public string Nome { get; set; } = null!;
    public string? Sabor { get; set;}
    public bool IsGlutenFree { get; set; }
}

public class PizzaDtoProfile : Profile
{
    public PizzaDtoProfile()
    {
        CreateMap<Pizza, PizzaDto>();
        CreateMap<PizzaDto, Pizza>();
    }
}

