using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using ScreenPlayPlattern.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Boa.Constrictor.WebDriver.WebLocator;
namespace ScreenPlayPlattern.Interactions
{
   public class FlightBooking : ITask
    {
        public string ToCity { get; }
        public string FromCity { get; }

        public string DepatureDate { get; }
        public string ReturnDate { get; }

        public int NoOfAdults { get; }
        public int NoOfChild { get; }
        public string ClassType { get; }

        private FlightBooking(string fromCity, string toCity,string depatureDate,string returnDate,int  noOfAdults, int noOfChild,string classType)
        {
            ToCity = toCity;
            FromCity = fromCity;
            DepatureDate = depatureDate;
            ReturnDate = returnDate;
            NoOfAdults = noOfAdults;
            NoOfChild = noOfChild;
            ClassType = classType;
        }

        public static FlightBooking For(string fromCity, string toCity, string depatureDate, string returnDate, int noOfAdults, int noOfChild, string classType) =>
              new FlightBooking(fromCity, toCity,depatureDate,returnDate,noOfAdults,noOfChild,classType);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(Click.On(FlightBookingPage.FromButton));
            actor.AttemptsTo(Click.On(FlightBookingPage.FromButton));
            actor.AttemptsTo(SendKeys.To(FlightBookingPage.FromInput, FromCity));
            Thread.Sleep(2000);
            actor.AttemptsTo(Click.On(FlightBookingPage.GoaCity));
            actor.AttemptsTo(Click.On(FlightBookingPage.ToButton));
            actor.AttemptsTo(Click.On(FlightBookingPage.ToButton));
            actor.AttemptsTo(SendKeys.To(FlightBookingPage.ToInput, ToCity));
            Thread.Sleep(2000);
            actor.AttemptsTo(Click.On(FlightBookingPage.MumbaiCity));

            actor.AttemptsTo(Click.On(L("DEPARTURE Date",
                            By.XPath("//div[@aria-label='" + DepatureDate + "']//div[@class='dateInnerCell']"))));
            actor.AttemptsTo(Click.On(FlightBookingPage.Return));
            actor.AttemptsTo(Click.On(L("Return Date",
                       By.XPath("//div[@aria-label='" + ReturnDate + "']//div[@class='dateInnerCell']"))));
            actor.AttemptsTo(Click.On(FlightBookingPage.NoOfTravellerAndClass));

            actor.AttemptsTo(Click.On(L("Number OF Adults",
                           By.XPath("//li[@data-cy='adults-"+Convert.ToString(NoOfAdults)+"']"))));
            actor.AttemptsTo(Click.On(L("Number OF Children",
               By.XPath("//li[@data-cy='children-" + Convert.ToString(NoOfChild) + "']"))));
            if(string.Equals(ClassType, "Economy"))
                {
                actor.AttemptsTo(Click.On(FlightBookingPage.EconomyClass));
            }
            actor.AttemptsTo(Click.On(FlightBookingPage.ApplyButton));
        }
    }
}
