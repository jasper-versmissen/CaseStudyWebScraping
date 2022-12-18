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

namespace webscraping
{
    class Program
    {
        private static IWebDriver driver;
        static void Main(string[] args)
        {
            String Searh = "Desktops";
            String url = "https://www.bol.com/nl/nl/s/?searchtext=" + Searh;
            int vcount = 1;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            var discoverButton = driver.FindElement(By.Id("js-first-screen-accept-all-button"));
            discoverButton.Click();
            By elem_artikelen_link = By.ClassName("product-item--row");
            ReadOnlyCollection<IWebElement> artikelen = driver.FindElements(elem_artikelen_link);
            Console.WriteLine("Total number of artikelen in " + url + " are " + artikelen.Count);


            /* Go through the Videos List and scrap the same to get the attributes of the videos in the channel */
            foreach (IWebElement artikel in artikelen)
            {
                if (vcount <= 5)
                {
                    string str_title, str_views, str_prijs;
                    IWebElement elem_artikel_title = artikel.FindElement(By.ClassName("product-title"));
                    str_title = elem_artikel_title.Text;                   

                    IWebElement elem_artikel_prijs = artikel.FindElement(By.ClassName("promo-price"));
                    str_prijs = elem_artikel_prijs.Text;

                    Console.WriteLine("******* Artikel " + vcount + " *******");
                    Console.WriteLine("Title: " + str_title);                    
                    Console.WriteLine("Prijs: " + str_prijs);
                    Console.WriteLine("\n");

                }

                vcount++;
            }






        }
    }
}