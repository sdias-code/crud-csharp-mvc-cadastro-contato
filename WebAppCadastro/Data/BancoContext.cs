using Microsoft.EntityFrameworkCore;
using WebAppCadastro.Models;

namespace WebAppCadastro.Data
{
    public class BancoContext: DbContext {        

        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }
        
    public DbSet<ContatoModel> Contatos { get; set; }
    }
}
