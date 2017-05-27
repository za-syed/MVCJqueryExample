using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPopupUsers.Models;
using MVCPopupUsers.DAL;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace MVCPopupUsers.Controllers
{
    public class FriendsController : Controller
    {
        private FriendsDBContext db = new FriendsDBContext();
        private IEnumerable<State> states = null;
        // GET: /Phone/
        public ActionResult Index(string filter = null, int page = 1,
             int pageSize = 5, string sort = "FriendId", string sortdir = "DESC")
        {
            states = db.States;
            var records = new PagedList<Friend>();
            ViewBag.filter = filter;
            records.Content = db.Friends
                        .Where(x => filter == null ||
                                (x.FirstName.Contains(filter))
                                   || x.LastName.Contains(filter) || x.MiddleName.Contains(filter) || x.Gender.Contains(filter)
                                   || x.MaritalStatus.Contains(filter)
                              )
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Friends
                         .Where(x => filter == null ||
                               (x.FirstName.Contains(filter)) || 
                               x.LastName.Contains(filter) || x.MiddleName.Contains(filter)
                               || x.Gender.Contains(filter) || x.MaritalStatus.Contains(filter)
                               ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }
        public ActionResult Details(int id = 0)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            states = db.States;
            ViewBag.states = states;
            return PartialView("Details", friend);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var friend = new Friend();            
            states = db.States;
            ViewBag.states = states;
            return PartialView("Create", friend);
        }


        // POST: /Phone/Create
        [HttpPost]
        public JsonResult Create(Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Friends.Add(friend);
                db.SaveChanges();
                return Json(new { success = true });
            }           
            return Json(friend, JsonRequestBehavior.AllowGet);
        }
        // GET: /Phone/Edit/5
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            var friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            states = db.States;
            ViewBag.states = states;
            return PartialView("Edit", friend);
        }


        // POST: /Phone/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Friend  friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit", friend);
        }
        public ActionResult Delete(int id = 0)
        {
            Friend friend = db.Friends.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            states = db.States;
            ViewBag.states = states;
            return PartialView("Delete", friend);
        }


        //
        // POST: /Phone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var friend = db.Friends.Find(id);
            db.Friends.Remove(friend);
            db.SaveChanges();
            return Json(new { success = true });
        }
       [HttpGet]
        //[HttpPost]
        public ActionResult GetCitiesByState(string StateCode )
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            var citys = db.Cities.Where(c=>c.StateCode==StateCode);
            citys.ForEachAsync(c => cities.Add(new SelectListItem(){Value=c.CityCode,Text=c.CityDesc}));
            return Json(cities, JsonRequestBehavior.AllowGet);

        }
	}
}