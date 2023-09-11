namespace CarRent.API.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
