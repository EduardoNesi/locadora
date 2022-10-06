using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using locadora.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace locadora.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public FilmesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Filmes.Include(j => j.CategoriadeFilme).ToList());

        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Filmes filmes)
        {
            _context.Filmes.Add(filmes);
            _context.SaveChanges();
            return Created("", filmes);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int Id)
        {

            foreach (Filmes filmes in _context.Filmes.Include(f => f.CategoriadeFilme).ToList())
            {
                if (filmes.Id == Id)
                {
                    return Ok(filmes);
                }
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            foreach (var filmes in _context.Filmes.ToList())
            {
                if (filmes.Id == id)
                {
                    _context.Filmes.Remove(filmes);
                    _context.SaveChanges();
                    return Ok(filmes);
                }

            }

            return NotFound();
        }

        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] Filmes filmes)
        {
            foreach (var filme_cadastrado in _context.Filmes.ToList())
            {
                if (filme_cadastrado.Id == filmes.Id)
                {
                    filme_cadastrado.Nome = filmes.Nome;
                    filme_cadastrado.Produtora = filmes.Produtora;
                    filme_cadastrado.Preco = filmes.Preco;
                    filme_cadastrado.CategoriadeFilmeId = filmes.CategoriadeFilmeId;
                    _context.Filmes.Update(filme_cadastrado);
                    _context.SaveChanges();
                    return Ok(filme_cadastrado);
                }

            }

            return NotFound();
        }

    }

}