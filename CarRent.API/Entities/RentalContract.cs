namespace CarRent.API.Entities
{
    public class RentalContract
    {
        public int ContractNr { get; set; }

        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
