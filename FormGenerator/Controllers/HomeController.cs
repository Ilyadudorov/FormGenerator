using FormGenerator.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace FormGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        IWebHostEnvironment hostEnv;


        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment env)
        {
            _logger = logger;
            hostEnv = env;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public Form DataDisplay(string path)
        {
            var webClient = new WebClient();
            var jsonstring = webClient.DownloadString(path);
            System.IO.File.Delete(path);
            JObject json = JObject.Parse(jsonstring);
            var result = JsonConvert.DeserializeObject<Form>(json["form"].ToString());
            return result;
        }

        [HttpPost]
        public IActionResult Postmessage(Form form)
        {
            return View("Postmessage",form);
        }

        public IActionResult FileUpload(IFormFile file)
        {
            var dir = hostEnv.ContentRootPath + "\\Uploadjson";
            using (var fs = new FileStream(Path.Combine(dir, file.FileName), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            return View("result", DataDisplay(Path.Combine(dir, file.FileName)));
        }
    }
}
