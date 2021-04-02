using AutoMapper;
using SBSClientServerManager.Models;
using SBSClientServerManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSClientServerManager.Controllers
{
    public class ServerController : Controller
    {
        private ApplicationDbContext _context;
        public ServerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Server
        [HttpGet]
        public PartialViewResult Add(int? clientId)
        {
            var viewModel = new ServerFormViewModel
            {
                ClientId = clientId
            };

            return PartialView("_AddServer", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(ServerFormViewModel serverdata)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add", serverdata);


            var newserver = Mapper.Map<Server>(serverdata);
            _context.Servers.Add(newserver);
            _context.SaveChanges();
            var clientId = newserver.ClientId;
            return RedirectToAction("Details","Client",new { id=clientId });

        }
        public ActionResult Edit(int id)
        {
            var serverinDb = _context.Servers.FirstOrDefault(c => c.Id == id);
            var viewModel = Mapper.Map<ServerFormViewModel>(serverinDb);
            return PartialView("_EditServer", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ServerFormViewModel serverUpdate)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", serverUpdate);


            var serverinDb = _context.Servers.Single(c => c.Id == serverUpdate.Id);
            Mapper.Map(serverUpdate, serverinDb);
            _context.SaveChanges();
            return RedirectToAction("Details", "Client", new { id = serverUpdate.ClientId });

        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == 0|| id ==null)
            {
                return HttpNotFound();
            }
            else
            {
                var server = _context.Servers.Single(c => c.Id == id);
                _context.Servers.Remove(server);
                _context.SaveChanges();
                return RedirectToAction("Details","Client",new { id=server.ClientId});
            }

        }
    }
}