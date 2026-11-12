using System.Text;
using GestaoJogos.Models;

namespace GestaoJogos.Repositories
{
    public class JogoRepository
    {
        //* Ao declarar um campo e ele for private é boa praticar iniciar com _ (Underscore)
        private readonly string _caminhoArquivo; //* Ao receber um valor ele não muda, sendo apenas para leitura

        public JogoRepository()
        {
            string pasta = Path.Combine(Environment.CurrentDirectory, "dados");
            //* Ele pega um caminho e combina o Environment.CurrentDirectory com "dados" que seria a pasta
            Directory.CreateDirectory(pasta); //* Cria o diretorio no caminho especificado

            _caminhoArquivo = Path.Combine(pasta, "jogos.csv");

            if (!File.Exists(_caminhoArquivo)) //* Checa se o arquivo NÃO existe
            {
                File.WriteAllText(
                    _caminhoArquivo, //* É o caminho aonde ele vai criar esse texto
                    "Id;Nome;Desenvolvedora;Genero;AnoLancamento;Preco" + Environment.NewLine, //* Depois da coluna Preco ele quebra a lina
                    Encoding.UTF8 //* É um método de codificação, salvando nesse padrão UTF8
                );
            }
        }

        public List<Jogo> Listar()
        {
            var jogos = new List<Jogo>(); //* var é uma variavel não definida, unica para métodos e não pode ser iniciada como null, ela le oque tem dentro e define automaticamente

            var linhas = File.ReadAllLines(_caminhoArquivo, Encoding.UTF8); //* Le todas as linhas do caminho especificado no encoding especificado

            foreach (var linha in linhas.Skip(1)) //* Skip -> Pula a primeira linha do arquivo, pois é um cabeçalho.
            {
                if (string.IsNullOrWhiteSpace(linha))  //* Verifica se tem espaços nulos ou em branco e os desconsidera.
                {
                    continue;
                }

                var campos = linha.Split(';'); //* Ele separa aonde achar o caractere indicado ";".

                if (campos.Length != 6 ) //* Se o numero de colunas for diferente de 6 (numero de dados que nós temos).
                {
                    continue;
                }

                jogos.Add(new Jogo
                {
                    Id = int.Parse(campos[0]),
                    Nome = campos[1],
                    Desenvolvedora = campos[2],
                    Genero = campos[3],
                    AnoLancamento = int.Parse(campos[4]),
                    Preco = decimal.Parse(campos[5])

                });
            }

            return jogos;
        }
    }
}