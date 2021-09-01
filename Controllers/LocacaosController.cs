using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APILocadoraCRUD.Data;
using APILocadoraCRUD.Models;

namespace APILocadoraCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaosController : ControllerBase
    {
        private readonly APILocadoraCRUDContext _context;

        public LocacaosController(APILocadoraCRUDContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locacao>>> GetLocacaosAsync()
        {
            return await _context.Locacaos.ToListAsync();
        }

        //GET por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Locacao>> GetLocacaoAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = await _context.Locacaos.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            return locacao;
        }

        //PUT por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacaoAsync(int id, Locacao locacao)
        {
            if (id != locacao.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(locacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteLocacao(id))
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

        // POST
        [HttpPost]
        public async Task<ActionResult<Locacao>> PostLocacao(Locacao locacao)
        {
            _context.Locacaos.Add(locacao);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExisteLocacao(locacao.IdCliente))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLocacaosAsync", new { id = locacao.IdCliente }, locacao);
        }

        //DELETE por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacao(int id)
        {
            var locacao = await _context.Locacaos.FindAsync(id);

            if (locacao == null)
            {
                return NotFound();
            }

            _context.Locacaos.Remove(locacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Verifica se ainda existe locação
        private bool ExisteLocacao(int id)
        {
            return _context.Locacaos.Any(e => e.IdCliente == id);
        }
    }
}
