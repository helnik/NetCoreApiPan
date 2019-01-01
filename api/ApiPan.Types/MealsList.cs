using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiPan.Types
{
    [DataContract]
    public class MealsList
    {
        [DataMember(Name = "Meals")]
        public List<Meal> Meals { get; set; }
    }
}
