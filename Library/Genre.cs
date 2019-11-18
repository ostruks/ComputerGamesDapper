using System.ComponentModel.DataAnnotations;

namespace Library
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [StringLength(600, MinimumLength = 1, ErrorMessage = "Invalid description length")]
        public string Description { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}";
        }
    }
}
