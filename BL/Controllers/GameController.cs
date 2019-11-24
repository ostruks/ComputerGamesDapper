using BL.MoldesDTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class GameController : IRepository<GameDTO>
    {
        private GameRepository _gameRepository = new GameRepository();
        public GameDTO Create(GameDTO game)
        {
            var result = _gameRepository.Create(Mapping.GameFromBlToDal(game));
            return Mapping.GameFromDalToBl(result);
        }

        public void Delete(GameDTO game)
        {
            _gameRepository.Delete(Mapping.GameFromBlToDal(game));
        }

        public void Delete(int id)
        {
            _gameRepository.Delete(id);
        }

        public List<GameDTO> GetAll(int license = 0)
        {
            List<GameDTO> result = new List<GameDTO>();
            foreach (Game game in _gameRepository.GetAll(license))
            {
                result.Add(Mapping.GameFromDalToBl(game));
            }
            return result;
        }

        public GameDTO Get(int Id)
        {
            return Mapping.GameFromDalToBl(_gameRepository.Get(Id));
        }

        public void Update(GameDTO game)
        {
            _gameRepository.Update(Mapping.GameFromBlToDal(game));
        }
    }
}
