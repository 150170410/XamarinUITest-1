using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class PhoneNumberViewPage : BasePage
    {
        private const string InvalidCardErrorMessage = "Card Invalid. Tap to fix.";
        private const string DeclinedCardErrorMessage = "Card Declined. Tap to fix.";
        private const string ValidatingInfobarMessage = "Validating";
        private const string CardValidInfobarMessage = "Card Valid";

        private readonly static Query _phoneNumberTextbox = new Query("TxtPhone");
        private readonly Lazy<Query> _nextButton = new Lazy<Query>(() => new Query(x => x.Marked("NEXT")));
        private readonly Lazy<Query> _skipButton = new Lazy<Query>(() => new Query(x => x.Marked("SKIP")));
        private readonly Lazy<Query> _clickBackButton = new Lazy<Query>(() => new Query(x => x.Id("ico_header_back.png")));
        private readonly Lazy<Query> _cardValidInfobar = new Lazy<Query>(() => new Query(x => x.Marked(CardValidInfobarMessage)));
        private readonly Lazy<Query> _validateInfobar = new Lazy<Query>(() => new Query(x => x.Marked(ValidatingInfobarMessage)));
        private readonly Lazy<Query> _cardInvalidNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(InvalidCardErrorMessage)));
        private readonly Lazy<Query> _cardDeclinedNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(DeclinedCardErrorMessage)));

        public PhoneNumberViewPage(IApp app) : base(app, "Phone Number View", _phoneNumberTextbox) { }

        public PhoneNumberViewPage EnterPhoneNumberAndMoveNext(string _number)
        {
            app.EnterText(_phoneNumberTextbox, _number);
            app.Tap(_nextButton.Value);
            return this;
        }

        public PhoneNumberViewPage EnterPhoneNumberInTextBox(string _number)
        {
            app.EnterText(_phoneNumberTextbox, _number);
            return this;
        }

        public PhoneNumberViewPage ClickNextButton()
        {
            app.Tap(_nextButton.Value);
            return this;
        }

        public PhoneNumberViewPage ClickOnSkipPhoneNumberButton()
        {
            app.Tap(_skipButton.Value);
            return this;
        }

        public PhoneNumberViewPage ClickOnCvvInvalidLabelAndNavigate()
        {
            app.Tap(_cardInvalidNavigationInfobar.Value);
            return this;
        }

        public PhoneNumberViewPage ClickOnCardDeclinedLabelAndNavigate()
        {
            app.Tap(_cardDeclinedNavigationInfobar.Value);
            return this;
        }

        public PhoneNumberViewPage ClickBackButton()
        {
            app.Tap(_clickBackButton.Value);
            return this;
        }

        public bool IsSkipButtonVisible()
        {
            var result = app.Query(_skipButton.Value);
            return result.Length > 0;
        }

        public bool IsNextButtonVisible()
        {
            var result = app.Query(_nextButton.Value);
            return result.Length > 0;
        }

        public bool IsValidationCompleted()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ValidatingInfobarMessage), "Timed out waiting for no element", DefaultApiCallTimeout);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsValidationLabelVisible()
        {
            app.WaitForElement(x => x.Marked(ValidatingInfobarMessage), "Timed Out", DefaultTimeoutForUiElementToRenderInSeconds);
            var result = app.Query(_validateInfobar.Value);
            return result.Length > 0;
        }

        public bool IsCardValidLabelVisible()
        {
            app.WaitForElement(x => x.Marked(CardValidInfobarMessage), "Timed Out", TimeSpan.FromSeconds(5));
            var result = app.Query(_cardValidInfobar.Value);
            return result.Length > 0;
        }

        public bool IsCardInvalidLabelVisible()
        {
            app.WaitForElement(x => x.Marked(InvalidCardErrorMessage), "Timed Out", TimeSpan.FromSeconds(3));
            var result = app.Query(_cardInvalidNavigationInfobar.Value);
            return result.Length > 0;
        }

        public bool IsCardDeclinedLabelVisible()
        {
            app.WaitForElement(x => x.Marked(DeclinedCardErrorMessage), "Timed Out", TimeSpan.FromSeconds(3));
            var result = app.Query(_cardDeclinedNavigationInfobar.Value);
            return result.Length > 0;
        }
    }
}
