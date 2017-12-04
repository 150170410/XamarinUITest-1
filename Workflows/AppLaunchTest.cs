using NUnit.Framework;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class AppLaunchTest : BaseTest
    {
        public AppLaunchTest(Platform platform) : base(platform){}

        [Test]
        public void AppLaunches()
        {
            app.WaitForElement(e => e.All());
            app.Screenshot("App Launched");
        }
    }
}