namespace CarRent.API.Entities
{
    public class Car
    {
        public int CarNr { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<RentalContract> Contracts { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
