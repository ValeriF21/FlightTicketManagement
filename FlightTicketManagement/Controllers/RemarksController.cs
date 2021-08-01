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
    public class RemarksController : Controller
    {
        // GET: RemarksController
        public async Task<ActionResult<RemarksViewModel>> Index()
        {
            RemarksViewModel remarksViewModel = new RemarksViewModel();
            RemarksRepo remarksRepo = new RemarksRepo();
            TypesRepo typesRepo = new TypesRepo();

            remarksViewModel.remarks = await remarksRepo.Get_All_Remarks();
            remarksViewModel.types = await typesRepo.Get_All_Types();
            return View(remarksViewModel);
            
        }

        // GET: RemarksController/Create
        [HttpPost]
        public async Task<ActionResult> Create(string ID, string Description)
        {
            Remark remark = new Remark(int.Parse(ID), Description);

            string res = await new RemarksRepo().Save_Remark(remark);

            return RedirectToAction("Index", "Remarks");
        }

        // POST: RemarksController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                Remark remark = new Remark();
                remark.Description = collection["item.Description"];
                remark.Type_ID = int.Parse(collection["item.Type_ID"]);
                var response = await new RemarksRepo().Edit_Location(id, remark);
                return RedirectToAction("Index", "Remarks");
            }
            catch (Exception ex)
            {
                return View("ErrorViewModel");
            }
        }

        // GET: RemarksController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            RemarksRepo remarkRepo = new RemarksRepo();

            string res = await remarkRepo.Delete_Remark(id);

            return RedirectToAction("Index", "Remarks");
        }
    }
}
