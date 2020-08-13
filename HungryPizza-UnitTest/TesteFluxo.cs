using AutoMapper;
using HungryPizza_AppServices.Pedido;
using HungryPizza_Domain.Dto.Pedido;
using HungryPizza_Domain.Dto.Pizza;
using HungryPizza_Domain.Entities.Pedido;
using HungryPizza_Domain.Entities.Pizza;
using HungryPizza_Domain.InterfaceRepository.Pedido;
using HungryPizza_Domain.Result;
using HungryPizza_Repository.Context;
using HungryPizza_Repository.Pedido;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizza_UnitTest
{
    public class Tests
    {        
        [Test]
        public void InsertDuasPizzasComDoisSabores_Acertivo()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();

            var pedido = new RequestPedidoDto();
            pedido.Pizzas = new List<PizzaDto>();
            var pizza = new PizzaDto();
            pizza.Sabores = new List<SaborDto>();
            var pizza0 = new PizzaDto();
            pizza0.Sabores = new List<SaborDto>();

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                Sabor = "3 Queijos",
                Valor = 50.00M
            });

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                Sabor = "Portuguesa",
                Valor = 45.00M
            });

            pizza0.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("6441F3F6-E413-4147-8ADC-D23EED5F55A4"),
                Sabor = "Mussarela",
                Valor = 42.50M
            });

            pizza0.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                Sabor = "Portuguesa",
                Valor = 45.00M
            });

            pedido.Pizzas.Add(pizza);
            pedido.Pizzas.Add(pizza0);
            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void InsertUmaPizzaComUmSabor_Acertivo()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();
            var pedido = new RequestPedidoDto();
            pedido.Pizzas = new List<PizzaDto>();
            var pizza = new PizzaDto();
            pizza.Sabores = new List<SaborDto>();
            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                Sabor = "3 Queijos",
                Valor = 50.00M
            });

            pedido.Pizzas.Add(pizza);

            var tresult = new TResult();
            tresult.Success = true;
            tresult.Object = pedido;

            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void InsertDuasPizzasComUmEComDoisSabore_Acertivo()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();

            var pedido = new RequestPedidoDto();
            pedido.Pizzas = new List<PizzaDto>();
            var pizza = new PizzaDto();
            var pizza0 = new PizzaDto();
            pizza.Sabores = new List<SaborDto>();
            pizza0.Sabores = new List<SaborDto>();

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                Sabor = "3 Queijos",
                Valor = 50.00M
            });

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                Sabor = "Portuguesa",
                Valor = 45.00M
            });

            pizza0.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("6441F3F6-E413-4147-8ADC-D23EED5F55A4"),
                Sabor = "Mussarela",
                Valor = 42.50M
            });

            pedido.Pizzas.Add(pizza);
            pedido.Pizzas.Add(pizza0);

            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void ValidarValorPedido_Acertivo()
        {
            var pedido = new PedidoEntity();
            var pizza = new PizzaEntity();
            pedido.Pizzas = new List<PizzaEntity>();

            pizza.Sabores.Add(new SaborEntity()
            {
                Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                Sabor = "3 Queijos",
                Valor = 50.00M
            });

            pizza.Sabores.Add(new SaborEntity()
            {
                Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                Sabor = "Portuguesa",
                Valor = 45.00M
            });

            pedido.Pizzas.Add(pizza);

            pedido.Pizzas.ForEach(x => {
                x.CalcularValorTotal();
            });

            pedido.CalcularValorTotal();

            Assert.AreEqual(47.50M, pedido.ValorTotal);
        }

        [Test]
        public void HistoricoPedido_Acertivo()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();
            var options = new DbContextOptionsBuilder<Context>()
                .UseSqlServer("Server=DESKTOP-RPIAK1N; Database=HungryPizza; Trusted_Connection=True; MultipleActiveResultSets=true")
                .Options;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>().ReverseMap();
                cfg.CreateMap<SaborDto, SaborEntity>().ReverseMap();
            });
            var mapper = config.CreateMapper();

            var pedido = new ResponsePedidoDto();

            mock.Setup(x => x.SelecionarPedido(It.IsAny<Guid>())).Returns(Task.FromResult(pedido));
            var repository = new PedidoRepository(new Context(options), mapper);
            var response = repository.SelecionarPedido(Guid.Parse("2FA4CF6F-65C8-4004-9CB9-780AE6B79115")).Result;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Pizzas.FirstOrDefault());
            Assert.IsNotNull(response.Pizzas.LastOrDefault());
            Assert.That(response.Pizzas, Has.Exactly(2).Items);
            Assert.That(response.Pizzas.FirstOrDefault().Sabores, Has.Exactly(2).Items);
            Assert.That(response.Pizzas.LastOrDefault().Sabores, Has.Exactly(2).Items);
        }

        [Test]
        public void InsertPedidoSemPizza_Erro()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();

            var pedido = new RequestPedidoDto();

            var tresult = new TResult();
            tresult.Success = false;
            tresult.Object = pedido;

            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;


            Assert.AreEqual(1, result.Errors.Count);
        }

        [Test]
        public void InsertUmaPizzaComTresSabores_Erro()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();

            var pedido = new RequestPedidoDto();
            pedido.Pizzas = new List<PizzaDto>();
            var pizza = new PizzaDto();
            pizza.Sabores = new List<SaborDto>();

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                Sabor = "3 Queijos",
                Valor = 50.00M
            });

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                Sabor = "Portuguesa",
                Valor = 45.00M
            });

            pizza.Sabores.Add(new SaborDto()
            {
                Id = Guid.Parse("6441F3F6-E413-4147-8ADC-D23EED5F55A4"),
                Sabor = "Mussarela",
                Valor = 42.50M
            });

            pedido.Pizzas.Add(pizza);

            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;

            Assert.AreEqual(1, result.Errors.Count);
        }

        [Test]
        public void InsertMaisDeDezPizzas_Erro()
        {
            Mock<IPedidoRepository> mock = new Mock<IPedidoRepository>();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RequestPedidoDto, PedidoEntity>();
                cfg.CreateMap<PizzaDto, PizzaEntity>();
                cfg.CreateMap<SaborDto, SaborEntity>();
            });

            var mapper = config.CreateMapper();

            var pedido = new RequestPedidoDto();
            pedido.Pizzas = new List<PizzaDto>();
            for (int i = 0; i < 11; i++)
            {
                var pizza = new PizzaDto();
                pizza.Sabores = new List<SaborDto>();
                pizza.Sabores.Add(new SaborDto()
                {
                    Id = Guid.Parse("0ACCED84-4AC5-4BBF-9848-1C5A5FA788F7"),
                    Sabor = "3 Queijos",
                    Valor = 50.00M
                });

                pizza.Sabores.Add(new SaborDto()
                {
                    Id = Guid.Parse("7F1CD03A-D9B8-461D-A9A5-6746B60C454E"),
                    Sabor = "Portuguesa",
                    Valor = 45.00M
                });
                pedido.Pizzas.Add(pizza);
            }
            
            mock.Setup(x => x.InserirPedido(It.IsAny<PedidoEntity>())).Returns(Task.FromResult(mapper.Map<PedidoEntity>(pedido)));
            var service = new PedidoAppServices(mock.Object, mapper);

            var result = service.InserirPedido(pedido).Result;

            Assert.AreEqual(1, result.Errors.Count);
        }
    }
}