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

            String url = "https://www.ictjob.be/nl/";
            int vcount = 1;
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            var element = driver.FindElement(By.XPath("//*[@id=\"keywords-input\"]"));
            element.SendKeys("IT");
            element.Submit();
            By elem_job_link = By.ClassName("job-info");
            ReadOnlyCollection<IWebElement> jobs = driver.FindElements(elem_job_link);
            Console.WriteLine("Total number of jobs in " + url + " are " + jobs.Count);



            foreach (IWebElement job in jobs)
            {
                if (vcount <= 5)
                {
                    string str_title, str_views, str_rel, str_link;
                    IWebElement elem_job_title = job.FindElement(By.ClassName("job-title"));
                    str_title = elem_job_title.Text;

                    IWebElement elem_job_name = job.FindElement(By.ClassName("job-company"));
                    str_views = elem_job_name.Text;

                    IWebElement elem_job_details = job.FindElement(By.ClassName("job-details"));
                    str_rel = elem_job_details.Text;

                    IWebElement elem_job_links = job.FindElement(By.ClassName("search-item-link"));
                    str_link = elem_job_links.Text;


                    Console.WriteLine("******* Job " + vcount + " *******");
                    Console.WriteLine("Job Title: " + str_title);
                    Console.WriteLine("Company: " + str_views);
                    Console.WriteLine("Details: " + str_rel);
                    Console.WriteLine("link: " + str_link);
                    Console.WriteLine("\n");

                }
                
                vcount++;
            }



        }
    }
}