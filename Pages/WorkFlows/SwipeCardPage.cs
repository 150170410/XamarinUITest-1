using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class SwipeCardPage : BasePage
    {
        private readonly static Query swipeCardText = new Query(x => x.Marked("SWIPE CARD"));
        private readonly Lazy<Query> _backButton = new Lazy<Query>(() => new Query("ico_header_back.png"));
        private readonly Lazy<Query> _simulateSwipeButton = new Lazy<Query> (() => new Query("BtnSimulateAutomationId"));
        private readonly Lazy<Query> _skipCreditCardButton = new Lazy<Query> (() => new Query(x => x.Marked("SKIP CREDIT CARD")));
        private readonly Lazy<Query> _enterManuallyButton = new Lazy<Query> (() => new Query(x => x.Marked("ENTER MANUALLY")));
        private readonly Lazy<Query> _closeButton = new Lazy<Query> (() => new Query("BtnCloseReaderOverlayAutomationId"));

        public SwipeCardPage(IApp app) : base(app, "Swipe Card", swipeCardText){}

        public SwipeCardPage ClickCloseSimulationButton()
        {
            app.Tap(_closeButton.Value);
            return this;
        }

        public SwipeCardPage ClickSimulateSwipeButton()
        {
            app.Tap(_simulateSwipeButton.Value);
            return this;
        }

        public SwipeCardPage ClickManualCardButton()
        {
            app.Tap(_enterManuallyButton.Value);
            return this;
        }

        public SwipeCardPage ClickSkipCreditCardButton()
        {
            app.Tap(_skipCreditCardButton.Value);
            return this;
        }

        public SwipeCardPage ClickBackButton()
        {
            app.Tap(_backButton.Value);
            return this;
        }
    }
}
