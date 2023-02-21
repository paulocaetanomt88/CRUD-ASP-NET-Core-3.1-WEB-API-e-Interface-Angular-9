using Microsoft.EntityFrameworkCore;

namespace Api_cartao.Models
{
    /*
     * O arquivo AppDbContext representa o nosso arquivo de contexto que vai herdar de DbContext
     * e permitir a comunicação entre o EF Core o banco de dados.
     * A classe AppDbContext decide o que deve ser adicionado ao banco de dados físico durante a migração do banco de dados. 
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        // Adicionamos a propriedade DbSet à classe Pagamento, assim, após a migração,
        // a tabela Pagamentos e a base de dados serão criados no SQL Server.
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}