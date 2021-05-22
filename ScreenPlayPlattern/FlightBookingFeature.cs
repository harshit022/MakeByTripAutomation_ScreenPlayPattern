using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScreenPlayPlattern.Interactions;
using ScreenPlayPlattern.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ScreenPlayPlattern
{
    [Parallelizable(ParallelScope.Fixtures)]
    public  class FlightBookingFeature
    {
        private IActor actor;
        [SetUp]
        public void InitializeScreenplay()
        {
            actor = new Actor(name: "Harshit", logger: new ConsoleLogger());
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            actor.Can(BrowseTheWeb.With(new ChromeDriver(directoryName + "\\Drivers")));
            actor.AttemptsTo(Navigate.ToUrl(LoginPage.Url));
            actor.AttemptsTo(MaximizeWindow.ForBrowser());
        }

        [TearDown]
        public void QuitBrowser()
        {
            actor.AttemptsTo(QuitWebDriver.ForBrowser());
        }
        [Test]
        public void TestFlightBooking()
        {
            DateTime depdateValue = DateTime.Now.AddDays(2);
            string depatureDate = depdateValue.ToString("ddd")+" " + depdateValue.ToString("MMM dd yyyy");
            DateTime returndateValue = DateTime.Now.AddDays(3);
            string returnDate = returndateValue.ToString("ddd")+" "+ returndateValue.ToString("MMM dd yyyy");
            actor.AttemptsTo(FlightBooking.For("Goa", "Mumbai", depatureDate,returnDate,1,1, "Economy"));
            actor.AttemptsTo(Click.On(FlightBookingPage.SearchButton));
            actor.AttemptsTo(Click.On(FlightBookingPage.DepFlight));
            actor.AttemptsTo(Click.On(FlightBookingPage.ReturnFlight));
            Thread.Sleep(3000);
            actor.AttemptsTo(Click.On(FlightBookingPage.BookNowButton));
            actor.AttemptsTo(Click.On(FlightBookingPage.ContinueButton));
            
            actor.AttemptsTo(SwitchWindow.To(actor.AskingFor(WindowHandle.Last())));
            actor.WaitsUntil(Appearance.Of(FlightConfirmationPage.DepartureFlightDetails), IsEqualTo.True());
            actor.WaitsUntil(Appearance.Of(FlightConfirmationPage.ReturnFlightDetails), IsEqualTo.True());

        }
    }
}
