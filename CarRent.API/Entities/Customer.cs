using System.Net;

namespace CarRent.API.Entities
{
    public class Customer
    {
        public Customer(int id, string name)
        {
            CustomerNr = id;
            Name = name;
        }

        public Customer()
        {
        }

        public int CustomerNr { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
