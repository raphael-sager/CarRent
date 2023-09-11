namespace CarRent.API.Entities
{
    public abstract class Category
    {
        public abstract int Id { get; set; }
        public abstract decimal DailyFee { get; set; }
        public abstract ICollection<Car> Cars { get; set; }
    }
}
