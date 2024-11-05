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
    }
}
