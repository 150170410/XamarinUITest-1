using System;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FastBar.Client.Registration.UITest.Pages
{
    public class EventPage : BasePage
    {
        private readonly static Query _eventPage = new Query(x => x.Id("SELECT EVENT"));
        private readonly Lazy<Query> _eventItem = new Lazy<Query>(() => new Query("EventItem"));

        public EventPage(IApp app) : base(app, "Event Page", _eventPage){}

        public EventPage SelectEvent(int index)
        {            
            app.WaitForElement(x => x.Id("EventItem"), "time out", DefaultApiCallTimeout);           
            app.WaitForNoElement((x => x.Marked("Downloading events...")), "Unable to download events", new TimeSpan(0,0,120));
            AppResult item = app.Query(_eventItem.Value)[index];
            app.TapCoordinates(item.Rect.CenterX, item.Rect.CenterY);
            app.WaitForNoElement((x => x.Marked("Processing...")), "Unable to proceed to event", TimeSpan.FromSeconds(120));
            return this;
        }
    }
}