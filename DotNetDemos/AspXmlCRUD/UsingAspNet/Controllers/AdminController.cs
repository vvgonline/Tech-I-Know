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
        // XML File location inside the project
        private string xmlDocLocation = "~/App_Data/ProjList.xml";
        // GET: Admin
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
            if (projects.Count > 0)
            {
                return View(projects);
            }
            return View();
        }

        // GET: Admin/Details/5
        public void Details(int id)
        {
            XDocument xDocument = XDocument.Load(Server.MapPath(xmlDocLocation));
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
        public ActionResult Create(int?id, FormCollection collection, ProjectModels models)
        {
            try
            {
                // TODO: Add insert logic here
                if (id is null)
                {
                    XmlDocument oXmlDocument = new XmlDocument();
                    oXmlDocument.Load(Server.MapPath(xmlDocLocation));
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
                    XDocument xmlDoc = XDocument.Load(Server.MapPath(xmlDocLocation));
                    xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", Max), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                    xmlDoc.Save(Server.MapPath(xmlDocLocation));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (models.ProjId > 0)
                    {
                        XDocument xmlDoc = XDocument.Load(Server.MapPath(xmlDocLocation));
                        var items = (from item in xmlDoc.Descendants("Project") select item).ToList();
                        XElement selected = items.Where(p => p.Element("Id").Value == models.ProjId.ToString()).FirstOrDefault();
                        selected.Remove();
                        xmlDoc.Save(Server.MapPath(xmlDocLocation));
                        xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                        xmlDoc.Save(Server.MapPath(xmlDocLocation));

                        xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                        xmlDoc.Save(Server.MapPath(xmlDocLocation));
                        return RedirectToAction("Index", "Home");
                    }
                }
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
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            else
            {
                int Id = Convert.ToInt32(id);
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
                XDocument xmlDoc = XDocument.Load(Server.MapPath(xmlDocLocation));
                var items = (from item in xmlDoc.Descendants("Project") select item).ToList();
                XElement selected = items.Where(p => p.Element("Id").Value == models.ProjId.ToString()).FirstOrDefault();
                selected.Remove();
                xmlDoc.Save(Server.MapPath(xmlDocLocation));
                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath(xmlDocLocation));

                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", models.ProjId), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath(xmlDocLocation));
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.Load(Server.MapPath(xmlDocLocation));
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
                XDocument xmlDoc = XDocument.Load(Server.MapPath(xmlDocLocation));
                xmlDoc.Element("Projects").Add(new XElement("Project", new XElement("Id", Max), new XElement("ProjectName", models.ProjName), new XElement("Location", models.Location)));
                xmlDoc.Save(Server.MapPath(xmlDocLocation));
                return RedirectToAction("Index", "Admin");
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (id > 0)
                {
                    XDocument xmlDoc = XDocument.Load(Server.MapPath(xmlDocLocation));
                    var items = (from item in xmlDoc.Descendants("Project") select item).ToList();
                    XElement selected = items.Where(p => p.Element("Id").Value == id.ToString()).FirstOrDefault();
                    selected.Remove();
                    xmlDoc.Save(Server.MapPath(xmlDocLocation));
                }
                return RedirectToAction("Index", "Admin");
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
