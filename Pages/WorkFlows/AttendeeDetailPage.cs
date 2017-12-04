using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class AttendeeDetailPage : BasePage
    {
        private const string PendingAmountLabelAutomationId = "LblPendingAmountAutomationId";
        private const string AttendeeDetailScrollViewAutomationId = "SVAttendeeDetailAutomationId";
        private const string AddCashButtonAutomationId = "BtnAddCashAutomationId";
        private const string AddWristbandButtonAutomationId = "BtnAddWristbandAutomationId";
        private const string RefundCashButtonAutomationId = "BtnRefundCashAutomationId";
        private const string AddCardButtonAutomationId = "BtnAddCardAutomationId";
        private const int TimeoutForUiElementToRenderInSeconds = 10;
        private const int ScrollingTimeoutInSeconds = 5;

        private static readonly Query _attendeeDetailPage = new Query(x => x.Marked("ATTENDEE"));
        private readonly Lazy<Query> _addWristbandButton = new Lazy<Query>(() => new Query(AddWristbandButtonAutomationId));
        private readonly Lazy<Query> _addCashButton = new Lazy<Query>(() => new Query(AddCashButtonAutomationId));
        private readonly Lazy<Query> _refundCashButton = new Lazy<Query>(() => new Query(RefundCashButtonAutomationId));
        private readonly Lazy<Query> _addCardButton = new Lazy<Query>(() => new Query(AddCardButtonAutomationId));
        private readonly Lazy<Query> _txtFirstName = new Lazy<Query>(() => new Query("TxtFirstNameAutomationId"));
        private readonly Lazy<Query> _txtLastName = new Lazy<Query>(() => new Query("TxtLastNameAutomationId"));
        private readonly Lazy<Query> _txtPhoneNumber = new Lazy<Query>(() => new Query("TxtPhoneNumberAutomationId"));
        private readonly Lazy<Query> _txtEmailAddress = new Lazy<Query>(() => new Query("TxtAttendeeEmailAutiomationId"));
        private readonly Lazy<Query> _txtNotes = new Lazy<Query>(() => new Query("TxtNotesAutomationId"));
        private readonly Lazy<Query> _gridCashInfo = new Lazy<Query>(() => new Query("GridCashInfoAutomationId"));
        private readonly Lazy<Query> _infoBar = new Lazy<Query>(() => new Query("InfoBarAutomationId"));
        private readonly Lazy<Query> _attendeeDetailScroll = new Lazy<Query>(() => new Query(AttendeeDetailScrollViewAutomationId));
        private readonly Lazy<Query> _lblPendingCash = new Lazy<Query>(() => new Query(PendingAmountLabelAutomationId));

        public AttendeeDetailPage(IApp app) : base(app, "Attendee Detail", _attendeeDetailPage){}

        public AttendeeDetailPage ClickAddCashButton()
        {
            app.ScrollDownTo(AddCashButtonAutomationId, AttendeeDetailScrollViewAutomationId, ScrollStrategy.Gesture, timeout: TimeSpan.FromSeconds(ScrollingTimeoutInSeconds));
            app.Tap(_addCashButton.Value);
            return this;
        }

        public AttendeeDetailPage ClickAddCardButton()
        {
            app.WaitForElement(x => x.Id(AddCardButtonAutomationId), "Timeout for waiting to appear ADD CARD button", timeout: TimeSpan.FromSeconds(TimeoutForUiElementToRenderInSeconds));
            app.ScrollDownTo(AddCardButtonAutomationId, AttendeeDetailScrollViewAutomationId, ScrollStrategy.Gesture, timeout: TimeSpan.FromSeconds(ScrollingTimeoutInSeconds));
            app.Tap(_addCardButton.Value);
            return this;
        }

        public AttendeeDetailPage ClickAddWristbandButton()
        {
            app.ScrollDownTo(AddWristbandButtonAutomationId, AttendeeDetailScrollViewAutomationId, ScrollStrategy.Gesture, timeout: TimeSpan.FromSeconds(ScrollingTimeoutInSeconds));
            app.Tap(_addWristbandButton.Value);
            return this;
        }

        public AttendeeDetailPage EnterFirstName(string firstName)
        {
            app.EnterText(_txtFirstName.Value, firstName);
            return this;
        }

        public AttendeeDetailPage EnterLastName(string lastName)
        {
            app.EnterText(_txtLastName.Value, lastName);
            return this;
        }

        public AttendeeDetailPage EnterEmailAddress(string emailAddress)
        {
            app.EnterText(_txtEmailAddress.Value, emailAddress);
            return this;
        }

        public AttendeeDetailPage EnterPhoneNumber(string phoneNumber)
        {
            app.EnterText(_txtPhoneNumber.Value, phoneNumber);
            return this;
        }

        public AttendeeDetailPage EnterNote(string note)
        {
            app.EnterText(_txtNotes.Value, note);
            return this;
        }

        public string GetPendingAmountMessage()
        {
            try
            {
                var result = app.WaitForElement(x => x.Id(PendingAmountLabelAutomationId), "Query Timeout", TimeSpan.FromSeconds(TimeoutForUiElementToRenderInSeconds));
                return result.Length > 0 ? result[0].Text : string.Empty;
            }
            catch (Exception ex)
            {                
                return string.Empty;
            }
        }

        public string GetInfoBarMessage()
        {
            try
            {
                var infobar = app.WaitForElement(x => x.Id("InfoBarAutomationId"), "Timeout waiting for InfoBar", TimeSpan.FromSeconds(TimeoutForUiElementToRenderInSeconds));
                return infobar.Length > 0 ? infobar[0].Text : string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
