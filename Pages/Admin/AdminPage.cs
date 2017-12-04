using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Admin
{
    public class AdminPage : BasePage
    {
        private readonly static Query _environment = new Query(x => x.Id("Environment"));
        private readonly Lazy<Query> _uploadState = new Lazy<Query>(() => new Query(x => x.Id("UploadState")));
        private readonly Lazy<Query> _preparingUpload = new Lazy<Query>(() => new Query(x => x.Id("PreparingUpload")));
        private readonly Lazy<Query> _lastSyncDateTime = new Lazy<Query>(() => new Query(x => x.Id("LastUploadedStateDateTime")));

        public AdminPage(IApp app) : base(app, "Admin Page", _environment)
        {
        }

        public AdminPage ClickEnvironmentMenuItem()
        {
            app.Tap(_environment);
            return this;
        }
    }
}
