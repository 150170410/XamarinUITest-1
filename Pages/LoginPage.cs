using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages
{
    public class LoginPage : BasePage
    {
        private readonly static Query _loginbutton = new Query("BtnLoginAutomationId");
        private readonly Lazy<Query> _emailField = new Lazy<Query>(() => new Query("TxtEmailAutomationId"));
        private readonly Lazy<Query> _pinField = new Lazy<Query>(() => new Query("TxtPasswordAutomationId"));
        private readonly Lazy<Query> _qrCodeLogin = new Lazy<Query>(() => new Query("BtnQrCodeLoginAutomationId"));
        private readonly Lazy<Query> _loginPass = new Lazy<Query>(() => new Query(x => x.Marked("ico_login_password.png")));

        public LoginPage(IApp app) : base(app, "LoginPage", _loginbutton)
        {
        }

        public LoginPage Login(string email, string pin)
        {
            app.EnterText(_emailField.Value, email);
            app.EnterText(_pinField.Value, pin);
            app.WaitForElement(x => x.Id("BtnLoginAutomationId"), "Login button not found", TimeSpan.FromSeconds(4));
            app.Tap(_loginbutton);
            return this;
        }
    }
}