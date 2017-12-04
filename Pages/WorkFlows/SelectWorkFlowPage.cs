using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class SelectWorkFlowPage : BasePage
    {
        private readonly static Query _swipeCardButton = new Query("btn_swipe_card.png");
        private readonly Lazy<Query> _newButton = new Lazy<Query> (() => new Query("RelLayoutButtonsForNewTab"));
        private readonly Lazy<Query> _existingButton = new Lazy<Query> (() => new Query("RelLayoutButtonsForExistingTab"));
        private readonly Lazy<Query> _scanQRCodeButton = new Lazy<Query> (() => new Query("btn_qrcode.png"));
        private readonly Lazy<Query> _loadCashButton = new Lazy<Query>(() => new Query(x => x.Id("btn_loadcash.png")));
        private readonly Lazy<Query> _scanWristbandButton = new Lazy<Query> (() => new Query(x => x.Id("btn-tap-wristband-white.png")));
        private readonly Lazy<Query> _searchButton = new Lazy<Query> (() => new Query(x => x.Id("btn-search-white.png")));
        private readonly Lazy<Query> _segmentedControl = new Lazy<Query>(() => new Query("SegmentedControlAutomationId"));

        public SelectWorkFlowPage(IApp app) : base(app, "Select Workflow", _swipeCardButton){}

        public SelectWorkFlowPage ClickSwipeCard()
        {
            app.Tap(_newButton.Value);
            app.Tap(_swipeCardButton);
            return this;
        }

        public SelectWorkFlowPage ClickQrCode()
        {
            app.Tap(_newButton.Value);
            app.Tap(_scanQRCodeButton.Value);
            return this;
        }

        public BasePage ClickLoadCash()
        {
            app.Tap(_newButton.Value);
            app.Tap(_loadCashButton.Value);
            return this;
        }

        public SelectWorkFlowPage ClickScan()
        {
            app.Tap(_segmentedControl.Value);
            app.Tap(_existingButton.Value);
            app.Tap(_scanWristbandButton.Value);

            return this;
        }

        public SelectWorkFlowPage ClickSearch()
        {
            app.Tap(_segmentedControl.Value);
            app.Tap(_existingButton.Value);
            app.Tap(_searchButton.Value);

            return this;
        }
    }
}
