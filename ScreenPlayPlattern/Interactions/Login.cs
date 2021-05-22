using Boa.Constrictor.Screenplay;
using Boa.Constrictor.WebDriver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenPlayPlattern.Interactions
{
    public class Login : ITask
    {
        public string Email { get; }
        public string Password { get; }

        private Login(string email, string password)
         { Email = email;
            Password = password;
                }

    public static Login For(string email, string password) =>
          new Login(email,password);

        public void PerformAs(IActor actor)
        {
            try
            {
                Wait.Until(Appearance.Of(LoginPage.LoginOrCreateAccuntButton), IsEqualTo.True());
                actor.AttemptsTo(Click.On(LoginPage.LoginOrCreateAccuntButton));
            }
            catch(Exception e)
            {
                actor.AttemptsTo(Click.On(LoginPage.LoginOrCreateAccuntButton2));
            }
            actor.AttemptsTo(SendKeys.To(LoginPage.EmailInput, Email));
            actor.AttemptsTo(Click.On(LoginPage.ContinueButton));
            actor.AttemptsTo(SendKeys.To(LoginPage.PasswordInput,Password));
            actor.AttemptsTo(Click.On(LoginPage.LoginButton));
        }
    }
}
