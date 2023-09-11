namespace CarRent.API.Entities
{
    public class RentalContract
    {
        public int ContractNr { get; set; }
        public Reservation Reservation { get; set; }
        public Car Car { get; set; }
    }
}
