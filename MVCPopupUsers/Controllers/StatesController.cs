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
    public class StatesController : Controller
    {
        //
        // GET: /States/
        private FriendsDBContext db = new FriendsDBContext();
        
        public ActionResult Index(string filter = null, int page = 1,
             int pageSize = 5, string sort = "StateId", string sortdir = "DESC")
        {
            var records = new PagedList<State>();
            ViewBag.filter = filter;
            records.Content = db.States
                        .Where(x => filter == null ||
                                (x.StateCode.Contains(filter))
                                   || x.StateDescription.Contains(filter) 
                              )
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.States
                         .Where(x => filter == null ||
                               (x.StateCode.Contains(filter)) ||
                               x.StateDescription.Contains(filter) 
                               ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }
        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            State state = db.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return PartialView("Details", state);
        }

      
        [HttpGet]
        public ActionResult Create()
        {
            var state = new State();
            return PartialView("Create",state);
        }

        [HttpPost]
        public JsonResult Create(State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(state, JsonRequestBehavior.AllowGet);
        }
      
        [HttpGet]
        public ActionResult Edit(int id = 0)
        { 
          var state = db.States.Find(id);
          if (state ==null)
          {
              return HttpNotFound();
          }
          return PartialView("Edit", state);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
            }
            return PartialView("Edit",state);
        }
       
        [HttpGet]
        public ActionResult Delete(int id = 0) 
        {
            var state = db.States.Find(id);
            if (state==null)
            {
                return HttpNotFound();
            }
            return PartialView("Delete", state);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var state = db.States.Find(id);
            db.States.Remove(state);
            db.SaveChanges();
            return Json(new { success=true});
        }

	}
}