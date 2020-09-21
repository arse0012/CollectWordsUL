using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CollectWordsUL
{
    [TestClass]
    public class CollectWordsTests
    {
        private static readonly string DriverDirectory = "C:\\Users\\seleniumDrivers";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("Collect words app",_driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("inputField"));
            inputElement.SendKeys("Way");

            IWebElement saveButtonElement = _driver.FindElement(By.Id("saveButton"));
            saveButtonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("outputField"));
            string text = outputElement.Text;

            Assert.AreEqual("Way",text);
        }
    }
}
