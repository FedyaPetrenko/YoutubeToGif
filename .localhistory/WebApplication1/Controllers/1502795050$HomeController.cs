using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = "https://www.youtube.com/watch?v=kIQypcFvGNM";
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(url); // gets a Video object with info about the video

            System.IO.File.WriteAllBytes(@"C:\Downloads\" + video.FullName, video.GetBytes());
            return View();
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