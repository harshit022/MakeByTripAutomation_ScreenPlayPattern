using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Boa.Constrictor.WebDriver.WebLocator;

namespace ScreenPlayPlattern.Pages
{
   public class FlightBookingPage
    {
        public static IWebLocator FromInput => L("From Field",
                                                 By.XPath("//input[@placeholder='From']"));
        public static IWebLocator FromButton=> L("From Field",
                                              By.XPath("//input[@id='fromCity']"));
        public static IWebLocator GoaCity => L("From Field",
                                           By.XPath("//p[normalize-space()='Goa, India']"));
        public static IWebLocator ToInput => L("From Field",
                                                By.XPath("//input[@placeholder='To']"));
        public static IWebLocator ToButton => L("From Field",
                                              By.XPath("//input[@id='toCity']"));
        public static IWebLocator MumbaiCity => L("From Field",
                                    By.XPath("//p[normalize-space()='Mumbai, India']"));
        public static IWebLocator Return => L("RETURN",
                            By.XPath("//span[normalize-space()='RETURN']"));
        public static IWebLocator NoOfTravellerAndClass => L("NoOfTravellerAndClass",
                     By.XPath("//span[normalize-space()='Travellers & CLASS']"));
        public static IWebLocator EconomyClass => L("EconomyClass",
                    By.XPath("//li[normalize-space()='Economy/Premium Economy']"));
        public static IWebLocator ApplyButton => L("ApplyButton",
               By.XPath("//button[normalize-space()='APPLY']"));
        public static IWebLocator SearchButton => L("SearchButton",
               By.XPath("//a[normalize-space()='Search']"));

        public static IWebLocator DepFlight => L("DepFlight",
               By.XPath("(//div[@class='paneView'][1]//label[starts-with(@class,'splitViewListing ')]/descendant::span[@class='outer'])[2]"));
        public static IWebLocator ReturnFlight => L("ReturnFlight",
       By.XPath("(//div[@class='paneView'][2]//label[starts-with(@class,'splitViewListing ')]/descendant::span[@class='outer'])[2]"));
        public static IWebLocator BookNowButton => L("BookNowButton",
       By.XPath("//button[normalize-space()='Book Now']"));
        public static IWebLocator ContinueButton => L("MakeMyTrip Continue Button",
                                              By.XPath("//button[normalize-space()='Continue']"));

    }
}
