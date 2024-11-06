using System.ComponentModel.DataAnnotations;

namespace ApiTarefasNet80.DTOs
{
    public class CategoriaDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
    }
}
