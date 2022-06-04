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

        public DbSet<AtletaDadosPessoais> DadosPessoais{ get; set; }
    }
}
