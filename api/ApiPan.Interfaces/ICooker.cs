using System;

namespace ApiPan.Interfaces
{
    public interface ICooker
    {
        string StartCooking(int temp);
        DateTime GetCookingStartTime();
    }
}
