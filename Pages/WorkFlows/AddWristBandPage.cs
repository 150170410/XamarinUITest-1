using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class AddWristBandPage : BasePage
    {
        private const string InvalidCardErrorMessage = "Card Invalid. Tap to fix.";
        private const string DeclinedCardErrorMessage = "Card Declined. Tap to fix.";
        private const string InfoBarAutomationId = "InfoBarAutomationId";
        private const string ValidatingInfobarMessage = "Validating";
        private const string CardValidInfobarMessage = "Card Valid";

        private readonly static Query _connectReader = new Query("RelativeLayout");
        private readonly Lazy<Query> _simulateButton = new Lazy<Query> (() => new Query("BtnSimulateAutomationId"));
        private readonly Lazy<Query> _closeButton = new Lazy<Query>(() => new Query("BtnCloseReaderOverlayAutomationId"));
        private readonly Lazy<Query> _cardValidInfobar = new Lazy<Query>(() => new Query(x => x.Marked(CardValidInfobarMessage)));
        private readonly Lazy<Query> _validateInfobar = new Lazy<Query>(() => new Query(x => x.Marked(ValidatingInfobarMessage)));
        private readonly Lazy<Query> _cardInvalidNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(InvalidCardErrorMessage)));
        private readonly Lazy<Query> _cardDeclinedNavigationInfobar = new Lazy<Query>(() => new Query(x => x.Marked(DeclinedCardErrorMessage)));
        private readonly Lazy<Query> _finishButton = new Lazy<Query>(() => new Query(x => x.Marked("FINISH")));       

        public AddWristBandPage(IApp app) : base(app, "Add Wristband", _connectReader){}

        public AddWristBandPage ClickFinishButton()
        {
            app.Tap(_finishButton.Value);
            return this;
        }

        public AddWristBandPage ClickOnSimulateNFC_RegistrationAndCloseOverlay()
        {
            app.Tap(_simulateButton.Value);
            app.Tap(_closeButton.Value);
            return this;
        }

        public AddWristBandPage ClickOnCardInvalidNavigationLabel()
        {
            ClickOnInfoBarWhichHasMessage(InvalidCardErrorMessage);
            return this;
        }

        public AddWristBandPage ClickOnCardDeclinedNavigationLabel()
        {
            ClickOnInfoBarWhichHasMessage(DeclinedCardErrorMessage);
            return this;
        }

        public AddWristBandPage CloseOverlay()
        {
            app.Tap(_closeButton.Value);
            return this;
        }

        public bool IsFinishButtonVisible()
        {
            var result = app.Query(_finishButton.Value);
            return result.Length > 0;
        }

        private void ClickOnInfoBarWhichHasMessage(string message)
        {
            app.WaitForElement(x => x.Marked(message), "Timeout waiting for InfoBar", DefaultTimeoutForUiElementToRenderInSeconds);
            app.Tap(x => x.Id(InfoBarAutomationId));
        }

        public bool IsValidationCompleted()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ValidatingInfobarMessage), "Timed out waiting for no element", DefaultApiCallTimeout);
                var result = app.Query(_validateInfobar.Value);
                return result.Length == 0;
            }
            catch (TimeoutException e)
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
