using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class ManualCardEntryPage : BasePage
    {
        private const int TimeoutForUiElementToRenderInSeconds = 10;
        private const int ScrollingTimeoutInSeconds = 5;
        private const int DefaultTimeOutSeconds = 30;
        private const string CardValidLabel = "The Card is Valid";
        private const string InvalidCvvLabel = "CVV invalid. Please check it and re-enter";
        private const string CardDeclinedLabel = "The credit card was declined";
        private const string CardNumberInvalidLabel = "Credit card number is invalid";
        private const string CardExpiredLabel = "The credit card has expired";
        private const string ProcessingActivityControl = "Processing...";
        private const string EnterNewCardAutomationId = "BtnEnterNewCardAutomationId";

        private readonly static Query _cardDetailsHeaderText = new Query(x => x.Marked("CARD DETAILS"));
        private readonly Lazy<Query> _cardNumberTextBox = new Lazy<Query>(() => new Query("TxtManualCreditCardNumberAutomationId"));
        private readonly Lazy<Query> _expirydateTextBox = new Lazy<Query>(() => new Query("TxtManualCreditCardExpiryDateAutomationId"));
        private readonly Lazy<Query> _cvvTextBox = new Lazy<Query>(() => new Query("TxtManualCvvAutomationId"));
        private readonly Lazy<Query> _nextButton = new Lazy<Query>(() => new Query(x => x.Marked("NEXT")));
        private readonly Lazy<Query> _simulateGoodCvvButton = new Lazy<Query>(() => new Query(x => x.Marked("Good")));
        private readonly Lazy<Query> _simulateBadCvvButton = new Lazy<Query>(() => new Query(x => x.Marked("Bad CVV")));
        private readonly Lazy<Query> _simulateDeclineButton = new Lazy<Query>(() => new Query(x => x.Marked("Decline")));
        private readonly Lazy<Query> _backButton = new Lazy<Query>(() => new Query(x => x.Marked("ico_header_back.png")));
        private readonly Lazy<Query> _enterNewCardButton = new Lazy<Query> (() => new Query(EnterNewCardAutomationId));
        private readonly Lazy<Query> _cardStatusLabel = new Lazy<Query>(() => new Query("LblCardStatusMsgAutomationId"));
        private readonly Lazy<Query> _validCardMessage = new Lazy<Query>(() => new Query(x => x.Marked(CardValidLabel)));
        private readonly Lazy<Query> _badCvvMessage = new Lazy<Query>(() => new Query(x => x.Marked(InvalidCvvLabel)));
        private readonly Lazy<Query> _declineMessage = new Lazy<Query>(() => new Query(x => x.Marked(CardDeclinedLabel)));
        private readonly Lazy<Query> _cardNumberInvalidMessage = new Lazy<Query>(() => new Query(x => x.Marked(CardNumberInvalidLabel)));
        private readonly Lazy<Query> _cardExpiredMessage = new Lazy<Query>(() => new Query(x => x.Marked(CardExpiredLabel)));
        private readonly Lazy<Query> _visaCardLogo = new Lazy<Query>(() => new Query("ico_visa_blue.png"));
        private readonly Lazy<Query> _blankCardLogo = new Lazy<Query>(() => new Query("ico_blank_card.png"));
        private readonly Lazy<Query> _masterCardLogo = new Lazy<Query>(() => new Query("ico_mastercard_blue.png"));
        private readonly Lazy<Query> _amexCardLogo = new Lazy<Query>(() => new Query("ico_americanexpress_blue.png"));
        private readonly Lazy<Query> _discoverCardLogo = new Lazy<Query>(() => new Query("ico_discover_blue.png"));
        private readonly Lazy<Query> _dinersclubCardLogo = new Lazy<Query>(() => new Query("ico_dinersclub_blue.png"));
        private readonly Lazy<Query> _jcbCardLogo = new Lazy<Query>(() => new Query("ico_jcb_blue.png"));
        private readonly Lazy<Query> _processingDialog = new Lazy<Query>(() => new Query(x => x.Marked(ProcessingActivityControl)));

        public ManualCardEntryPage(IApp app) : base(app, "Manual Card Entry", _cardDetailsHeaderText){}

        public ManualCardEntryPage EnterCreditCardNumberInTextBox(string cardNumber)
        {
            app.EnterText(_cardNumberTextBox.Value, cardNumber);
            return this;
        }

        public ManualCardEntryPage EnterCvvInTextBox(string cvv)
        {
            app.EnterText(_cvvTextBox.Value,cvv);
            return this;
        }

        public ManualCardEntryPage EnterExpiryDateInTextBox(string expiryDate)
        {
            app.EnterText(_expirydateTextBox.Value, expiryDate);
            return this;
        }

        public ManualCardEntryPage TapGoodCvvButton()
        {
            app.Tap(_simulateGoodCvvButton.Value);
            return this;
        }

        public ManualCardEntryPage TapBadCvvButton()
        {
            app.Tap(_simulateBadCvvButton.Value);
            return this;
        }

        public ManualCardEntryPage TapDeclineCvvButton()
        {
            app.Tap(_simulateDeclineButton.Value);
            return this;
        }

        public ManualCardEntryPage ClickNextButton()
        {
            app.Tap(_nextButton.Value);
            return this;
        }

        public ManualCardEntryPage ClickBackButton()
        {
            app.Tap(_backButton.Value);
            return this;
        }

        public bool IsNextButtonVisible()
        {
            var result = app.Query(_nextButton.Value);
            return result.Length > 0;
        }

        public string GetCardValidatedLabelMessage()
        {
            try
            {
                app.WaitForNoElement(x => x.Marked(ProcessingActivityControl), "Timed out waiting for no element", DefaultApiCallTimeout);
                var validlabel = app.WaitForElement(x => x.Marked(CardValidLabel), "Timed out waiting for element", DefaultTimeoutForUiElementToRenderInSeconds);
                return validlabel.Length > 0 ? validlabel[0].Text : string.Empty;
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                return string.Empty;
            }

        }

        public string GetCardNumberInvalidLabelMessage()
        {
            try
            {
                var inavlidcardnumberlabel = app.WaitForElement(x => x.Marked(CardNumberInvalidLabel), "Timed out waiting for element", DefaultTimeoutForUiElementToRenderInSeconds);
                return inavlidcardnumberlabel.Length > 0 ? inavlidcardnumberlabel[0].Text : string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public string GetCardExpiredLabelMessage()
        {
            try
            {
                var cardexpiredlabel = app.WaitForElement(x => x.Marked(CardExpiredLabel), "Timed out waiting for element", DefaultTimeoutForUiElementToRenderInSeconds);
                return cardexpiredlabel.Length > 0 ? cardexpiredlabel[0].Text : string.Empty;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
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

        public bool IsEnterNewCardButtonVisible()
        {
            var result = app.Query(_enterNewCardButton.Value);
            return result.Length > 0;
        }

        public bool IsBlankCardLogoVisible()
        {
            var result = app.Query(_blankCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsVisaLogoVisible()
        {
            var result = app.Query(_visaCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsMasterCardLogoVisible()
        {
            var result = app.Query(_masterCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsAmexCardLogoVisible()
        {
            var result = app.Query(_amexCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsDiscoverCardLogoVisible()
        {
            var result = app.Query(_discoverCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsDinersClubCardLogoVisible()
        {
            var result = app.Query(_dinersclubCardLogo.Value);
            return result.Length > 0;
        }

        public bool IsJcbCardLogoVisible()
        {
            var result = app.Query(_jcbCardLogo.Value);
            return result.Length > 0;
        }
    }
}
