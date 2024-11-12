namespace FoodFacts.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
    }
}