using BikeFit.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeFit.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<AtletaDadosPessoaisModel> DadosPessoais{ get; set; }

        public DbSet<AtletaMedidasAntropometricasModel> MedidasAntropometricas{ get; set; }
    }
}
