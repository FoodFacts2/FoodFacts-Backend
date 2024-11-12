namespace FoodFacts.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}