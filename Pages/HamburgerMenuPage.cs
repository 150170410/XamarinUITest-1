using System;
using FastBar.Client.Registration.UITest.Pages.Admin;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages
{
    public class HamburgerMenuPage : BasePage
    {
        private readonly static Query _menuPage = new Query(x => x.Marked("NO EVENT SELECTED"));
        private readonly Lazy<Query> _menuButton = new Lazy<Query>(() => new Query(x => x.Marked("ico_slide_menu.png")));
        private readonly Lazy<Query> _logOut = new Lazy<Query>(() => new Query(x => x.Marked("LOGOUT")));
        private readonly Lazy<Query> _admin = new Lazy<Query>(() => new Query(x => x.Marked("ADMIN")));
        private readonly Lazy<Query> _closeOutStation = new Lazy<Query>(() => new Query(x => x.Marked("CLOSE OUT STATION")));
        private readonly Lazy<Query> _selectedEventName = new Lazy<Query>(() => new Query("SelectedEventName"));
        private readonly Lazy<Query> _eventStartTime = new Lazy<Query>(() => new Query("EventStartTime"));
        private readonly Lazy<Query> _closeoutMessage = new Lazy<Query>(() => new Query("CloseOutMessage"));
        private readonly Lazy<Query> _syncDate = new Lazy<Query>(() => new Query("SyncDate"));
        private readonly Lazy<Query> _deviceName = new Lazy<Query>(() => new Query("DeviceName"));
        private readonly Lazy<Query> _userName = new Lazy<Query>(() => new Query("UserName"));
        private readonly Lazy<Query> _serverInfo = new Lazy<Query>(() => new Query("ServerInfo"));
        private readonly Lazy<Query> _bundleId = new Lazy<Query>(() => new Query("BundleId"));
        private readonly Lazy<Query> _version = new Lazy<Query>(() => new Query("Version"));

        public HamburgerMenuPage(IApp app) : base(app, "Hamburger Menu Page", _menuPage)
        {
        }

        public void ClickMenuButton()
        {
            app.Tap(_menuButton.Value);
            Console.WriteLine("Menu button clicked");
        }

        public void ClickLogOut()
        {
            app.Tap(_logOut.Value);
            Console.WriteLine("Logout clicked");
        }

        public AdminLoginPage ClickAdminButton()
        {
            app.Tap(_menuButton.Value);
            app.Tap(_admin.Value);
            Console.WriteLine("Admin Button Clicked");

            return new AdminLoginPage(app);
        }

        public EventPage ClickCloseOutStation()
        {
            app.Tap(_menuButton.Value);
            app.Tap(_closeOutStation.Value);

            return new EventPage(app);
        }

        public string SelectedEventName()
        {
            string selectedEventName = app.Query(_selectedEventName.Value)[0].Text;

            return selectedEventName;
        }

        public string EventStartTime()
        {
            string eventStartTime = app.Query(_eventStartTime.Value)[0].Text;

            return eventStartTime;
        }

        public string CloseOutMessage()
        {
            string _closeOutMessage = app.Query(_closeoutMessage.Value)[0].Text;

            return _closeOutMessage;
        }

        public string SyncDateAndTime()
        {
            string syncDate = app.Query(_syncDate.Value)[0].Text;

            return syncDate;
        }

        public string DeviceName()
        {
            string deviceName = app.Query(_deviceName.Value)[0].Text;

            return deviceName;
        }

        public string UserName()
        {
            string userName = app.Query(_userName.Value)[0].Text;

            return userName;
        }

        public string ServerInfo()
        {
            string serverInfo = app.Query(_serverInfo.Value)[0].Text;

            return serverInfo;
        }

        public string BundleId()
        {
            string bundleId = app.Query(_bundleId.Value)[0].Text;

            return bundleId;
        }

        public string Version()
        {
            string version = app.Query(_version.Value)[0].Text;

            return version;
        }
    }
}