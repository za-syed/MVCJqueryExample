using MVCPopupUsers.DAL;
using MVCPopupUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Data.Entity;

namespace MVCPopupUsers.Controllers
{
    public class CitiesController : Controller
    {
        private FriendsDBContext db = new FriendsDBContext();
        // GET: /Cities/                

        public ActionResult Index(string filter = null, int page = 1,
             int pageSize = 5, string sort = "CityId", string sortdir = "DESC")
        {
            var records = new PagedList<City>();
            ViewBag.filter = filter;
            records.Content = db.Cities
                        .Where(x => filter == null ||
                                (x.StateCode.Contains(filter))
                                   || x.CityCode.Contains(filter) || x.CityDesc.Contains(filter)
                              )
                        .OrderBy(sort + " " + sortdir)
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

            // Count
            records.TotalRecords = db.Cities
                         .Where(x => filter == null ||
                               (x.StateCode.Contains(filter)) ||
                               x.CityCode.Contains(filter) ||  x.CityDesc.Contains(filter)
                               ).Count();

            records.CurrentPage = page;
            records.PageSize = pageSize;

            return View(records);
        }
	}
}