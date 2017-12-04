using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class OptInEmailPage : BasePage
    {
        private const string InvalidCardErrorMessage = "Card Invalid. Tap to fix.";
        private const string DeclinedCardErrorMessage = "Card Declined. Tap to fix.";
        private const string ValidatingInfobarMessage = "Validating";
        private const string CardValidInfovarMessage = "Card Valid";

        private readonly static Query _emailTextbox = new Query("TxtEmail");
        private readonly Lazy<Query> _skipButton = new Lazy<Query>(() => new Query(x => x.Marked("SKIP")));
        private readonly Lazy<Query> _nextButton = new Lazy<Query>(() => new Query(x => x.Marked("NEXT")));
        private readonly Lazy<Query> _cardValidInfobar = new Lazy<Query>(() => new Query(x => x.Marked(CardValidInfovarMessage)));
        private readonly Lazy<Query> _validateInfobar = new Lazy<Query>(() => new Query(x => x.Marked(ValidatingInfobarMessage)));
        private readonly Lazy<Query> _cardInvalidNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(InvalidCardErrorMessage)));
        private readonly Lazy<Query> _cardDeclinedNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(DeclinedCardErrorMessage)));

        public OptInEmailPage(IApp app) : base(app, "Email Optin", _emailTextbox){}

        public OptInEmailPage EnterEmailAndMoveNext(string email)
        {
            app.EnterText(_emailTextbox, email);
            app.Tap(_nextButton.Value);
            return this;
        }

        public OptInEmailPage EnterEmailInTextBox(string email)
        {
            app.EnterText(_emailTextbox, email);
            return this;
        }

        public OptInEmailPage ClickNextButton()
        {
            app.Tap(_nextButton.Value);
            return this;
        }

        public OptInEmailPage ClickOnSkipEmailButton()
        {
            app.Tap(_skipButton.Value);
            return this;
        }

        public OptInEmailPage CardInvalidNavigation()
        {
            app.WaitForElement(x => x.Marked(InvalidCardErrorMessage));
            app.Tap(_cardInvalidNavigationInfobar.Value);
            return this;
        }

        public OptInEmailPage CardDeclinedNavigation()
        {
            app.WaitForElement(x => x.Marked(DeclinedCardErrorMessage));
            app.Tap(_cardDeclinedNavigationInfobar.Value);
            return this;
        }

        public bool IsNextButtonVisible()
        {
            var result = app.Query(_nextButton.Value);
            return result.Length > 0;
        }

        public bool IsSkipButtonVisible()
        {
            var result = app.Query(_skipButton.Value);
            return result.Length > 0;
        }

        public bool IsValidationCompleted()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ValidatingInfobarMessage), "Timed out waiting for no element", DefaultApiCallTimeout);
                var result = app.Query(_validateInfobar.Value);
                return result.Length == 0;
            }
            catch
            {
                return false;
            }
        }

        public bool IsCardValidatedLabelVisible()
        {
            var result = app.Query(_cardValidInfobar.Value);
            return result.Length > 0;
        }
    }
}
