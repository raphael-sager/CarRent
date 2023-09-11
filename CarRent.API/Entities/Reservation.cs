namespace CarRent.API.Entities
{
    public class Reservation
    {
        public int ReservationNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }

        public virtual ICollection<RentalContract> RentalContracts { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
