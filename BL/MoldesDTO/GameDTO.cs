using BL.Exception;
using System;

namespace BL.MoldesDTO
{
    public class GameDTO
    {
        private string _name;
        private int _yearOfIssue;
        public int Id { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 60)
                {
                    throw new ValidationException("Name of the game should be less then 60 letters", "");
                }

                _name = value;
            }
        }
        public int YearOfIssue
        {
            get
            {
                return _yearOfIssue;
            }
            set
            {
                if (_yearOfIssue < 1980 || _yearOfIssue > DateTime.Now.Year)
                {
                    throw new ValidationException("Publishing year should be much than 1980 and not much than today's year", "");
                }

                _yearOfIssue = value;
            }
        }
        public int Genre_Id { get; set; }
        public int Publisher_Id { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {YearOfIssue}, {Genre_Id}, {Publisher_Id}";
        }
    }
}
