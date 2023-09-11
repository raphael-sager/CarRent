namespace CarRent.API.Entities
{
    public class RentalContract
    {
        public int ContractNr { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
