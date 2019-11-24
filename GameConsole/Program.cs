using BL.Controllers;
using BL.MoldesDTO;
using DAL;
using System;

namespace GameConsole
{
    class Program
    {
        static IRepository<GenreDTO> Genres = new GenreController();
        static IRepository<PublisherDTO> Publishers = new PublisherController();
        static IRepository<GameDTO> Games = new GameController();

        static void Main(string[] args)
        {
            //Show all
            Display(Genres);
            Display(Publishers);
            Display(Games);

            //Show one
            Display(Genres, 1);
            Display(Publishers, 1);
            Display(Games, 1);

            //Show one by license
            int license = 123654;
            GetAllGames(license);

            //Create one
            Create(Genres, new GenreDTO() { Name = "MMO", Description = "Description" });
            Create(Publishers, new PublisherDTO() { Name = "Man", License = 111222 });
            Create(Games, new GameDTO() { Name = "Chuvak", YearOfIssue = 2018, Genre_Id = 2, Publisher_Id = 3 });

            Display(Genres);
            Display(Publishers);
            Display(Games);

            //Update one
            Update(Genres, new GenreDTO() { Id = 2, Name = "MMORPG", Description = "New Description" });
            Update(Publishers, new PublisherDTO() { Id = 2, Name = "Man22", License = 111222 });
            Update(Games, new GameDTO() { Id = 2, Name = "Chuvak345", YearOfIssue = 2018, Genre_Id = 2, Publisher_Id = 2 });

            Display(Genres);
            Display(Publishers);
            Display(Games);

            //Delete one
            Delete(Genres, 3);
            Delete(Publishers, 3);
            Delete(Games, 3);

            Display(Genres);
            Display(Publishers);
            Display(Games);

            Console.ReadKey();
        }

        private static void Display<T>(IRepository<T> rep) where T : class
        {
            foreach (var genre in rep.GetAll())
            {
                Console.WriteLine(genre);
            }
            Console.WriteLine("========================");
        }

        private static void Display<T>(IRepository<T> rep, int Id) where T : class
        {
            Console.WriteLine(rep.Get(Id));
            Console.WriteLine("========================");
        }

        private static void Create<T>(IRepository<T> rep, T tclass) where T : class
        {
            Console.WriteLine(rep.Create(tclass));
        }

        private static void Update<T>(IRepository<T> rep, T tclass) where T : class
        {
            rep.Update(tclass);
        }

        private static void Delete<T>(IRepository<T> rep, int Id) where T : class
        {
            rep.Delete(Id);
        }

        private static void GetAllGames(int license)
        {
            foreach (var game in Games.GetAll(license))
            {
                Console.WriteLine(game);
            }
            Console.WriteLine("========================");
        }
    }
}
