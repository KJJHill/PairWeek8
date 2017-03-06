using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Models
{
    public class AlienInfo
    {
        // VALUES ARE IN FOLLOWING ORDER:
        //name
        //age
        //weight
        //distance (in AUs)

        public static List<SelectListItem> Planets { get; } = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury", Value = "Mercury|0.24|0.37|0.61"},
            new SelectListItem() { Text = "Venus", Value = "Venus|0.62|0.90|0.28"},
            new SelectListItem() { Text = "Mars", Value = "Mars|1.88|0.38|0.52" },
            new SelectListItem() { Text = "Jupiter", Value = "Jupiter|11.862|2.65|4.2" },
            new SelectListItem() { Text = "Saturn", Value = "Saturn|29.456|1.13|8.52" },
            new SelectListItem() { Text = "Neptune", Value = "Neptune|84.07|1.43|29.09" },
            new SelectListItem() { Text = "Uranus", Value = "Uranus|164.81|1.09|18.21" }
        };

        public static List<SelectListItem> TransportationModes { get; } = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="Walking|3" },
            new SelectListItem() { Text = "Car", Value = "Car|100" },
            new SelectListItem() { Text = "Bullet Train", Value = "Bullet Train|200" },
            new SelectListItem() { Text = "Boeing 747", Value = "Boeing 747|570" },
            new SelectListItem() { Text = "Concorde", Value = "Concorde|1350" }
        };

    }
}