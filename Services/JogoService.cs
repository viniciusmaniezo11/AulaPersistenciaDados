using GestaoJogos.Models;
using GestaoJogos.Repositories;

namespace GestaoJogos.Services
{
    public class JogoService
    {
        private readonly JogoRepository _repository;

        public JogoService(JogoRepository repository) //* Injeção de dependencia -> Ao instanciar o JogoService ele injeta o JogoRepository
        {
            _repository = repository;
        }

        public List<Jogo> Listar() //* É uma convenção utilizar o mesmo nome que está no repository
        {
            return _repository.Listar();
        }
    }
}