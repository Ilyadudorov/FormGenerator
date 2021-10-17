using FormGenerator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FormGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Form formresult;

        public string tmp;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(List<IFormFile> files)
        {

            //if (files == null)
            //{
            //    return Ok("NULL");
            //}

            //using (StreamReader st = new StreamReader())
            //{

            //}

            //var filePaths = Path.GetFullPath(files);
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            tmp = filePaths.ToString();
            return Ok(new { count = files.Count, size, filePaths });
            //return Ok(filePaths);

        }

        public IActionResult Result()
        {
            //using (StreamReader r = new StreamReader("C:\\Users\\User\\Desktop\\formjson.json"))
            //{
            //    string json = r.ReadToEnd();
            //    formresult = JsonConvert.DeserializeObject<Form>("C:\\Users\\User\\Desktop\\formjson.json");
            //}
            //return View(formresult);
            

            formresult = JsonConvert.DeserializeObject<Form>("C:\\Users\\User\\Desktop\\formjson.json");

            return View(formresult);
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
    }
}
