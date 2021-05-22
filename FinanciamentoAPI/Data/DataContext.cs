using FinanciamentoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanciamentoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Empresa> Empresa { get; set; }
    }
}
