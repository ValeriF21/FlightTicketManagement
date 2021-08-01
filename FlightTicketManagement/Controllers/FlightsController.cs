using FlightTicketManagement.Models;
using FlightTicketManagement.Repositries;
using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightTicketManagement.Controllers
{
    public class FlightsController : Controller
    {
        // GET: FlightsController1
        public async Task<ActionResult<FlightsViewModel>> Index()
        {
            FlightsViewModel flightsViewModel = new FlightsViewModel();

            var returnedData = await new FlightsRepo().Get_All_Flights();
            var newList = new List<FullFlight>();

            foreach (var item in returnedData)
            {
                switch (item.Type_ID)
                {
                    case 1: newList.Add(item); break;
                    case 2: newList.Add((LowCost)item); break;
                    case 3: newList.Add((Charter)item); break;
                }
            }

            flightsViewModel.flights = newList;
            flightsViewModel.locations = await new LocationsRepo().Get_All_Locations();
            flightsViewModel.remarks = await new RemarksRepo().Get_All_Remarks();
            flightsViewModel.types = await new TypesRepo().Get_All_Types();

            return View(flightsViewModel);
        }

        // POST: FlightsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FlightForm flight = new FlightForm();
                    flight.StartingPoint = collection["flightForm.StartingPoint"];
                    flight.Destination = collection["flightForm.Destination"];
                    flight.Type_ID = int.Parse(collection["flightForm.Type_ID"]);
                    flight.Base_Price = float.Parse(collection["flightForm.Base_Price"]);
                    flight.StartingPoint_Departure = DateTime.Parse(DateTime.Parse(collection["flightForm.StartingPoint_Departure"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.StartingPoint_Arrival = DateTime.Parse(DateTime.Parse(collection["flightForm.StartingPoint_Arrival"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.Destination_Departure = DateTime.Parse(DateTime.Parse(collection["flightForm.Destination_Departure"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.Destination_Arrival = DateTime.Parse(DateTime.Parse(collection["flightForm.Destination_Arrival"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    var response = await new FlightsRepo().Save_Flight(flight);
                }
                return RedirectToAction("Index", "Flights");
            }
            catch (Exception ex)
            {
                return View("ErrorViewModel");
            }
        }

        // GET: FlightsController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FlightForm flight = new FlightForm();
                    flight.Type_ID = int.Parse(collection["flightForm.Type_ID"]);
                    flight.StartingPoint = collection["flightForm.StartingPoint"];
                    flight.Destination = collection["flightForm.Destination"];
                    flight.Base_Price = float.Parse(collection["flightForm.Base_Price"]);
                    flight.StartingPoint_Departure = DateTime.Parse(DateTime.Parse(collection["flightForm.StartingPoint_Departure"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.StartingPoint_Arrival = DateTime.Parse(DateTime.Parse(collection["flightForm.StartingPoint_Arrival"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.Destination_Departure = DateTime.Parse(DateTime.Parse(collection["flightForm.Destination_Departure"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    flight.Destination_Arrival = DateTime.Parse(DateTime.Parse(collection["flightForm.Destination_Arrival"]).ToString("yyyy-MM-ddTHH:mm:ss"));
                    var response = await new FlightsRepo().Edit_Flight(id, flight);
                }
                return RedirectToAction("Index", "Flights");
            }
            catch (Exception ex)
            {
                return View("ErrorViewModel");
            }
        }

        // GET: FlightsController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            string res = await new FlightsRepo().Delete_Flight(id);

            return RedirectToAction("Index", "Flights");
        }
    }
}
