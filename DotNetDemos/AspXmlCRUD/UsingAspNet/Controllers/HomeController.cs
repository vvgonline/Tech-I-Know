using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//want to make this controller and ProjectModels as sample for XML CRUD
//Thus need to reference System.Xml: https://docs.microsoft.com/en-us/dotnet/standard/data/xml/process-xml-data-using-the-dom-model and https://docs.microsoft.com/en-us/dotnet/api/system.xml?view=netframework-4.5
using System.Xml;
using System.Collections.Generic;
using UsingAspNet.Models;

namespace UsingAspNet.Controllers
{
    public class HomeController : Controller
    {
        private string xmlDocLocation = "~/App_Data/ProjList.xml";
        // GET: Home
        public ActionResult Index()
        {
            List<ProjectModels> projects = new List<ProjectModels>();
            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath(xmlDocLocation));

            //Loop through the selected Nodes.
            foreach (XmlNode node in doc.SelectNodes("/Projects/project"))
            {
                //Fetch the Node values and assign it to Model.
                projects.Add(new ProjectModels
                {
                    ProjId = int.Parse(node["Id"].InnerText),
                    ProjName = node["ProjectName"].InnerText,
                    Location = node["Location"].InnerText
                });
            }
            return View(projects);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
