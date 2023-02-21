using Api_cartao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_cartao.Controllers
{
    [Route("api/[controller]")]
    // seguindo as práticas para as API REST e estamos forçando a nossa API a retornar JSON.
    // Assim não precisamos alterar os métodos HTTP gerados
    // e podemos inclusive testar as operações CRUD usando um software como o Postman.
    [Produces("application/json")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Aqui estamos injetando uma instância do nosso contexto AppDbContext no construtor
        // para poder realizar as operações com as entidades e persistir no banco de dados via EF Core.
        public PagamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            return await _context.Pagamentos.ToListAsync();
        }

        // GET: api/Pagamentos/[id]
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        // PUT: api/Pagamentos/[id]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.PagamentoId)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pagamentos
        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamento", new { id = pagamento.PagamentoId }, pagamento);
        }

        // DELETE: api/pagamentos/[id]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pagamento>> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();

            return pagamento;
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.PagamentoId == id);
        }
    }
}