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
    public class FilmesController : ControllerBase
    {
        private readonly APILocadoraCRUDContext _context;

        public FilmesController(APILocadoraCRUDContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> GetFilmesAsync()
        {
            return await _context.Filmes.ToListAsync();
        }

        //GET por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilmeAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes.FindAsync(id);

            if (filme == null)
            {
                return NotFound();
            }

            return filme;
        }

        

        //PUT por ID
        [HttpPut("{id}")]
        public async Task<ActionResult> PutFilmeAsync(int id, Filme filme)
        {
            if (id != filme.IdFilme)
            {
                return BadRequest();
            }

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExiste(id))
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
        public async Task<ActionResult<Filme>> PostFilmeAsync(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmesAsync", new { id = filme.IdFilme }, filme);
        }

        //DELETE por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmeAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = _context.Filmes.FirstOrDefault(e => e.IdFilme == id);

            if (filme == null)
            {
                return NotFound();
            }

            _context.Remove(filme);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        ////DELETE uma lista de filmes por ID
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFilmesAsync(int[] listIdDelete)
        //{
        //    foreach (int idFilme in listIdDelete)
        //    {
        //        var filme = _context.Filmes.FirstOrDefault(e => e.IdFilme == idFilme);
        //        _context.Remove(filme);
        //        await _context.SaveChangesAsync();
        //    }

        //    return NoContent();

        //}

        //Verificar se ainda existe o filme
        private bool FilmeExiste(int id)
        {
            return _context.Filmes.Any(e => e.IdFilme == id);
        }
    }
}
