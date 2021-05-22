using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Boa.Constrictor.Logging;
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using OpenQA.Selenium.Chrome;
using ScreenPlayPlattern.Interactions;
using FluentAssertions;
using System.IO;
using System.Reflection;

namespace ScreenPlayPlattern
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class LoginFeature
    {
        private IActor actor;
        [SetUp]
        public void InitializeScreenplay()
        {
            actor = new Actor(name: "Harshit", logger: new ConsoleLogger());
            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            actor.Can(BrowseTheWeb.With(new ChromeDriver(directoryName+"\\Drivers")));
            actor.AttemptsTo(Navigate.ToUrl(LoginPage.Url));
            actor.AttemptsTo(MaximizeWindow.ForBrowser());
        }

        [TearDown]
        public void QuitBrowser()
        {
            actor.AttemptsTo(QuitWebDriver.ForBrowser());
        }
        [Test]
        public void TestWithValidCredentials()
        {
            actor.AttemptsTo(Login.For("testplateiq@gmail.com", "test@123"));
            actor.WaitsUntil(Appearance.Of(LoginPage.OTPText), IsEqualTo.True());
        }
        [Test]
        public void TestWithInValidCredentials()
        {
            actor.AttemptsTo(Login.For("testplateiq@gmail.com", "test@456"));
            actor.WaitsUntil(Appearance.Of(LoginPage.ErrorMessageText), IsEqualTo.True());
            actor.AskingFor(Text.Of(LoginPage.ErrorMessageText)).Should().Be("Either Username or Password is incorrect.");
        }
        [Test]
        public void TestWithInValidEmailAddress()
        {
            try
            {
                Wait.Until(Appearance.Of(LoginPage.LoginOrCreateAccuntButton), IsEqualTo.True());
                actor.AttemptsTo(Click.On(LoginPage.LoginOrCreateAccuntButton));
            }
            catch (Exception e)
            {
                actor.AttemptsTo(Click.On(LoginPage.LoginOrCreateAccuntButton2));
            }
            actor.AttemptsTo(SendKeys.To(LoginPage.EmailInput,"testiih123"));
            actor.AttemptsTo(Click.On(LoginPage.ContinueButton));
            actor.WaitsUntil(Appearance.Of(LoginPage.ErrorMessageInvalidUserNamePasswordText), IsEqualTo.True());
            actor.AskingFor(Text.Of(LoginPage.ErrorMessageInvalidUserNamePasswordText)).Should().Be("Please enter a valid Email Id or Mobile Number.");
        }
        [Test]
        public void TestWithInValidPassword()
        {
            actor.AttemptsTo(Login.For("testplateiq@gmail.com", "test"));
            actor.WaitsUntil(Appearance.Of(LoginPage.ErrorMessageInvalidUserNamePasswordText), IsEqualTo.True());
            actor.AskingFor(Text.Of(LoginPage.ErrorMessageInvalidUserNamePasswordText)).Should().Be("Password cannot be less than 6 characters.");
        }

    }
}
