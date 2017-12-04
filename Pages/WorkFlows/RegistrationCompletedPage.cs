using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class RegistrationCompletedPage : BasePage
    {
        private readonly static Query _nextAttendee = new Query("NextAttendee");

        public RegistrationCompletedPage(IApp app): base(app, "Registration Completed", _nextAttendee){}

        public RegistrationCompletedPage ClickNextAttendeeButton()
        {
            app.Tap(_nextAttendee);
            return this;
        }
    }
}
