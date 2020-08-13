using HungryPizza_Domain.Entities.Pedido;
using HungryPizza_Domain.Entities.Pizza;
using Microsoft.EntityFrameworkCore;

namespace HungryPizza_Repository.Context
{
    public class Context : DbContext
    {
        #region <<< Constructor >>>
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        #endregion

        #region <<< DB SET >>
        public DbSet<PedidoEntity> Pedido { get; set; }
        public DbSet<PizzaEntity> Pizza { get; set; }
        public DbSet<SaborEntity> Sabor { get; set; }
        public DbSet<PedidoPizzaSaborEntity> PedidoPizzaSabor { get; set; }
        #endregion

        #region <<< Methods >>>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        #endregion
    }
}
