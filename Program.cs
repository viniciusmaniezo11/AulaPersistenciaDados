//* Fluxo de funcionamento:
//* Program => Services => Repositories => Model + Dados (DB)

using GestaoJogos.Models;
using GestaoJogos.Repositories;
using GestaoJogos.Services;

var repository = new JogoRepository(); //* Faz a comunicação com as camadas
var service = new JogoService(repository); 

bool executando = true;

while (executando)
{
    Console.Clear();
    Console.WriteLine("======= GESTÃO DE JOGOS ======= ");
    Console.WriteLine("1 - CADASTRAR JOGO");
    Console.WriteLine("2 - LISTAR JOGOS");
    Console.WriteLine("0 - SAIR");
    Console.WriteLine("\nEscolha uma opção");

    string? opcao = Console.ReadLine();

    try //* Tudo que estiver no try ele tenta fazer.
    {
        switch (opcao)
        {
            // case "1"
            // Cadastrar();
            // break;

            case "2":
            Listar();
            break;
            

            case "0":
             executando = false;
            break; 
             
            default:
             Console.WriteLine("Opção invalida");
             Pausar();
            break;
        }
    }
    catch (ArgumentException ex) //* Caso surja um erro ele vai para o catch.
    {
        Console.WriteLine($"\nErro: {ex.Message}");
        throw;
    }
}

void Listar()
{
    Console.Clear();
    Console.WriteLine("======= JOGOS CADASTRADOS =======");

    var jogos = service.Listar();

    if (jogos.Count == 0)
    {
        Console.WriteLine("Nenhum jogo cadastrado");
    }
    else
    {
        foreach (var jogo in jogos)
        {
            ExibirJogo(jogo);
        }

    }
    
    Pausar();
}

void ExibirJogo(Jogo jogo)
{
    Console.WriteLine($"""
    -----------------------
    ID: {jogo.Id}
    Nome: {jogo.Nome}
    Desenvolvedora: {jogo.Genero}
    Ano de lançamento: {jogo.AnoLancamento}
    Preço: {jogo.Preco}
    """);
}

void Pausar()
{
    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
}