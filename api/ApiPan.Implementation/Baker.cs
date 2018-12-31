using ApiPan.Interfaces;
using System;

namespace ApiPan.Implementation
{
    public class Baker : ICooker
    {
        public DateTime GetCookingStartTime() => DateTime.Now;
    }
}
