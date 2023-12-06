using CoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml;
namespace CoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger = logger;

        private readonly IWebHostEnvironment _hostEnvironment;
        // application's base path
        private readonly string contentRootPath;
        // application's publishing path
        private readonly string webRootPath;
        //string for xml document location
        private readonly string xmlDocLocation;
        //private const string xmlDocLocation = "D:/ProjList.xml";
        //Load the XML file in XmlDocument.
        private readonly XmlDocument doc = new();
        private readonly ILogger<HomeController> logger;

        //public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, string contentRootPath, string webRootPath, string xmlDocLocation, XmlDocument doc)
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            contentRootPath = _hostEnvironment.ContentRootPath;
            webRootPath = _hostEnvironment.WebRootPath;
            xmlDocLocation = contentRootPath + "/App_data/ProjList.xml";
            //this.contentRootPath = _hostEnvironment.ContentRootPath;
            //this.webRootPath = _hostEnvironment.WebRootPath;
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
        //private static string GetThisFilePath([CallerFilePath] string path = null)
        //{
        //    return path;
        //}

        //private readonly string xmlDocLocation = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../App_Data/ProjList.xml");


        // object of model ProjectModels
        //readonly ProjListModel plm;

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

            List<ProjListModel> projList = [];

            if (doc.DocumentElement != null)
            {
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

                //Console.WriteLine(doc.DocumentElement.ToString());
                //Loop through the selected Nodes.
                //foreach (XmlNode node in doc.DocumentElement.SelectNodes("//Projects//project"))
                //{
                //    //Fetch the Node values and assign it to Model.
                //    projList.Add(new ProjListModel
                //    {
                //        ProjId = int.Parse(node["Id"].InnerText),
                //        ProjName = node["ProjectName"].InnerText,
                //        Location = node["Location"].InnerText
                //    });
                //}
            }

            //This if condition will only true after all project nodes are edded in "projects" list object i.e. should be return after foreach loop is completed
            //Also return that list of node to the Index view
            if (projList.Count > 0)
            {
                return View(projList);
            }
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
