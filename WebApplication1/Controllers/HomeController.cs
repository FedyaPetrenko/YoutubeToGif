
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
            //Download Video From Youtube
            string url = "https://www.youtube.com/watch?v=bDuzU4XLEEs";
            var youTube = YouTube.Default;
            var video = youTube.GetVideo(url);
            //------------
            //Save Video
            //System.IO.File.WriteAllBytes(@"C:\Downloads\" + video.FullName, video.GetBytes());


           

            var ffmpeg = new FFMpegConverter();

            using (System.IO.Stream stream = new System.IO.MemoryStream(video.GetBytes(), 0, video.GetBytes().Length))
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(stream);
   //             sw.Write(video.GetBytes(), 0, video.GetBytes().Length);

               var result = ffmpeg.ConvertLiveMedia(stream, Format.mp4, @"C:\Downloads\result2.gif", Format.gif, new ConvertSettings() { VideoFrameRate = 1, MaxDuration = 10 });
               result.Start();

            }

            //var videoName = @"C:\Downloads\" + video.FullName;
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