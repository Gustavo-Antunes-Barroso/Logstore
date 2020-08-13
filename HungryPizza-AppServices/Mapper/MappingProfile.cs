using AutoMapper;
using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.Dto.Pizza;
using HungryPizza_Domain.Entities.Pedido;
using HungryPizza_Domain.Entities.Pizza;

namespace HungryPizza_AppServices.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<RequestPedidoDto, PedidoEntity>().ReverseMap();
            CreateMap<PizzaDto, PizzaEntity>().ReverseMap();
            CreateMap<SaborDto, SaborEntity>().ReverseMap();
        }
    }
}
