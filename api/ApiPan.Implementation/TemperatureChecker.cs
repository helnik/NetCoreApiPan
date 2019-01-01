using ApiPan.Interfaces;

namespace ApiPan.Implementation
{
    public class TemperatureChecker : ITemperatureChecker
    {
        public bool IsCookingReadyTemperature(int temp)
        {
            return temp >= 10;
        }
    }
}
