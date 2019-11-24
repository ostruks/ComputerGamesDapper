using AutoMapper;
using DAL.Models;

namespace BL.MoldesDTO
{
    internal static class Mapping
    {
        private static IMapper _blMapper = new MapperConfiguration(
            conf =>
            {
                conf.CreateMap<Game, GameDTO>();
                conf.CreateMap<GameDTO, Game>();
                conf.CreateMap<Genre, GenreDTO>();
                conf.CreateMap<GenreDTO, Genre>();
                conf.CreateMap<Publisher, PublisherDTO>();
                conf.CreateMap<PublisherDTO, Publisher>();
            }).CreateMapper();

        internal static Game GameFromBlToDal(GameDTO game)
        {
            return _blMapper.Map<GameDTO, Game>(game);
        }
        internal static GameDTO GameFromDalToBl(Game game)
        {
            return _blMapper.Map<Game, GameDTO>(game);
        }
        internal static Genre GenreFromBlToDal(GenreDTO genre)
        {
            return _blMapper.Map<GenreDTO, Genre>(genre);
        }
        internal static GenreDTO GenreFromDalToBl(Genre genre)
        {
            return _blMapper.Map<Genre, GenreDTO>(genre);
        }
        internal static Publisher CreatorFromBlToDal(PublisherDTO creator)
        {
            return _blMapper.Map<PublisherDTO, Publisher>(creator);
        }
        internal static PublisherDTO CreatorFromDalToBl(Publisher creator)
        {
            return _blMapper.Map<Publisher, PublisherDTO>(creator);
        }
    }
}
