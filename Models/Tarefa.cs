namespace ApiTarefasNet80.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public bool Feito { get; set; } = false;

        public DateTime Data { get; set; } = DateTime.Now;

        public DateTime? Data_feito { get; set; }

        public Categoria Categoria { get; set; }
    }
}
