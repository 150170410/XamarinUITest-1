using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class CvvViewPage : BasePage
    {
        private const int TimeoutForUiElementToRenderInSeconds = 10;
        private const int ScrollingTimeoutInSeconds = 5;
        private const string CardValidLabel = "The Card is Valid";
        private const string InvalidCvvLabel = "CVV invalid. Please check it and re-enter";
        private const string CardDeclinedLabel = "The credit card was declined";
        private const string TryAnotherCardButton = "TRY ANOTHER CARD";
        private const string ProcessingActivityControl = "Processing...";

        private readonly static Query _enterCvvText = new Query(x => x.Marked("ENTER CVV"));
        private readonly Lazy<Query> _cvvTextBox = new Lazy<Query>(() => new Query("TxtCvvAutomationId"));
        private readonly Lazy<Query> _simulateGoodCvvButton = new Lazy<Query>(() => new Query(x => x.Marked("Good")));
        private readonly Lazy<Query> _simulateBadCvvButton = new Lazy<Query>(() => new Query(x => x.Marked("Bad CVV")));
        private readonly Lazy<Query> _simulateDeclineButton = new Lazy<Query>(() => new Query(x => x.Marked("Decline")));
        private readonly Lazy<Query> _validCardMessage = new Lazy<Query>(() => new Query(x => x.Marked(CardValidLabel)));
        private readonly Lazy<Query> _badCvvMessage = new Lazy<Query> (() => new Query(x => x.Marked(InvalidCvvLabel)));
        private readonly Lazy<Query> _declineMessage = new Lazy<Query> (() => new Query(x => x.Marked(CardDeclinedLabel)));
        private readonly Lazy<Query> _tryOtherCardButton = new Lazy<Query> (() => new Query(x => x.Marked(TryAnotherCardButton)));
        private readonly Lazy<Query> _processingMessage = new Lazy<Query> (() => new Query(x => x.Marked("Processing...")));
        private readonly Lazy<Query> _nextButton = new Lazy<Query> (() => new Query(x => x.Marked("NEXT")));
        private readonly Lazy<Query> _backButton = new Lazy<Query>(() => new Query(x => x.Id("ico_header_back.png")));

        public CvvViewPage(IApp app) : base(app, "Cvv View", _enterCvvText){}

        public CvvViewPage TapGoodCvvButton()
        {
            app.Tap(_simulateGoodCvvButton.Value);
            return this;
        }

        public CvvViewPage TapBadCvvButton()
        {
            app.Tap(_simulateBadCvvButton.Value);
            return this;
        }

        public CvvViewPage TapDeclineCvvButton()
        {
            app.Tap(_simulateDeclineButton.Value);
            return this;
        }

        public CvvViewPage EnterCvvInTextBox(string cvv)
        {
            app.EnterText(_cvvTextBox.Value, cvv);
            return this;
        }

        public CvvViewPage ClickNextButton()
        {
            app.Tap(_nextButton.Value);
            return this;
        }

        public CvvViewPage GoodCvvTransactionAndMoveNext(string _cvv)
        {
            app.Tap(_simulateGoodCvvButton.Value);
            app.EnterText(_cvvTextBox.Value, _cvv);
            app.Tap(_nextButton.Value);
            return this;
        }

        public CvvViewPage BadCvvTransactionAndMoveNext(string cvv)
        {
            app.Tap(_simulateBadCvvButton.Value);
            app.EnterText(_cvvTextBox.Value, cvv);
            app.Tap(_nextButton.Value);
            return this;
        }

        public CvvViewPage CardDeclinedTrasactionAndMoveNext(string cvv)
        {
            app.Tap(_simulateDeclineButton.Value);
            app.EnterText(_cvvTextBox.Value, cvv);
            app.Tap(_nextButton.Value);
            return this;
        }

        public CvvViewPage ClickBackButton()
        {
            app.Tap(_backButton.Value);
            return this;
        }

        public CvvViewPage ClickTryAnotherCardButton()
        {
            app.Tap(_tryOtherCardButton.Value);
            return this;
        }

        public bool IsNextButtonVisible()
        {
            var result = app.Query(_nextButton.Value);
            return result.Length > 0;
        }

        public bool IsTryAnotherCardButtonVisible()
        {
            app.WaitForElement(x => x.Marked(TryAnotherCardButton), "Timed out waiting for invalid cvv label", DefaultTimeoutForUiElementToRenderInSeconds);
            var result = app.Query(_tryOtherCardButton.Value);
            return result.Length > 0;
        }

        public bool IsCvvInvalidMessageVisible()
        {
            app.WaitForElement(x => x.Marked(InvalidCvvLabel), "Timed out waiting for invalid cvv label", DefaultTimeoutForUiElementToRenderInSeconds);
            var result = app.Query(_badCvvMessage.Value);
            return result.Length > 0;
        }

        public bool IsCardValidMessageVisible()
        {
            app.WaitForElement(x => x.Marked(CardValidLabel), "Timed out waiting for invalid cvv label", DefaultTimeoutForUiElementToRenderInSeconds);
            var result = app.Query(_validCardMessage.Value);
            return result.Length > 0;
        }

        public bool IsCardDeclinedMessageVisible()
        {
            app.WaitForElement(x => x.Marked(CardDeclinedLabel), "Timed out waiting for invalid cvv label", DefaultTimeoutForUiElementToRenderInSeconds);
            var result = app.Query(_declineMessage.Value);
            return result.Length > 0;
        }

        public string GetCardValidatedMessage()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ProcessingActivityControl), "Timed out waiting for no element", DefaultApiCallTimeout);
                var infobar = app.WaitForElement(x => x.Marked(CardValidLabel), "Timed out waiting for element", TimeSpan.FromSeconds(TimeoutForUiElementToRenderInSeconds));
                return infobar.Length > 0 ? infobar[0].Text : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string GetCardInvalidCvvLabelMessage()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ProcessingActivityControl), "Timed out waiting for no element", DefaultApiCallTimeout);
                var invalidcvvlabel = app.WaitForElement(x => x.Marked(InvalidCvvLabel), "Timed out waiting for element", DefaultTimeoutForUiElementToRenderInSeconds);
                return invalidcvvlabel.Length > 0 ? invalidcvvlabel[0].Text : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string GetCardDeclinedLabelMessage()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ProcessingActivityControl), "Timed out waiting for no element", DefaultApiCallTimeout);
                var declinedcardlabel = app.WaitForElement(x => x.Marked(CardDeclinedLabel), "Timed out waiting for element", DefaultTimeoutForUiElementToRenderInSeconds);
                return declinedcardlabel.Length > 0 ? declinedcardlabel[0].Text : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
