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
    public class SQLController : Controller
    {
        // GET: SQL
        private ApplicationDbContext _context;
        public SQLController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Server
        [HttpGet]
        public ActionResult Add(int? clientId)
        {
            var newsqlservers = new SqlServer();

            var viewModel = Mapper.Map<SqlServerFormViewModel>(newsqlservers);
            viewModel.ClientId = clientId;
            return PartialView("_AddSqlServer", viewModel);

        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(SqlServerFormViewModel sqldata)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add", sqldata);

            var password = EncryptionHelper.EncryptStringAES(sqldata.Password);
            sqldata.Password = password;

            var newsql = Mapper.Map<SqlServer>(sqldata);
            _context.SqlServers.Add(newsql);
            _context.SaveChanges();
            var clientId = newsql.ClientId;
            return RedirectToAction("Details", "Client", new { id = clientId });
        }


            public ActionResult Edit(int id)
        {
            var sqlserverinDb = _context.SqlServers.FirstOrDefault(c => c.Id == id);
            var password = EncryptionHelper.DecryptStringAES(sqlserverinDb.Password);
            sqlserverinDb.Password = password;
            var viewModel = Mapper.Map<SqlServerFormViewModel>(sqlserverinDb);
            return PartialView("_EditSqlServer", viewModel);

        }

        public ActionResult View(int id)
        {
            var sqlserverinDb = _context.SqlServers.FirstOrDefault(c => c.Id == id);
            var password = EncryptionHelper.DecryptStringAES(sqlserverinDb.Password);
            sqlserverinDb.Password = password;
            var viewModel = Mapper.Map<SqlServerFormViewModel>(sqlserverinDb);
            return PartialView("_ViewSqlServer", viewModel);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(SqlServerFormViewModel sqlServerUpdate)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", sqlServerUpdate);
            var password = EncryptionHelper.EncryptStringAES(sqlServerUpdate.Password);
            sqlServerUpdate.Password = password;
           
            var sqlServerinDb = _context.SqlServers.Single(c => c.Id == sqlServerUpdate.Id);
            Mapper.Map(sqlServerUpdate, sqlServerinDb);
            _context.SaveChanges();
            return RedirectToAction("Details", "Client", new { id = sqlServerUpdate.ClientId });

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
                var server = _context.SqlServers.Single(c => c.Id == id);
                _context.SqlServers.Remove(server);
                _context.SaveChanges();
                return RedirectToAction("Details", "Client", new { id = server.ClientId });
            }

        }
    }
}
