using BL.MoldesDTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class GenreController : IRepository<GenreDTO>
    {
        private GenreRepository _genreRepository = new GenreRepository();
        public GenreDTO Create(GenreDTO genre)
        {
            var result = _genreRepository.Create(Mapping.GenreFromBlToDal(genre));
            return Mapping.GenreFromDalToBl(result);
        }

        public void Delete(GenreDTO genre)
        {
            _genreRepository.Delete(Mapping.GenreFromBlToDal(genre));
        }

        public void Delete(int id)
        {
            _genreRepository.Delete(id);
        }

        public List<GenreDTO> GetAll(int license = 0)
        {
            List<GenreDTO> result = new List<GenreDTO>();
            foreach (Genre genre in _genreRepository.GetAll(license))
            {
                result.Add(Mapping.GenreFromDalToBl(genre));
            }
            return result;
        }

        public GenreDTO Get(int Id)
        {
            return Mapping.GenreFromDalToBl(_genreRepository.Get(Id));
        }

        public void Update(GenreDTO genre)
        {
            _genreRepository.Update(Mapping.GenreFromBlToDal(genre));
        }
    }
}
