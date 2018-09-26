using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelloWorld
{
    [TestClass]
    public class UnitTest1
    {
        ChromeDriver driver = new ChromeDriver();
        [TestMethod]
        public void TestMethod1()
        {
            
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("https://perf.exalinkservices.com/auth/?redirect=https%3A%2F%2Fperf.exalinkservices.com%2Fcalcs%2F%23%2Fprojects");

            var login = driver.FindElementById("username");
            var password = driver.FindElementByXPath("//input[@placeholder = 'Password']");
            var logIn = driver.FindElementByXPath("//button[@class = 'btn btn-block']");

            login.SendKeys("jack");
            password.SendKeys("Dummy#123");

            logIn.Click();


            driver.FindElementByXPath("//button[@id='clients']").Click();
            driver.FindElementByXPath("//span[text()='Medicines']").Click();

            Assert.IsTrue(IsPresent("//button[@class='btn btn-primary view-project']"));


            driver.FindElementByXPath("//button[@id = 'nav-item-data']").Click(); //Data Page
            driver.FindElementByXPath("//td[@class = 'cell-success']").Click();//first row in grid


            var buttonView = driver.FindElementByXPath("//button[@ng-click = 'ctrl.viewData()']");

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//button[@ng-click = 'ctrl.viewData()']"));

            foreach (IWebElement element in elements)
            {
                if (element.Displayed)
                {
                    buttonView = element;
                    break;
                }
            }

            buttonView.Click();

            Assert.IsTrue(IsPresent("//div[@class='ag-body-viewport']"));

            driver.Navigate().Back();

            driver.FindElementByXPath("//a[contains(. , 'Domain')]").Click();

            

            buttonView.Click();

            Assert.IsTrue(IsPresent("//div[@class='ag-body-viewport']"));


        }
        public bool IsPresent(string path)
        {
            bool present;
            try {
                driver.FindElementByXPath(path);
                present = true;
            }
            catch (NoSuchElementException)
            {
                present = false;
            }
            return present;
        }
    }
}
