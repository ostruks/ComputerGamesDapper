using System.Collections.Generic;

namespace DAL.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int License { get; set; }
        public ICollection<Game> Games { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {License}";
        }
    }
}
