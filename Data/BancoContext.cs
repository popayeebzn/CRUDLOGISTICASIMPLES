
using GABRIELPROJETOV1.Models;
using Microsoft.EntityFrameworkCore;


namespace GABRIELPROJETOV1.Data
{
    public class BancoContext : DbContext
    {

        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
        }

        public DbSet<FornecedoresModel> Fornecedores { get; set;}

        public DbSet<MateriaisModel> Materiais { get; set; } // Corrigir o nome da propriedade


    }
}
