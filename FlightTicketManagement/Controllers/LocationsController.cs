using FlightTicketManagement.Models;
using FlightTicketManagement.Repositries;
using FlightTicketManagementEntites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagement.Controllers
{
    public class LocationsController : Controller
    {
        // GET: LocationsController
        public async Task<ActionResult<List<Location>>> Index()
        {
            LocationsViewModel locView = new LocationsViewModel();

            locView.locations = await new LocationsRepo().Get_All_Locations();

            return View(locView);
        }

        // GET: LocationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LocationsViewModel loc)
        {
            Location location = new Location(loc.Code, loc.Airport, loc.Country);

            var locationRepo = new LocationsRepo();

            string res = await locationRepo.Save_Location(location);

            return RedirectToAction("Index", "Locations");
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Code, IFormCollection collection)
        {
            try
            {
                Location location = new Location();
                location.Airport = collection["item.Airport"];
                location.Country = collection["item.Country"];
                var response = await new LocationsRepo().Edit_Location(Code, location);
                return RedirectToAction("Index", "Locations");
            }
            catch (Exception ex)
            {
                return View("ErrorViewModel");
            }
        }


        // GET: LocationsController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            LocationsRepo locationRepo = new LocationsRepo();

            string res = await locationRepo.Delete_Location(id);

            return RedirectToAction("Index", "Locations");
        }
    }
}
