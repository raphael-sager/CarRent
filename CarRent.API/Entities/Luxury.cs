﻿namespace CarRent.API.Entities
{
    public class Luxury : Category
    {
        public override int Id { get; set; }
        public override decimal DailyFee { get; set; }
        public override ICollection<Car> Cars { get; set; }
    }
}
