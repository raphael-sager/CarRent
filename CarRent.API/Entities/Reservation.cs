namespace CarRent.API.Entities
{
    public class Reservation
    {
        public int ReservationNr { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public Customer Customer { get; set; }
        public Category Category { get; set; }
        public int RentalContractId { get; set; }
        public RentalContract RentalContract { get; set; }
    }
}
