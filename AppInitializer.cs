using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace FastBar.Client.Registration.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.iOS)
            {
                return ConfigureApp
                       .iOS
                       .AppBundle("/../../../../FastBar.Client.Registration/iOS/bin/iPhoneSimulator/Debug/device-builds/iphone9.1-10.2/FastBarRegistration.app")
                       .DeviceIdentifier("4733bd4271201a44ffac614a2fe4cf5b2fbba83e")
                       //.DeviceIdentifier("5B97B1AA-308E-44E8-9477-DAB67091B31F")
                       .EnableLocalScreenshots()
                       .PreferIdeSettings()
                    .StartApp(AppDataMode.Clear);
            }
            else
            {
                return ConfigureApp
                    .Android
                    .StartApp();
            }
        }
    }
}