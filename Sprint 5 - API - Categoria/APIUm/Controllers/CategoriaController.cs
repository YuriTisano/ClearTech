using APIUm.Data;
using APIUm.Data.Dtos;
using APIUm.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIUm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaContext _context;
        private IMapper _mapper;

        public CategoriaController(CategoriaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {
            try
            {
                Categoria categoriaNome = _context.Categorias.FirstOrDefault(categoriaNome => categoriaNome.Nome.ToUpper() == categoriaDto.Nome.ToUpper());

                if (categoriaNome == null)
                {
                    Categoria categoria = _mapper.Map<Categoria>(categoriaDto);
                    _context.Categorias.Add(categoria);
                    _context.SaveChanges();
                    return CreatedAtAction(nameof(RecuperaCategoriaPorFiltro), new { id = categoria.Id }, categoria);
                }
                throw new ArgumentException();

            }
            catch (ArgumentException)
            {
                return BadRequest("Ops! Já existe uma CATEGORIA com este nome. Para que não ocorra problemas futuros, por favor, cadastre uma CATEGORIA com nome diferente.");
            }
        }

        [HttpGet]
        public IActionResult RecuperaCategoriaPorFiltro(string nome, string crescenteOuDecrescente, bool? status, string tipo, string datadeCriacao)
        {
            List<Categoria> list = null;

            if (nome != null && nome.Length < 3)
            {
                return NotFound("Para pesquisar uma categoria é necessário o mínimo de 3 letras digitadas");
            }
            if (nome != null && nome.Length >= 3)
            {
                list = _context.Categorias.Where(fitro => fitro.Nome.ToLower().Contains(nome.ToLower())).ToList();
            }
            else
            {
                list = _context.Categorias.ToList();
            }

            if (datadeCriacao != null)
            {
                list = _context.Categorias.Where(fitro => fitro.DatadeCriacao.ToLower().Contains(datadeCriacao.ToLower())).ToList();
            }

            if (status != null)
            {
                if (status != true && status != false)
                {
                    return NotFound("Para pesquisar por STATUS digite True ou False como parametros para pesquisa de status");
                }
                list = list.Where(fitro => fitro.Status == status).ToList();

            }

            if (tipo != null)
            {
                list = _context.Categorias.Where(c => c.Tipo.ToLower().Contains(tipo.ToLower())).ToList();
            }

            if (crescenteOuDecrescente != null)
            {
                if (crescenteOuDecrescente != "D" && crescenteOuDecrescente != "C")
                {
                    return NotFound("Digite D para ordem em DECRESCENTE ou C para ordem em CRESCENTE");
                }
                if (crescenteOuDecrescente.ToUpper() == "D")
                {
                    list = list.OrderByDescending(fitro => fitro.Nome).ToList();
                }
                else if (crescenteOuDecrescente.ToUpper() == "C")
                {
                    list = list.OrderBy(fitro => fitro.Nome).ToList();
                }
            }
            return Ok(list);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            _mapper.Map(categoriaDto, categoria);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
