namespace Library
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int License { get; set; }
        public override string ToString()
        {
            return $"{Id}, {Name}, {License}";
        }
    }
}
