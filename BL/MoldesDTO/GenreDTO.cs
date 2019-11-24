using BL.Exception;

namespace BL.MoldesDTO
{
    public class GenreDTO
    {
        private string _description;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value.Length > 600)
                {
                    throw new ValidationException("Description shouldbe less than 600 letters", "");
                }

                _description = value;
            }
        }
        public override string ToString()
        {
            return $"{Id}, {Name}, {Description}";
        }
    }
}
