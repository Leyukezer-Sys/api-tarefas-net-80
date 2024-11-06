using ApiTarefasNet80.DTOs;
using ApiTarefasNet80.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefasNet80.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriaController : Controller
    {
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                List<Categoria> lista = new CategoriaDAO().List();

                return Ok(lista);
            }
            catch (Exception)
            {

                return Problem($"Ocorreram erros ao processar a Solução");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }
            catch (Exception)
            {

                return Problem("Ocorreram erros ao processar a solicitação");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaDTO item)
        {
            var categoria = new Categoria();

            categoria.Nome = item.Nome;

            try
            {
                var dao = new CategoriaDAO();
                categoria.Id = dao.Insert(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }

            return Created("", categoria);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoriaDTO item) 
        {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);

                if(categoria == null) return NotFound();

                categoria.Nome = item.Nome;

                new CategoriaDAO().Update(categoria);

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                var categoria = new CategoriaDAO().GetById(id);

                if (categoria == null) return NotFound();

                new CategoriaDAO().Delete(categoria.Id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
