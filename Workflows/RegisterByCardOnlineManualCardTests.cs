using FastBar.Client.Registration.UITest.Pages;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class RegisterByCardOnlineManualCardTests : BaseTest
    {
        private SwipeCardPage _swipeCardPage;
        public RegisterByCardOnlineManualCardTests(Platform platform) : base(platform) { }

        [SetUp]
        public void Init()
        {
            // Arrange
            SelectWorkFlowPage selectWorkFlowPage = NavigateToSelectWorkflowScreen(TestUsername, TestPin, 3);
            selectWorkFlowPage.ClickSwipeCard();
            SelectPricingPackagePage selectPricingPackage = new SelectPricingPackagePage(app);
            selectPricingPackage.SelectPricingPackage(0);
            _swipeCardPage = new SwipeCardPage(app);
        }

        [Test]
        public void ManualGoodCard_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualCardPage = new ManualCardEntryPage(app);
            manualCardPage.EnterCreditCardNumberInTextBox(TestCreditCardNumber)
                          .EnterExpiryDateInTextBox(TestExpiryDate)
                          .EnterCvvInTextBox(Test3DigitCvv)
                          .TapGoodCvvButton();

            // Assert for PhoneNumverPage
            Assert.IsTrue(manualCardPage.IsNextButtonVisible());

            // Act
            manualCardPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);

            // Assert for validating card
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardValidLabelVisible());

            // Act
            phoneNumberViewPage.EnterPhoneNumberInTextBox(TestPhoneNumber);

            // Assert for PhoneNumberPage
            Assert.IsTrue(phoneNumberViewPage.IsNextButtonVisible());

            // Act
            phoneNumberViewPage.ClickNextButton();
            AddWristBandPage addWristbandPage = new AddWristBandPage(app);
            addWristbandPage.ClickOnSimulateNFC_RegistrationAndCloseOverlay();

            // Assert for AddWristbandPage.
            Assert.IsTrue(addWristbandPage.IsFinishButtonVisible());

            // Act
            addWristbandPage.ClickFinishButton();
            RegistrationCompletedPage registrationCompletedPage = new RegistrationCompletedPage(app);
            registrationCompletedPage.ClickNextAttendeeButton();
            var result = app.WaitForElement(x => x.Marked("btn_swipe_card.png"), "Timeout for waiting SelectWorkflowPage", DefaultTimeoutForUiElementToRenderInSeconds);

            // Assert
            Assert.IsNotEmpty(result);

        }

        [Test]
        public void ManualCardBadCvvAndCompleteWithGoodCvv_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualCardEntryPage = new ManualCardEntryPage(app);
            manualCardEntryPage.EnterCreditCardNumberInTextBox(TestCreditCardNumber)
                               .EnterExpiryDateInTextBox(TestExpiryDate)
                               .EnterCvvInTextBox(Test3DigitCvv)
                               .TapBadCvvButton();

            // Assert for ManualCardEntry Page
            Assert.IsTrue(manualCardEntryPage.IsVisaLogoVisible());
            Assert.IsTrue(manualCardEntryPage.IsNextButtonVisible());

            manualCardEntryPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);

            // Assert for Validation
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardInvalidLabelVisible());
            // Act
            phoneNumberViewPage.ClickOnCvvInvalidLabelAndNavigate();

            // Assert
            Assert.IsTrue(manualCardEntryPage.IsCvvInvalidMessageVisible());

            manualCardEntryPage.EnterCvvInTextBox(Test3DigitCvv)
                               .TapGoodCvvButton();

            // Assert for CvvViewPage
            Assert.IsTrue(manualCardEntryPage.IsNextButtonVisible());

            // Act
            manualCardEntryPage.ClickNextButton();

            // Assert for validating card
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardValidLabelVisible());

            // Act
            phoneNumberViewPage.EnterPhoneNumberInTextBox(TestPhoneNumber);

            // Assert for PhoneNumberPage
            Assert.IsTrue(phoneNumberViewPage.IsNextButtonVisible());

            // Act
            phoneNumberViewPage.ClickNextButton();
            AddWristBandPage addWristbandPage = new AddWristBandPage(app);
            addWristbandPage.ClickOnSimulateNFC_RegistrationAndCloseOverlay();

            // Assert for AddWristbandPage.
            Assert.IsTrue(addWristbandPage.IsFinishButtonVisible());

            // Act
            addWristbandPage.ClickFinishButton();
            RegistrationCompletedPage registrationCompletedPage = new RegistrationCompletedPage(app);
            registrationCompletedPage.ClickNextAttendeeButton();
            var result = app.WaitForElement(x => x.Marked("btn_swipe_card.png"), "Timeout for waiting SelectWorkflowPage", DefaultTimeoutForUiElementToRenderInSeconds);

            // Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void ManualDeclinedCardAndCompleteWithGoodCard_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualCardEntryPage = new ManualCardEntryPage(app);
            manualCardEntryPage.EnterCreditCardNumberInTextBox(TestCreditCardNumber)
                               .EnterExpiryDateInTextBox(TestExpiryDate)
                               .EnterCvvInTextBox(Test3DigitCvv)
                               .TapDeclineCvvButton();

            // Assert for ManualCardEntry Page
            Assert.IsTrue(manualCardEntryPage.IsVisaLogoVisible());
            Assert.IsTrue(manualCardEntryPage.IsNextButtonVisible());

            // Act
            manualCardEntryPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);


            // Assert for Validation
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardDeclinedLabelVisible());

            // Act
            phoneNumberViewPage.ClickOnCardDeclinedLabelAndNavigate();

            // Assert
            Assert.IsTrue(manualCardEntryPage.IsCardDeclinedMessageVisible());

            // Act
            manualCardEntryPage.EnterCreditCardNumberInTextBox(TestCreditCardNumber)
                               .EnterExpiryDateInTextBox(TestExpiryDate)
                               .EnterCvvInTextBox(Test3DigitCvv)
                               .TapGoodCvvButton();


            // Assert for CvvViewPage
            Assert.IsTrue(manualCardEntryPage.IsNextButtonVisible());

            // Act
            manualCardEntryPage.ClickNextButton();

            // Assert for validating card
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardValidLabelVisible());

            // Act
            phoneNumberViewPage.EnterPhoneNumberInTextBox(TestPhoneNumber);

            // Assert for PhoneNumberPage
            Assert.IsTrue(phoneNumberViewPage.IsNextButtonVisible());

            // Act
            phoneNumberViewPage.ClickNextButton();
            AddWristBandPage addWristbandPage = new AddWristBandPage(app);
            addWristbandPage.ClickOnSimulateNFC_RegistrationAndCloseOverlay();

            // Assert for AddWristbandPage.
            Assert.IsTrue(addWristbandPage.IsFinishButtonVisible());

            // Act
            addWristbandPage.ClickFinishButton();
            RegistrationCompletedPage registrationCompletedPage = new RegistrationCompletedPage(app);
            registrationCompletedPage.ClickNextAttendeeButton();
            var result = app.WaitForElement(x => x.Marked("btn_swipe_card.png"), "Timeout for waiting SelectWorkflowPage", DefaultTimeoutForUiElementToRenderInSeconds);

            // Assert
            Assert.IsNotEmpty(result);

        }
    }
}


        




