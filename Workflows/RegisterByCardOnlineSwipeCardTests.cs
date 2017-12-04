using FastBar.Client.Registration.UITest.Pages;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class RegisterByCardOnlineSwipeCardTests : BaseTest
    {
        private SwipeCardPage _swipeCardPage;
        public RegisterByCardOnlineSwipeCardTests(Platform platform) : base(platform){}

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
        public void GoodSwipe_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickSimulateSwipeButton();

            CvvViewPage cvvViewPage = new CvvViewPage(app);
            cvvViewPage.EnterCvvInTextBox(Test3DigitCvv)
                       .TapGoodCvvButton();

            // Assert for CvvViewPage
            Assert.IsTrue(cvvViewPage.IsNextButtonVisible());

            cvvViewPage.ClickNextButton();
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
        public void BadCvvAndCompleteWithGoodSwipe_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickSimulateSwipeButton();

            CvvViewPage cvvViewPage = new CvvViewPage(app);
            cvvViewPage.EnterCvvInTextBox(Test3DigitCvv)
                       .TapBadCvvButton();

            // Assert for CvvViewPage
            Assert.IsTrue(cvvViewPage.IsNextButtonVisible());

            // Act
            cvvViewPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);

            // Assert for Validation
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardInvalidLabelVisible());
            // Act
            phoneNumberViewPage.ClickOnCvvInvalidLabelAndNavigate();

            // Assert
            Assert.IsTrue(cvvViewPage.IsCvvInvalidMessageVisible());

            cvvViewPage.EnterCvvInTextBox(Test3DigitCvv)
                       .TapGoodCvvButton();
            
            // Assert for CvvViewPage
            Assert.IsTrue(cvvViewPage.IsNextButtonVisible());

            // Act
            cvvViewPage.ClickNextButton();

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
        public void DeclineCardAndCompleteWithGoodCvv_RegistrationWorks()
        {
            // Act
            _swipeCardPage.ClickSimulateSwipeButton();

            CvvViewPage cvvViewPage = new CvvViewPage(app);
            cvvViewPage.EnterCvvInTextBox(Test3DigitCvv)
                       .TapDeclineCvvButton();

            // Assert for CvvViewPage
            Assert.IsTrue(cvvViewPage.IsNextButtonVisible());

            // Act
            cvvViewPage.ClickNextButton();
            PhoneNumberViewPage phoneNumberViewPage = new PhoneNumberViewPage(app);

            // Assert for Validation
            Assert.IsTrue(phoneNumberViewPage.IsValidationCompleted());
            Assert.IsTrue(phoneNumberViewPage.IsCardDeclinedLabelVisible());
            // Act
            phoneNumberViewPage.ClickOnCardDeclinedLabelAndNavigate();

            // Assert
            Assert.IsTrue(cvvViewPage.IsCardDeclinedMessageVisible());

            // Act
            cvvViewPage.ClickTryAnotherCardButton();
            _swipeCardPage.ClickSimulateSwipeButton();
            cvvViewPage.EnterCvvInTextBox(Test3DigitCvv)
                       .TapGoodCvvButton();
            
            // Assert for CvvViewPage
            Assert.IsTrue(cvvViewPage.IsNextButtonVisible());

            // Act
            cvvViewPage.ClickNextButton();

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





