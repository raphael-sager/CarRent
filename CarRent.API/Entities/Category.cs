namespace CarRent.API.Entities
{
    public abstract class Category
    {
        public int CategoryId { get; set; }
        public abstract decimal DailyFee { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
