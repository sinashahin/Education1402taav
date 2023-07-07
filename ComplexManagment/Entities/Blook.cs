namespace ComplexManagment.Entities
{
    public class Blook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int ComplexId { get; set; }
        public Complex Complex { get; set; }
    }
}
