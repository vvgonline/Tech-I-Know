using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//want to make this controller and ProjectModels as sample for XML CRUD
//Thus need to reference System.Xml: https://docs.microsoft.com/en-us/dotnet/standard/data/xml/process-xml-data-using-the-dom-model and https://docs.microsoft.com/en-us/dotnet/api/system.xml?view=netframework-4.5
using System.Xml;
using UsingAspNet.Models;
using System.Xml.Linq;
using System.Data;

namespace UsingAspNet.Controllers
{
    public class HomeController : Controller
    {
        private const string xmlDocLocation = "~/App_Data/ProjList.xml";
        // object of model ProjectModels
        readonly ProjectModels pm = new ProjectModels();
        #region GET-Methods
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
            if(projects.Count > 0)
            {
                return View(projects);
            }
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            // object of model ProjectModels
            ProjectModels pm = new ProjectModels();
            XDocument xDocument = XDocument.Load(Server.MapPath(xmlDocLocation));
            var items = (from item in xDocument.Descendants("project")
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

            return View(pm);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            // object of model ProjectModels
            ProjectModels pm = new ProjectModels();
            XDocument xDocument = XDocument.Load(Server.MapPath(xmlDocLocation));
            var items = (from item in xDocument.Descendants("project")
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

            return View(pm);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                XmlDocument XmlDocObj = new XmlDocument();
                XmlDocObj.Load(Server.MapPath(xmlDocLocation));
                XmlNode RootNode = XmlDocObj.SelectSingleNode("Projects");
                XmlNodeList projects = RootNode.ChildNodes;

                XmlNode node = projects[0];

                //int pId = int.Parse(Request.Form["_pId"]);

                foreach (XmlNode n in projects)
                {
                    if (int.Parse(n["Id"].InnerText) == id)
                    {
                        node = n;
                    }
                }

                node.RemoveAll();
                RootNode.RemoveChild(node);

                XmlDocObj.Save(Server.MapPath(xmlDocLocation));


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region POST-Methods
        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(ProjectModels project)
        {
            try
            {
                // TODO: Add insert logic here
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Server.MapPath(xmlDocLocation));
                XmlNode node = xmlDocument.SelectSingleNode("Projects");
                XmlNodeList nodeList = node.ChildNodes;

                //get the last id
                var x = xmlDocument.GetElementsByTagName("Id");
                int Max = 0;
                foreach (XmlElement item in x)
                {
                    int EId = Convert.ToInt32(item.InnerText.ToString());
                    if (EId > Max)
                    {
                        Max = EId;
                    }
                }
                Max += 1; //increment the last id by 1

                //now to new node
                XmlNode newNode = node.AppendChild(
                        xmlDocument.CreateNode(XmlNodeType.Element, "project", "")
                    );
                // TODO: Add last incremental Id logic
                newNode.AppendChild(
                        xmlDocument.CreateNode(XmlNodeType.Element, "Id", "")
                    ).InnerText = Max.ToString();
                // add project name
                newNode.AppendChild(
                        xmlDocument.CreateNode(XmlNodeType.Element, "ProjectName", "")
                    ).InnerText = project.ProjName;
                // add project location
                newNode.AppendChild(
                        xmlDocument.CreateNode(XmlNodeType.Element, "Location", "")
                    ).InnerText = project.Location;

                // now save the changes
                xmlDocument.Save(Server.MapPath(xmlDocLocation));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View();
        }

        public ActionResult Update(ProjectModels project, FormCollection collection)
        {
            XmlDocument XmlDocObj = new XmlDocument();
            XmlDocObj.Load(Server.MapPath(xmlDocLocation));
            XmlNode RootNode = XmlDocObj.SelectSingleNode("Projects");
            XmlNodeList projects = RootNode.ChildNodes;

            XmlNode node = projects[0];
            foreach (XmlNode ns in projects)
            {
                if (ns["Id"].InnerText == project.ProjId.ToString())
                {
                    node = ns;
                }
            }

            node["ProjectName"].InnerText = project.ProjName;
            node["Location"].InnerText = project.Location;

            XmlDocObj.Save(Server.MapPath(xmlDocLocation));

            return RedirectToAction("Index");
        }
        #endregion
    }
}