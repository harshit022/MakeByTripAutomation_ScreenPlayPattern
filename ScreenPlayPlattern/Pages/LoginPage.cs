using Boa.Constrictor.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Boa.Constrictor.WebDriver.WebLocator;
namespace ScreenPlayPlattern.Interactions
{
    public static class LoginPage
    {
        public const string Url = "https://www.makemytrip.com/";

        public static IWebLocator EmailInput => L("Email Address Input",
                                                   By.Id("username"));
        public static IWebLocator LoginOrCreateAccuntButton => L("MakeMyTrip Login Button",
                                                   By.XPath("//label[text()='Login with Phone/Email']"));
        public static IWebLocator LoginOrCreateAccuntButton2 => L("MakeMyTrip Login Button",
                                                    By.XPath("//li[@class='makeFlex hrtlCenter font10 makeRelative lhUser']"));
        public static IWebLocator ContinueButton => L("MakeMyTrip Continue Button",
                                                      By.XPath("//span[normalize-space()='Continue']"));
        public static IWebLocator PasswordInput=> L("MakeMyTrip Password Button",
                                                    By.Id("password"));
        public static IWebLocator LoginButton => L("MakeMyTrip Continue Button",
                                                     By.XPath("//button/span[text()='Login']"));

        public static IWebLocator OTPText => L("MakeMyTrip Succesfully OTP Page Displayed",
                                                    By.XPath("//p[text()='OTP has been sent to EMAIL']"));
        public static IWebLocator ErrorMessageText => L("MakeMyTrip Error Message",
                                                  By.XPath("//span[@data-cy='serverError']"));
        public static IWebLocator ErrorMessageInvalidUserNamePasswordText => L("MakeMyTrip Error Message",
                                          By.XPath("//p[@class='validity font12 redText appendTop5 makeFlex']"));
    }
}
