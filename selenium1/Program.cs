using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace selenium1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\");
            driver.Navigate().GoToUrl("file:///C:/Users/anil.krishnamaneni/Desktop/New%20Text%20Document.html");

            var coll = driver.FindElements(By.TagName("label"));
            foreach (var label in coll)
            {
                if (label.Text.Trim() == "welcome to Ding")
                {
                    label.Click();
                    break;
                }
            }

            var alert = driver.WaitGetAlert();

            IAlert a = driver.SwitchTo().Alert();
            a.Accept();

            driver.FindElement(By.TagName("Input")).Click();
            a = driver.SwitchTo().Alert();
            a.Accept();
            driver.FindElement(By.ClassName("submit")).Click();
            a = driver.SwitchTo().Alert();
            a.Accept();
        }
    }

    public static class WebExtensions
    {
        public static IAlert WaitGetAlert(this IWebDriver driver, int waitTimeInSeconds = 5)
        {
            IAlert alert = null;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTimeInSeconds));

            try
            {
                alert = wait.Until(d =>
                {
                    try
                    {
                        // Attempt to switch to an alert
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        // Alert not present yet
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                alert = null;
            }

            return alert;
        }
    }
}