using CoreWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml;
using System.Xml.Linq;
namespace CoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        //IWebHostEnvironment required for contentRootPath and webRootPath
        private readonly IWebHostEnvironment _hostEnvironment;

        // application's base path
        private readonly string contentRootPath;

        // application's publishing path
        private readonly string webRootPath;

        //string for xml document location
        private readonly string xmlDocLocation;
        //static path xml file
        //private const string xmlDocLocation = "D:/ProjList.xml";

        //Load the XML file in XmlDocument.
        private readonly XmlDocument doc = new();

        // object of model ProjectModels
        //private readonly ProjListModel plm;

        private readonly ILogger<HomeController> logger;


        //public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, string contentRootPath, string webRootPath, string xmlDocLocation, XmlDocument doc)

        //home default constructor
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            contentRootPath = _hostEnvironment.ContentRootPath;
            webRootPath = _hostEnvironment.WebRootPath;
            xmlDocLocation = contentRootPath + "/App_data/ProjList.xml";
            //this.contentRootPath = _hostEnvironment.ContentRootPath;
            //this.webRootPath = _hostEnvironment.WebRootPath;
            // 👇 Path.Combine is nor working!
            //this.xmlDocLocation = Path.Combine(contentRootPath, "/App_data/ProjList.xml");
            //this.doc = doc;
            this.logger = logger;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region xmlCRUD
        //following ways not working to get xml doc location
        //private static string GetThisFilePath([CallerFilePath] string path = null)
        //{
        //    return path;
        //}

        //private readonly string xmlDocLocation = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../App_Data/ProjList.xml");

        // object of model ProjectModels
        

        #region GET-Methods
        // GET: Home
        public IActionResult Index()
        {
            //load xml file
            try
            {
                doc.Load(xmlDocLocation);
            }
            catch
            {
                doc.LoadXml("<Projects></Projects>");
                Console.WriteLine(doc);
            }
            doc.Load(xmlDocLocation);

            // object of model ProjListModel
            List<ProjListModel> projList = [];

            if (doc.DocumentElement != null)
            {
                //Loop through the selected Nodes.
                foreach (XmlNode node in doc.DocumentElement.SelectNodes("//Projects//project"))
                {
                    //Fetch the Node values and assign it to Model.
                    projList.Add(new ProjListModel
                    {
                        ProjId = int.Parse(node["Id"].InnerText),
                        ProjName = node["ProjectName"].InnerText,
                        Location = node["Location"].InnerText
                    });
                }
            }

            //This if condition will only true after all project nodes are edded in "projects" list object i.e. should be return after foreach loop is completed
            //Also return that list of node to the Index view
            if (projList.Count > 0)
            {
                return View(projList);
            }
            return View();
        }

        // GET: Home/Edit/5 After getting a single record to edit send it to view
        public ActionResult Edit(int id, ProjListModel plm)
        {
            XDocument xDocument = XDocument.Load(xmlDocLocation);
            var items = (from item in xDocument.Descendants("project")
                         where Convert.ToInt32(item.Element("Id").Value) == id
                         select new ProjectItems
                         {
                             Id = Convert.ToInt32(item.Element("Id").Value),
                             ProjectName = (string)item.Element("ProjectName").Value,
                             Location = (string)item.Element("Location").Value
                         }).SingleOrDefault();
            if (items != null)
            {
                int id1 = items.Id;
                plm.ProjId = id1;
                plm.ProjName = items.ProjectName;
                plm.Location = items.Location;
            }

            return View(plm);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                doc.Load(xmlDocLocation);
                XmlNode RootNode = doc.SelectSingleNode("Projects");
                XmlNodeList projects = RootNode.ChildNodes;

                XmlNode node = projects[0];

                foreach (XmlNode n in projects)
                {
                    //match the selected id and nodes inner text
                    if (int.Parse(n["Id"].InnerText) == id)
                    {
                        node = n;
                    }
                }

                //node.RemoveAll();   //removes nodes inside selected "project"
                RootNode.RemoveChild(node); //removes selected "project" node

                doc.Save(xmlDocLocation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region GET-Post
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            //collection is null
            return collection is null ? throw new ArgumentNullException(nameof(collection)) : (ActionResult)View();
        }

        [HttpPost]
        public ActionResult Update(ProjListModel project, IFormCollection collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            doc.Load(xmlDocLocation);
            XmlNode RootNode = doc.SelectSingleNode("Projects");
            XmlNodeList projects = RootNode.ChildNodes;

            XmlNode node = projects[0];

            foreach (XmlNode ns in projects)
            {
                //match the selected id
                if (ns["Id"].InnerText == project.ProjId.ToString())
                {
                    node = ns;
                }
            }

            //update the node value from new value entered
            node["ProjectName"].InnerText = project.ProjName;
            node["Location"].InnerText = project.Location;
            doc.Save(xmlDocLocation);

            return RedirectToAction("Index");
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(ProjListModel project)
        {
            try
            {
                // insert logic here 👇
                doc.Load(xmlDocLocation);
                XmlNode node = doc.SelectSingleNode("Projects");
                XmlNodeList nodeList = node.ChildNodes;

                //get the last id
                var x = doc.GetElementsByTagName("Id");
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
                        doc.CreateNode(type: XmlNodeType.Element, name: "project", namespaceURI: "")
                    );
                // TODO: Add last incremental Id logic
                newNode.AppendChild(
                        doc.CreateNode(XmlNodeType.Element, "Id", "")
                    ).InnerText = Max.ToString();
                // add project name
                newNode.AppendChild(
                        doc.CreateNode(XmlNodeType.Element, "ProjectName", "")
                    ).InnerText = project.ProjName;
                // add project location
                newNode.AppendChild(
                        doc.CreateNode(XmlNodeType.Element, "Location", "")
                    ).InnerText = project.Location;

                // now save the changes
                doc.Save(xmlDocLocation);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return View();
        }
        #endregion
        #endregion
    }

    internal class ProjectItems
    {
        public int Id { get; set; }
        public required string ProjectName { get; set; }
        public required string Location { get; set; }
    }
}
