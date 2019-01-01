using ApiPan.Interfaces;
using ApiPan.Types;
using System;
using Newtonsoft.Json;
using RestSharp;

namespace ApiPan.Implementation
{
    public class Baker : ICooker
    {
        public string StartCooking(int temp) => $"Started baking at {temp} Celsius";

        public DateTime GetCookingStartTime() => DateTime.Now;

        /// <summary>
        /// Free to use api read instructions here https://forum.kodi.tv/showthread.php?tid=282387
        /// </summary>
        /// <param name="mealName"></param>
        /// <returns></returns>
        public MealsList GetRecipeByMealName(string mealName)
        {
            var client = new RestClient(@"http://www.themealdb.com/api/json/v1/1/");
            var resp = client.Execute($"search.php?s={mealName}"); //Pancakes
            return JsonConvert.DeserializeObject<MealsList>(resp.Content);
        }


      
    }
}
