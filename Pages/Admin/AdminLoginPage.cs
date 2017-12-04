using Xamarin.UITest;
using System;

namespace FastBar.Client.Registration.UITest.Pages.Admin
{
    public class AdminLoginPage : BasePage
    {
        private readonly static Query _adminPin = new Query(x => x.Id("AdminPin"));
        private readonly Lazy<Query> _adminLogin = new Lazy<Query>(() => new Query(x => x.Id("AdminLogin")));

        public AdminLoginPage(IApp app) : base(app, "Admin Login Page", _adminPin)
        {
        }

        public AdminLoginPage AdminLogin(string pin)
        {
            app.EnterText(_adminPin, pin);
            app.Tap(_adminLogin.Value);
            return this;
        }
    }
}