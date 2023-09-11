namespace CarRent.API.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Car Car { get; set; }
    }
}
