using ApiPan.Interfaces;
using System;

namespace ApiPan.Implementation
{
    public class Baker : ICooker
    {
        public string StartCooking(int temp) => $"Started baking at {temp} Celsius";

        public DateTime GetCookingStartTime() => DateTime.Now;
    }
}
