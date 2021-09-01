using APILocadoraCRUD.Data;
using APILocadoraCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILocadoraCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly APILocadoraCRUDContext _context;

        public ClientesController(APILocadoraCRUDContext context)
        {
            _context = context;
        }

        //GET Chamar todos os dados da tabela
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        //GET ID - Chamar o dado pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        //PUT - Alterar o dado pelo ID
        [HttpPut("{id}")]
        public async Task<ActionResult> PutClienteAsync(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExiste(id))
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

        //POST - Incluir dado na tabela
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClienteAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientesAsync", new {id = cliente.IdCliente }, cliente);
        }

        //DELETE - Deletar o dado pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Verifica se ainda existe o cliente
        private bool ClienteExiste(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
