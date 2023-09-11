namespace CarRent.API.Entities
{
    public class Midrange : Category
    {
        public override int Id { get; set; }
        public override decimal DailyFee { get; set; }
        public override ICollection<Car> Cars { get; set; }
    }
}
