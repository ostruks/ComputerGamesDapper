using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(600, MinimumLength = 1, ErrorMessage = "Invalid description length")]
        public string Description { get; set; }
        public ICollection<Game> Games { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
