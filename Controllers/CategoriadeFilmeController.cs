using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using locadora.Models;
using System.Linq;

namespace Prova.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriadeFilmeController : ControllerBase
    {
        //injeção de dependecia
        private readonly DataContext _context;
        public CategoriadeFilmeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Categorias.ToList());

        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] CategoriadeFilme categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created("", categoria);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int Id)
        {

            foreach (CategoriadeFilme categoria in _context.Categorias.ToList())
            {
                if (categoria.Id == Id)
                {
                    return Ok(categoria);
                }
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            foreach (var categoria in _context.Categorias.ToList())
            {
                if (categoria.Id == id)
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                    return Ok(categoria);
                }

            }

            return NotFound();
        }

        [HttpPatch]
        [Route("editar")]
        public IActionResult Editar([FromBody] CategoriadeFilme categoria)
        {
            foreach (var categoria_cadastrada in _context.Categorias.ToList())
            {
                if (categoria_cadastrada.Id == categoria.Id)
                {
                    categoria_cadastrada.Nome = categoria.Nome;
                    categoria_cadastrada.Descricao = categoria.Descricao;
                    _context.Categorias.Update(categoria_cadastrada);
                    _context.SaveChanges();
                    return Ok(categoria_cadastrada);
                }

            }

            return NotFound();
        }

    }

}