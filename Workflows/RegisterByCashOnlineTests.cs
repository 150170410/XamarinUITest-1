using FastBar.Client.Registration.UITest.Pages;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class RegisterByCashOnlineTests : BaseTest
    {
        private LoadCashViewPage _loadCashViewPage;
        public RegisterByCashOnlineTests(Platform platform) : base(platform)
        {
        }

        [SetUp]
        public void Init()
        {
            // Arrange
            SelectWorkFlowPage selectWorkFlowPage = NavigateToSelectWorkflowScreen(TestUsername, TestPin, 3);
            selectWorkFlowPage.ClickLoadCash();
            SelectPricingPackagePage selectPricingPackage = new SelectPricingPackagePage(app);
            selectPricingPackage.SelectPricingPackage(0);
            _loadCashViewPage = new LoadCashViewPage(app);
        }

        [Test]
        public void LoadCash_RegistrationWorks()
        {
            // Act

            // Act
            _loadCashViewPage.EnterAmount(100);

            // Assert For LoadCashPage
            Assert.IsTrue(_loadCashViewPage.IsNextButtonVisible());

            _loadCashViewPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);
            phoneNumberViewPage.EnterPhoneNumberInTextBox(TestPhoneNumber);

            // Assert for PhoneNumberPage
            Assert.IsTrue(phoneNumberViewPage.IsNextButtonVisible());

            phoneNumberViewPage.ClickNextButton();
            AddWristBandPage addWristbandPage = new AddWristBandPage(app);
            addWristbandPage.ClickOnSimulateNFC_RegistrationAndCloseOverlay();

            // Assert for AddWristbandPage.
            Assert.IsTrue(addWristbandPage.IsFinishButtonVisible());

            addWristbandPage.ClickFinishButton();
            RegistrationCompletedPage registrationCompletedPage = new RegistrationCompletedPage(app);
            registrationCompletedPage.ClickNextAttendeeButton();
            var result = app.WaitForElement(x => x.Marked("btn_swipe_card.png"), "Timeout for waiting SelectWorkflowPage", DefaultTimeoutForUiElementToRenderInSeconds);

            // Assert
            Assert.IsNotEmpty(result);
        }
    }
}