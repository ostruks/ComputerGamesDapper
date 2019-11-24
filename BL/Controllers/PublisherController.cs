using BL.MoldesDTO;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BL.Controllers
{
    public class PublisherController : IRepository<PublisherDTO>
    {
        private PublisherRepository _publisherRepository = new PublisherRepository();
        public PublisherDTO Create(PublisherDTO creator)
        {
            var result = _publisherRepository.Create(Mapping.CreatorFromBlToDal(creator));
            return Mapping.CreatorFromDalToBl(result);
        }

        public void Delete(PublisherDTO creator)
        {
            _publisherRepository.Delete(Mapping.CreatorFromBlToDal(creator));
        }

        public void Delete(int id)
        {
            _publisherRepository.Delete(id);
        }

        public List<PublisherDTO> GetAll(int license = 0)
        {
            List<PublisherDTO> result = new List<PublisherDTO>();
            foreach (Publisher publisher in _publisherRepository.GetAll(license))
            {
                result.Add(Mapping.CreatorFromDalToBl(publisher));
            }
            return result;
        }

        public PublisherDTO Get(int Id)
        {
            return Mapping.CreatorFromDalToBl(_publisherRepository.Get(Id));
        }

        public void Update(PublisherDTO creator)
        {
            _publisherRepository.Update(Mapping.CreatorFromBlToDal(creator));
        }
    }
}
