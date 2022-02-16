using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMySql.Models;

namespace MVCMySql.Controllers
{
    public class HomeController : Controller
    {
        readonly MySqlCon _con;
        //readonly RemoteMySqlCon _rcon;
        public HomeController()
        {
            _con = new MySqlCon();
            //_rcon = new RemoteMySqlCon();
        }

        public ActionResult Index()
        {
            return View(_con.Contacts.ToList());
            //return View(_rcon.Tags.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}