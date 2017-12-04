using System;
using FastBar.Client.Registration.UITest.Pages;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture]
    public class BaseTest
    {        
        public const string TestUsername = "demo@getfastbar.com";
        public const string TestPin = "1234";
        public const string TestEmail = "test@getfastbar.com";
        public const string TestPhoneNumber = "4255551111";
        public const string Test3DigitCvv = "123";
        public const string Test4DigitCvvForAmex = "1234";
        public const string TestCreditCardNumber = "4242424242424242";
        public const string TestExpiryDate = "1229";

        public TimeSpan DefaultTimeoutForUiElementToRenderInSeconds => TimeSpan.FromSeconds(UITestConstants.TimeoutForUiElementToRenderInSeconds);
        public TimeSpan DefaultApiCallTimeout => TimeSpan.FromSeconds(Common.Constants.ServiceClientConstants.DefaultTimeoutSeconds);

        protected IApp app;
        protected Platform platform;

        public BaseTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void SetUpApp()
        {            
            iOSAppConfigurator iosconfigurator = ConfigureApp.iOS;

            string appBundlePath = Environment.GetEnvironmentVariable("APP_BUNDLE_PATH");
            if (!string.IsNullOrEmpty(appBundlePath))
            {
                iosconfigurator.AppBundle(appBundlePath);
            }

            string simulatorUDID = Environment.GetEnvironmentVariable("IOS_SIMULATOR_UDID");
            if (!string.IsNullOrEmpty(simulatorUDID))
            {
                iosconfigurator.DeviceIdentifier(simulatorUDID);
            }

            app = iosconfigurator.Debug().EnableLocalScreenshots().StartApp();
        }

        public SelectWorkFlowPage NavigateToSelectWorkflowScreen(string emailAddress = TestUsername, string pin = TestPin, int indexOfTheEventToBeSelect = 1)
        {                   
            try
            {
                app.WaitForElement(x => x.Id("BtnLoginAutomationId"), "timed out", DefaultTimeoutForUiElementToRenderInSeconds);
                LoginPage loginPage = new LoginPage(app);
                loginPage.Login(emailAddress, pin);
                app.WaitForNoElement((x => x.Marked("Logging in...")), "Unable to login", DefaultApiCallTimeout);
            }
            catch (Exception)
            {    
            }

            try
            {
                app.WaitForElement(x => x.Marked("SELECT EVENT"), "timed out", TimeSpan.FromSeconds(3));
                EventPage eventPage = new EventPage(app);
                eventPage.SelectEvent(indexOfTheEventToBeSelect);
                app.WaitForNoElement((x => x.Marked("Processing...")), "Unable to proceed to event", DefaultApiCallTimeout);
            }
            catch (Exception)
            {                
            }

            try
            {
                app.WaitForElement(x => x.Marked("btn_swipe_card.png"), "timed out", DefaultTimeoutForUiElementToRenderInSeconds);
                return new SelectWorkFlowPage(app);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}