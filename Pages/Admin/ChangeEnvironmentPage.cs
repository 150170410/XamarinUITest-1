using Xamarin.UITest;
using System;

namespace FastBar.Client.Registration.UITest.Pages.Admin
{
    public class ChangeEnvironmentPage : BasePage
    {
        private readonly static Query _changeEnvironment = new Query(x => x.Id("ChangeEnvironment"));
        private readonly Lazy<Query> _changeAndLogout = new Lazy<Query>(() => new Query(x => x.Marked("Change and Logout")));
        private readonly Lazy<Query> _cancel = new Lazy<Query>(() => new Query(x => x.Marked("Cancel")));

        public ChangeEnvironmentPage(IApp app) : base(app, "Change Environment Page", _changeEnvironment)
        {
        }
    }
}