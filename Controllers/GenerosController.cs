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
    public class GenerosController : ControllerBase
    {
        private readonly APILocadoraCRUDContext _context;

        public GenerosController(APILocadoraCRUDContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGenerosAsync()
        {
            return await _context.Generos.ToListAsync();
        }

        //GET por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGeneroAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FindAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        //PUT por ID
        [HttpPut("{id}")]
        public async Task<ActionResult> PutGeneroAsync(int id, Genero genero)
        {
            if (id != genero.IdGenero)
            {
                return BadRequest();
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneroExiste(id))
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

        //POST
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGeneroAsync(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenerosAsync", new { id = genero.IdGenero }, genero);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGeneroAsync(int id)
        {
            var genero = await _context.Generos.FindAsync(id);

            if (genero == null)
            {
                return NotFound();
            }

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Verifica se ainda existe o genero
        private bool GeneroExiste(int id)
        {
            return _context.Generos.Any(e => e.IdGenero == id);
        }

    }
}
