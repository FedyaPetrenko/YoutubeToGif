using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary;
using NReco;

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
            var ffmpeg = new NReco.VideoConverter.FFMpegConverter();
            new NReco.V
            ffmpeg.ConvertMedia("your_clip.mp4", null, "result.gif", null, new ConvertSettings());
            return View();
        }

        public ActionResult About()
        {
            string url = "https://www.youtube.com/watch?v=kIQypcFvGNM";
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(url); // gets a Video object with info about the video

            System.IO.File.WriteAllBytes(@"C:\Downloads\" + video.FullName, video.GetBytes());

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}