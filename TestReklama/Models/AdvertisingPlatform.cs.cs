﻿namespace TestReklama.Models
{
    public class AdvertisingPlatform
    {
        public string Name { get; set; }
        public List<string> Locations { get; set; } = new();
    }
}
