namespace GestaoJogos.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; //* "" != null
        public string Desenvolvedora { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int AnoLancamento { get; set; }
        public decimal Preco { get; set; }  
    }
}