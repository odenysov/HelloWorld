using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace HelloWorld
{
    [TestClass]
    public class UnitTest2
    {
        UnitTest1 test = new UnitTest1();

        ChromeDriver driver = new ChromeDriver();
        [TestMethod]
        public void TestMethod2()
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

            Assert.IsTrue(test.IsPresent("//button[@class='btn btn-primary view-project']"));
        }
    }
}
