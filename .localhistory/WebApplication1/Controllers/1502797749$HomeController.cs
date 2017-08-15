using NReco.VideoConverter;
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
            var videoName = @"C:\Downloads\" + video.FullName;
            var ffmpeg = new NReco.VideoConverter.FFMpegConverter();
            
            ffmpeg.ConvertMedia(videoName, null, @"C:\Downloads\result.gif", null, new ConvertSettings() { MaxDuration = 10 });
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