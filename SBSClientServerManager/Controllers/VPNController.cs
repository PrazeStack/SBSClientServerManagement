using AutoMapper;
using SBSClientServerManager.Helper;
using SBSClientServerManager.Models;
using SBSClientServerManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBSClientServerManager.Controllers
{
    public class VPNController : Controller
    {
        
        private ApplicationDbContext _context;
        public VPNController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        [HttpGet]
        public ActionResult Add(int? clientId)
        {
            var newvpnservers = new VPN();

            var viewModel = Mapper.Map<VpnFormViewModel>(newvpnservers);
            viewModel.ClientId = clientId;
            return PartialView("_AddVpn", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(VpnFormViewModel vpndata)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add", vpndata);

            var password = EncryptionHelper.EncryptStringAES(vpndata.Password);
            vpndata.Password = password;

            var newvpn = Mapper.Map<VPN>(vpndata);
            _context.VPNs.Add(newvpn);
            _context.SaveChanges();
            var clientId = newvpn.ClientId;
            return RedirectToAction("Details", "Client", new { id = clientId });

        }
        public ActionResult Edit(int id)
        {
            var vpninDb = _context.VPNs.FirstOrDefault(c => c.Id == id);
            var password = EncryptionHelper.DecryptStringAES(vpninDb.Password);
            vpninDb.Password = password;
            var viewModel = Mapper.Map<VpnFormViewModel>(vpninDb);
            return PartialView("_EditVpn", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(VpnFormViewModel vpnUpdate)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", vpnUpdate);
           
            var password = EncryptionHelper.EncryptStringAES(vpnUpdate.Password);
            vpnUpdate.Password = password;

            var serverinDb = _context.VPNs.Single(c => c.Id == vpnUpdate.Id);
            Mapper.Map(vpnUpdate, serverinDb);
            _context.SaveChanges();
            return RedirectToAction("Details", "Client", new { id = vpnUpdate.ClientId });

        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var vpn = _context.VPNs.Single(c => c.Id == id);
                _context.VPNs.Remove(vpn);
                _context.SaveChanges();
                return RedirectToAction("Details", "Client", new { id = vpn.ClientId });
            }

        }

        public ActionResult View(int id)
        {
            var vpninDb = _context.VPNs.FirstOrDefault(c => c.Id == id);
            var password = EncryptionHelper.DecryptStringAES(vpninDb.Password);
            vpninDb.Password = password;
            var viewModel = Mapper.Map<VpnFormViewModel>(vpninDb);
            return PartialView("_ViewVpn", viewModel);

        }
    }
}
