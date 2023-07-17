using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Application.Context
{
    public class CalculadoraContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=PE07ZKZB\SQLEXPRESS;Database=calculadora_frwk;Trusted_Connection=True;TrustServerCertificate=true");
        }
        
        public DbSet<Operacoes> Operacoes { get; set; }
    }
}
