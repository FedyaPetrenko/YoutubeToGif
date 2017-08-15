
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoLibrary;
using NReco.VideoConverter;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = "https://www.youtube.com/watch?v=bDuzU4XLEEs";
            var youTube = YouTube.Default; // starting point for YouTube actions
            var video = youTube.GetVideo(url); // gets a Video object with info about the video
            
            //System.IO.File.WriteAllBytes(@"C:\Downloads\" + video.FullName, video.GetBytes());
            var videoName = @"C:\Downloads\" + video.FullName;
            var ffmpeg = new FFMpegConverter();

            using (System.IO.Stream stream = new System.IO.FileStream(videoName, System.IO.FileMode.Open) )
            {
               
               var result =  ffmpeg.ConvertLiveMedia(stream, Format.mp4, @"C:\Downloads\result2.gif", Format.gif, new ConvertSettings() { VideoFrameRate = 1, MaxDuration = 10 });
                result.Start();
            }
            //ffmpeg.ConvertMedia(videoName, null, @"C:\Downloads\result.gif", null, new ConvertSettings() { VideoFrameRate = 1, MaxDuration = 10 });

            
            


            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}