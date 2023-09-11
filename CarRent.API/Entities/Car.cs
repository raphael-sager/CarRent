namespace CarRent.API.Entities
{
    public class Car
    {
        public int CarNr { get; set; }
        public Model Model { get; set; }
        public Brand Brand { get; set; }
        public ICollection<RentalContract> Contracts { get; set; }
        public Category Category { get; set; }
    }
}
