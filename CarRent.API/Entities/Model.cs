﻿namespace CarRent.API.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
