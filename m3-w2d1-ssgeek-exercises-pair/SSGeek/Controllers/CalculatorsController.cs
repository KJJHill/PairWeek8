using SSGeek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSGeek.Controllers
{
    public class CalculatorsController : Controller
    {
        // INSTRUCTIONS
        // As a part of each exercise you will need to 
        // - develop a view for AlienAge, AlienWeight, and AlienTravel that displays a form to submit data
        // - develop a model for the forms to bind to when the form request is submitted
        // - create a new action to process the form submission (e.g. AlienAgeResult, AlienWeightResult, etc.)
        // - create a view that displays the submitted form result

        // GET: Calculators/AlienAge
        public ActionResult AlienAge()
        {
            if (Request.Params["Planet"] != null && Request.Params["InputAge"] != null)
            {
                string[] planetInfoSplit = Request.Params["Planet"].Split('|');
                double ageConversion = double.Parse(planetInfoSplit[1]);

                double calculatedAge = ageConversion * int.Parse(Request.Params["InputAge"]);

                ViewBag.InputAge = Request.Params["InputAge"];
                ViewBag.PlanetImage = planetInfoSplit[0] + ".jpg";
                ViewBag.PlanetName = planetInfoSplit[0];
                ViewBag.CalculatedAge = calculatedAge;
            }

            return View("AlienAge");
        }

        public ActionResult AlienWeight()
        {
            if (Request.Params["Planet"] != null && Request.Params["InputWeight"] != null)
            {
                string[] planetInfoSplit = Request.Params["Planet"].Split('|');
                double weightConversion = double.Parse(planetInfoSplit[2]);

                double calculatedWeight = weightConversion * int.Parse(Request.Params["InputWeight"]);

                ViewBag.InputWeight = Request.Params["InputWeight"];
                ViewBag.PlanetImage = planetInfoSplit[0] + ".jpg";
                ViewBag.PlanetName = planetInfoSplit[0];
                ViewBag.CalculatedWeight = calculatedWeight;
            }

            return View("AlienWeight");
        }

        public ActionResult AlienTravel()
        {
            const double hoursInYear = 8760;
            const double milesInAAU = 92960000;

            if (Request.Params["Planet"] != null && Request.Params["InputAge"] != null && Request.Params["InputMode"] != null)
            {
                string[] planetInfoSplit = Request.Params["Planet"].Split('|');
                string[] transportationSplit = Request.Params["InputMode"].Split('|');
                double auConversion = double.Parse(planetInfoSplit[3]);

                double speedOfTransportation = double.Parse(transportationSplit[1]);

                double distanceToPlanetAU = auConversion * milesInAAU;

                double earthYears = distanceToPlanetAU / (hoursInYear * speedOfTransportation);
                double calculatedAge = double.Parse(Request.Params["InputAge"]) + earthYears;

                ViewBag.InputAge = Request.Params["InputAge"];
                ViewBag.PlanetImage = planetInfoSplit[0] + ".jpg";
                ViewBag.PlanetName = planetInfoSplit[0];
                ViewBag.CalculatedAge = Math.Round(calculatedAge,2);
                ViewBag.EarthYears = Math.Round(earthYears,2);
                ViewBag.InputMode = transportationSplit[0];
            }

            return View("AlienTravel");
        }



        //TODO: Create an AlienWeight and AlienWeightResult Action
        //TODO: Create an AlienTravel and AlienTravelResult Action




    }
}