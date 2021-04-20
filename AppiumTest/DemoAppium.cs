using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Assert = NUnit.Framework.Assert;

namespace AppiumTest
{
    [TestFixture]
    public class DemoAppium
    {

        //AndroidDriver<AndroidElement> driver;


        //Creating Appium instance
        public AndroidDriver<AndroidElement> driver;
        DesiredCapabilities cap;
        IWebDriver webdriver;

        [SetUp]
        public void InitDriver()
        {
            cap = new DesiredCapabilities();

            //For Emulator
            /*cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "MyDevice");
            cap.SetCapability("appPackage", "com.android.calculator2");
            cap.SetCapability("appActivity", "com.android.calculator2.Calculator");*/

            // For real device
            /* cap.SetCapability("platformName", "Android");
             cap.SetCapability("platformVersion", "8.1.0");
             cap.SetCapability("deviceName", "Abhishek");
             cap.SetCapability("appPackage", "com.miui.calculator");
             cap.SetCapability("appActivity", "com.miui.calculator.cal.CalculatorActivity"); */

             //For blackberry access
             //cap.SetCapability("platformName", "Android");
             //cap.SetCapability("platformVersion", "8.1.0");
             //cap.SetCapability("deviceName", "Abhishek");
             //cap.SetCapability("appPackage", "com.good.gdgma");
             //cap.SetCapability("appActivity", "com.good.chrome.gdgma.gd.LaunchActivity");           




            //driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
        }

        [Test]
        public void DemoTest()
        {
            Assert.IsNotNull(driver);

            driver.FindElement(By.Id("com.android.calculator2:id/digit_2")).Click();
            Thread.Sleep(1000);

            driver.FindElementByAccessibilityId("plus").Click();
            //driver.FindElement(By.Id("com.android.calculator2:id/op_add")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("com.android.calculator2:id/digit_2")).Click();
            Thread.Sleep(1000);

            driver.FindElementByAccessibilityId("equals").Click();

            //driver.FindElement(By.Id("com.android.calculator2:id/eq")).Click();
            Thread.Sleep(1000);

            string result = driver.FindElement(By.Id("com.android.calculator2:id/formula")).GetAttribute("text");
            Thread.Sleep(1000);

            Assert.AreEqual("4", result);
        }

        [Test]
        public void DemoPegTest()
        {
            Assert.IsNotNull(driver);

            driver.FindElement(By.Id("com.android.calculator2:id/digit_2")).Click();
            Thread.Sleep(1000);
        }


        [Test]
        public void SeleniumTest()
        {
            ChromeOptions chromeCapabilities = new ChromeOptions();
            chromeCapabilities.AddArguments("start-maximized");
            //chromeCapabilities.EnableMobileEmulation("Pixel 2");
            chromeCapabilities.EnableMobileEmulation("iPhone 8");
            webdriver = new ChromeDriver(chromeCapabilities);
            webdriver.Url = "https://www.bain.com";
            webdriver.Navigate();

            Thread.Sleep(2000);
            webdriver.FindElement(By.XPath("(.//*[@class='site-message__close'])[1]/a[1]")).Click();
            Thread.Sleep(1000);
            webdriver.FindElement(By.Id("js-hamburger-btn")).Click();
            Thread.Sleep(1000);
            webdriver.FindElement(By.LinkText("Industries")).Click();
            Thread.Sleep(1000);
            webdriver.FindElement(By.LinkText("Advanced Manufacturing & Services")).Click();
            Thread.Sleep(1000);
            string title = webdriver.FindElement(By.XPath(".//*[starts-with(@class,'showMobileTitle hero')]")).Text;
            Assert.AreEqual("Advanced Manufacturing & Services", title);
        }


        [TearDown]
        public void close()
        {
           // driver.Quit();
            webdriver.Quit();
        }

    }
}
