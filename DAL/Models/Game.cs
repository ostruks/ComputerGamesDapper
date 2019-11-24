using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Invalid name length")]
        public string Name { get; set; }
        [Required]
        [Range(1980, 2019, ErrorMessage = "Invalid year")]
        public int YearOfIssue { get; set; }
        public int Genre_Id { get; set; }
        public int Publisher_Id { get; set; }
        public Publisher Publisher { get; set; }
        public Genre Genre { get; set; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {YearOfIssue}, {Genre_Id}, {Publisher_Id}";
        }
    }
}
