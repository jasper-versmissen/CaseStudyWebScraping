using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.Collections.ObjectModel;
using Pipelines.Sockets.Unofficial.Buffers;
using System.IO;



namespace webscraping
{
    class Program
    {
        private static IWebDriver driver;
        static void Main(string[] args)
        {
            String Search = "mrbeast";
            String url = "https://www.youtube.com/results?search_query=" + Search;
            int vcount = 1;            
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            var discoverButton = driver.FindElement(By.XPath("//*[@id=\"content\"]/div[2]/div[6]/div[1]/ytd-button-renderer[2]/yt-button-shape"));
            discoverButton.Click();
            Thread.Sleep(1000);
            By elem_videos_link = By.Id("dismissible");
            ReadOnlyCollection<IWebElement> videos = driver.FindElements(elem_videos_link);
            Console.WriteLine("Total number of videos in " + url + " are " + videos.Count);
            
            

            /* Go through the Videos List and scrap the same to get the attributes of the videos in the channel */
            foreach (IWebElement video in videos)
            {                
                if (vcount <= 5)
                {
                    string str_title, str_views, str_name;
                    IWebElement elem_video_title = video.FindElement(By.Id("video-title"));
                    str_title = elem_video_title.Text;

                    IWebElement elem_video_views = video.FindElement(By.Id("metadata-line"));
                    str_views = elem_video_views.Text;
                    
                    IWebElement elem_video_name = video.FindElement(By.Id("channel-info"));
                    str_name = elem_video_name.Text;

                    Console.WriteLine("******* Video " + vcount + " *******");
                    Console.WriteLine("Video Title: " + str_title);
                    Console.WriteLine("Video Views: " + str_views + " geupload");                    
                    Console.WriteLine("Channel name: " + str_name);
                    Console.WriteLine("\n");

                    

                }
                
                vcount++;
            }

        }  
    }    
}