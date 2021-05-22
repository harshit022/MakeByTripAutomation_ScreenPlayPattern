using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Boa.Constrictor.WebDriver.WebLocator;
namespace ScreenPlayPlattern.Pages
{
   public class FlightConfirmationPage
    {
        public static IWebLocator DepartureFlightDetails => L("DepartureFlightDetails",
                                         By.XPath("//span[text()='GOI-BOM']"));
        public static IWebLocator ReturnFlightDetails => L("ReturnFlightDetails",
                                        By.XPath("//span[text()='BOM-GOI']"));
    }
}
