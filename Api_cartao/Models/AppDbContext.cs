using Microsoft.EntityFrameworkCore;

namespace Api_cartao.Models
{
    /*
     * O arquivo AppDbContext representa o nosso arquivo de contexto que vai herdar de DbContext
     * e permitir a comunica��o entre o EF Core o banco de dados.
     * A classe AppDbContext decide o que deve ser adicionado ao banco de dados f�sico durante a migra��o do banco de dados. 
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        { }

        // Adicionamos a propriedade DbSet � classe Pagamento, assim, ap�s a migra��o,
        // a tabela Pagamentos e a base de dados ser�o criados no SQL Server.
        public DbSet<Pagamento> Pagamentos { get; set; }
    }
}