using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;

namespace UI_Automation_Demo.Properties
{
    public static class Methond
    {
        private static IWebDriver driver;

        public static void addProducttotheCart()
        {
            var service = EdgeDriverService.CreateDefaultService(
                driverPath: @"C:\Driver",
                driverExecutableFileName: "msedgedriver.exe"
            );


            driver = new EdgeDriver( service );

            driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com");
            driver.Manage().Window.Maximize();
            

            //Add HP ZBook 17 G2 Mobile Workstation
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.Laptops);
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.LAPTOPS.HPZbook);
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.LAPTOPS.HPZbook_Gray);

            Xpath.LAPTOPS Lap = new Xpath.LAPTOPS();
            Lap.Number = 1;
            string aa = driver.FindElement(By.XPath(Xpath.LAPTOPS.PriceXpath)).Text;
            Lap.Price = double.Parse(aa);
            Lap.TotalPrice = Lap.Number * Lap.Price;

            ClickElement(driver, Xpath.btnAddtoCart);
            ClickElement(driver, Xpath.homePage);

            //Add HP Z8000 BLUETOOTH MOUSE
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.Mice);
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.MicePage.Z8000);
            System.Threading.Thread.Sleep(10000);

            IWebElement quan =  driver.FindElement(By.XPath(Xpath.MicePage.Quantity));
            quan.Clear();
            quan.SendKeys("2");

            Xpath.MicePage mice = new Xpath.MicePage();
            mice.Number = 2;
            mice.Price = double.Parse(driver.FindElement(By.XPath(Xpath.MicePage.PriceXpath)).Text);
            mice.TotalPrice = mice.Number * mice.Price;

            ClickElement(driver, Xpath.btnAddtoCart);
            ClickElement(driver, Xpath.homePage);

            //Add  HP ELITE X2 1011 G1 TABLET

            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.Tablets);
            System.Threading.Thread.Sleep(10000);
            ClickElement(driver, Xpath.TabletsPage.HPElite);
            System.Threading.Thread.Sleep(10000);

            Xpath.TabletsPage tablet = new Xpath.TabletsPage();
            tablet.Number = 1;
            tablet.Price = double.Parse(driver.FindElement(By.XPath(Xpath.TabletsPage.PriceXpath)).Text);
            tablet.TotalPrice = tablet.Number * tablet.Price;

            ClickElement(driver, Xpath.btnAddtoCart);


            // Go to Cart 
            ClickElement(driver, Xpath.MenuCart);
            System.Threading.Thread.Sleep(10000);

            double totalPrice = double.Parse( driver.FindElement(By.XPath(Xpath.TotalPriceInCart)).Text);

            if (totalPrice != (Lap.TotalPrice + mice.TotalPrice + tablet.TotalPrice)) {
                throw new Exception("Total price not equal");
            }
        }

        public static void ClickElement(IWebDriver driver, string xpath) {
            IWebElement btnElement = driver.FindElement(By.XPath(xpath));
            btnElement.Click();

        }




 
    }

    public static class Xpath {
        public const string Laptops = "//div[@id='laptopsImg']";
        public const string Mice = "//div[@id='miceImg']"; 
        public const string Tablets = "//div[@id='tabletsImg']";
        public const string homePage = "//a[@href='#/']";
        public const string MenuCart = "//a[@id='shoppingCartLink']";
        public const string TotalPriceInCart = "//div[@id='shoppingCart']//span[contains(text(),'TOTAL')]/../span[2]";
        public class LAPTOPS {
            public const string HPZbook = "//a[contains(text(),'HP ZBook 17 G2 Mobile Workstation')]";
            public const string HPZbook_Gray = "//span[@title='GRAY']";

            public const string PriceXpath = "//div[@id='Description']/h2"; 


            public double Price{get;set;}
            public int Number { get; set; }

            public double TotalPrice { get; set; }


        }

        public class MicePage
        {
            public const string Z8000 = "//a[contains(text(),'HP Z8000 Bluetooth Mouse')]";
            public const string Quantity = "//input[@name='quantity']";

            public const string PriceXpath = "//div[@id='Description']/h2";

            public double Price { get; set; }
            public int Number { get; set; }

            public double TotalPrice { get; set; }

        }

        public class TabletsPage
        {
            public const string HPElite = "//a[contains(text(),'HP Elite x2 1011 G1 Tablet')]";
            public const string Quantity = "//input[@name='quantity']";
            public const string PriceXpath = "//div[@id='Description']/h2";
            public double Price { get; set; }
            public int Number { get; set; }

            public double TotalPrice { get; set; }
        }

        public const string btnAddtoCart = "//button[@name='save_to_cart']";
        

    }
}
