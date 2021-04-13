using AutoMapper;
using SBSClientServerManager.Models;
using SBSClientServerManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSClientServerManager.Controllers
{
    public class ClientController : Controller
    {
        
        private ApplicationDbContext _context;
        public ClientController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Client
        public ActionResult Index()
        {
            var clients = _context.Clients.ToList();
            var viewModel = Mapper.Map<List<ClientViewModel>>(clients);
            if (User.IsInRole("CanManageAllClientDetails"))
                return View("Index", viewModel);
            return View("ReadOnly-Index",viewModel);
        }

        // Get: List for Data Tables
        public ActionResult GetClientList()
        {
            var clients = _context.Clients.ToList();
            var viewModel = Mapper.Map<List<ClientViewModel>>(clients);
            return Json(new{data = viewModel},JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetServersList(int Id)
        {
           var servers = _context.Servers.Where(s => s.ClientId == Id)
               .ToList().Select(Mapper.Map<Server, ServerViewModel>);

            return Json(new { data = servers }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetVpnList(int Id)
        {
            var vpns = _context.VPNs.Where(v => v.ClientId == Id)
            .ToList().Select(Mapper.Map<VPN, VpnViewModel>);

            return Json(new { data = vpns }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetSqlList(int Id)
        {
            var sqlservers = _context.SqlServers.Where(s => s.ClientId == Id)
           .ToList().Select(Mapper.Map<SqlServer, SqlServerViewModel>);

            return Json(new { data = sqlservers }, JsonRequestBehavior.AllowGet);
        }
         
        
       
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == 0|| id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var client = _context.Clients.Single(c => c.Id == id);
                _context.Clients.Remove(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Details(int Id)

        {
            if (Id == 0)
                return RedirectToAction("Index");
            var servers = _context.Servers.Where(s => s.ClientId == Id)
                .ToList().Select(Mapper.Map<Server, ServerViewModel>);
             var vpns =_context.VPNs.Where(v => v.ClientId == Id)
                .ToList().Select(Mapper.Map<VPN, VpnViewModel>);
            var sqlservers = _context.SqlServers.Where(s => s.ClientId == Id)
                .ToList().Select(Mapper.Map<SqlServer, SqlServerViewModel>);
            var clientname = _context.Clients.SingleOrDefault(c => c.Id == Id).Name;

            var viewModel = new ClientViewModel
            {
                Name = clientname,
                Servers = servers,
                Vpns = vpns,
                SqlServers = sqlservers,
                Id = Id
   
            };
            if (User.IsInRole("CanManageAllClientDetails"))
                return View("Details", viewModel);
            return View("ReadOnly-Details", viewModel);
           

        }

        
        public PartialViewResult Add()
        {
            var newclients = new Client();
            var viewModel = Mapper.Map<ClientFormViewModel>(newclients);
            return PartialView("_CreateClient", viewModel);

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(ClientFormViewModel clientdata)
        {
            if (string.IsNullOrEmpty(clientdata.Name))
            {
                ModelState.AddModelError("Name", "Name can not be Empty!!");
                return RedirectToAction("Add", clientdata);
            }

            if (!ModelState.IsValid)
                    return RedirectToAction("Add", clientdata);
                
            
                var newclient = Mapper.Map<Client>(clientdata);
                _context.Clients.Add(newclient);
                _context.SaveChanges();
                //var clientId = newclient.Id;
                return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var clientinDb = _context.Clients.FirstOrDefault(c => c.Id == id);
            var viewModel = Mapper.Map<ClientFormViewModel>(clientinDb);
            return PartialView("_EditClient", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ClientFormViewModel clientUpdate)
        {
            if (!ModelState.IsValid)
                return PartialView("_EditClient", clientUpdate);


            var clientinDb = _context.Clients.Single(c => c.Id == clientUpdate.Id);
            Mapper.Map(clientUpdate, clientinDb);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}