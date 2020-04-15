using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using UsingAspNet.Models;

namespace UsingAspNet.Controllers
{
    public class AdminController : Controller
    {
        // object of model ProjectModels
        readonly ProjectModels pm = new ProjectModels();
        // GET: Admin
        public ActionResult Index()
        {
            List<ProjectModels> projList = new List<ProjectModels>();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/App_Data/ProjList.xml"));
            DataView dvPrograms;
            dvPrograms = ds.Tables[0].DefaultView;
            dvPrograms.Sort = "Id";
            foreach (DataRowView dataRow in dvPrograms)
            {
                pm.ProjId = Convert.ToInt32(dataRow[0]);
                pm.ProjName = Convert.ToString(dataRow[1]);
                pm.Location = Convert.ToString(dataRow[2]);
            }
            if (projList.Count > 0) {
                return View(projList);
            }
            return View();
        }

        // GET: Admin/Details/5
        public void Details(int id)
        {
            XDocument xDocument = XDocument.Load(Server.MapPath("~/App_Data/ProjList.xml"));
            var items = (from item in xDocument.Descendants("Project")
                         where Convert.ToInt32(item.Element("Id").Value) == id
                         select new ProjectItems
                         {
                             Id = Convert.ToInt32(item.Element("Id").Value),
                             ProjectName = item.Element("ProjectName").Value,
                             Location = item.Element("Location").Value
                         }).SingleOrDefault();
            if (items != null)
            {
                pm.ProjId = items.Id;
                pm.ProjName = items.ProjectName;
                pm.Location = items.Location;
            }
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult AddEditProject(int? id)
        {
            int Id = Convert.ToInt32(id);
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                if (Id > 0)
                {
                    Details(Id);
                    pm.IsEdit = true;
                    return View(pm);
                }
                else
                {
                    pm.IsEdit = false;
                    return View(pm);
                }
            }
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult AddEditProject(ProjectModels models)
        {
            if(models.ProjId > 0)
            {
                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/ProjList.xml"));
                var items = (from item in xmlDoc.Descendants("Project") select item).ToList();
                XElement selected = items.Where(p => p.Element("Id").Value == models.ProjId.ToString()).FirstOrDefault();
                selected.Remove();
                xmlDoc.Save(Server.MapPath("~/App_Data/ProjList.xml"));
                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath("~/App_Data/ProjList.xml"));

                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath("~/XML/ProjectList.xml"));
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.Load(Server.MapPath("~/App_Data/ProjList.xml"));
                XmlNodeList nodelist = oXmlDocument.GetElementsByTagName("Project");
                var x = oXmlDocument.GetElementsByTagName("Id");
                int Max = 0;
                foreach (XmlElement item in x)
                {
                    int EId = Convert.ToInt32(item.InnerText.ToString());
                    if (EId > Max)
                    {
                        Max = EId;
                    }
                }
                Max += 1;
                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/ProjList.xml"));
                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", Max), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath("~/App_Data/ProjList.xml"));
                return RedirectToAction("Index", "Admin");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                XDocument xmlDoc = XDocument.Load(Server.MapPath("~/App_Data/ProjList.xml"));
                var items = (from item in xmlDoc.Descendants("Project") select item).ToList();
                XElement selected = items.Where(p => p.Element("Id").Value == id.ToString()).FirstOrDefault();
                selected.Remove();
                xmlDoc.Save(Server.MapPath("~/App_Data/ProjList.xml"));
            }
            return RedirectToAction("Index", "Admin");
        }

        // POST: Admin/Delete/5
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
    public class ProjectItems
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public ProjectItems() { }
    }
}
