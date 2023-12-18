using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("PostAb")]
        public int PostAb(int a, int b) {
            return a + b;
        }

        [HttpGet("GetAb")]
        public int GetAb(int a, int b)
        {
            return a + b;
        }
        [HttpPost("PostList")]
        public List<string> PostList(string a, string b)
        {
            List<string> ls = new List<string>();
            ls.Add("a");
            ls.Add("b");
            ls.Add("c");
            ls.Add("d");
            return ls;
        }
        [HttpPost("PostUser")]
        public string PostUser([FromBody] User user)
        {
            return JsonConvert.SerializeObject(user);
        }
        //[HttpPost("upload2")]
        //public string UploadFile2([FromForm] IFormFile file)
        //{
        //    if (file != null)
        //    {
        //        var fileDir = "D://picture/";
        //        if (!Directory.Exists(fileDir))
        //        {
        //            Directory.CreateDirectory(fileDir);
        //        }
        //        //上传的文件的路径
        //        string filePath = fileDir + file.FileName;
        //        using (var fs = System.IO.File.Create(filePath))
        //        {
        //            file.CopyTo(fs);
        //        }
        //        return "上传成功";
        //    }
        //    else
        //    {
        //        return "上传失败";
        //    }
        //}
        #region 文件上传  可以带参数
        [HttpPost("upload")]
        public string uploadProject(IFormFile file, string userId)
        {
            if (file != null)
            {
                var fileDir = "D:\\aaa";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                //文件名称
                string projectFileName = file.FileName;

                //上传的文件的路径
                string filePath = fileDir + $@"\{projectFileName}";
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                return JsonConvert.SerializeObject("ok");
            }
            else
            {
                return JsonConvert.SerializeObject("no");
            }
        }
        #endregion
        #region 文件上传  可以带参数
        [HttpPost("uploads")]
        public string uploadProjects(List<IFormFile> files, string userId)
        {
            if(files.Count> 0)
            {
                var fileDir = "D:\\aaa";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                //文件名称
                foreach (IFormFile file in files)
                {
                    string projectFileName = file.FileName;
                    //上传的文件的路径
                    string filePath = fileDir + $@"\{projectFileName}";
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }
                return JsonConvert.SerializeObject("ok");
            }
            else
            {
                return JsonConvert.SerializeObject("no");
            }
        }
        #endregion
        [HttpGet("Chart")]
        public string Chart(int ID)
        {
            int[] tt = [30, 40, 50, 60, 70, 80];
            return JsonConvert.SerializeObject(tt);
        }
        [HttpPost("PostForm")]
        public string PostForm([FromBody] dynamic ob)
        {
            User user =new User();
            user.userName = "test";
            user.password = "123456";

            return JsonConvert.SerializeObject(user);
        }

    }
    public class User {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class Student { 
        public string name { get; set; }
        public int age { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
    
    }
   
   


}

