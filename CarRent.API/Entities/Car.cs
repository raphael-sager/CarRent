namespace CarRent.API.Entities
{
    public class Car
    {
        public int CarNr { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<RentalContract> RentalContracts { get; set; }
    }
}
