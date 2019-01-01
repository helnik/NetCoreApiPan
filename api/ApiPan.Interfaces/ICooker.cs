using ApiPan.Types;
using System;

namespace ApiPan.Interfaces
{
    public interface ICooker
    {
        MealsList GetRecipeByMealName(string mealName);
        string StartCooking(int temp);
        DateTime GetCookingStartTime();
    }
}
