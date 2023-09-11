namespace CarRent.API.Entities
{
    public class Customer
    {
        public Customer(string customerNr, string name)
        {
            Id = Guid.NewGuid();
            CustomerNr = customerNr;
            Name = name;
        }

        public Customer()
        {

        }

        public Guid Id { get; }

        public string CustomerNr { get; }

        public string Name { get; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
