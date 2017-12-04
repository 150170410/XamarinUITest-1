using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class LoadCashViewPage : BasePage
    {
        private readonly static Query _loadCashPage = new Query(x => x.Marked("ENTER AMOUNT"));
        private readonly Lazy<Query> _amountTextBox = new Lazy<UITest.Query>(() => new Query("TxtAmount"));
        private readonly Lazy<Query> _backButton = new Lazy<Query>(() => new Query("ico_header_back.png"));
        private readonly Lazy<Query> _nextButton = new Lazy<Query> (() => new Query(x => x.Marked("NEXT")));
        private readonly Lazy<Query> _finishButton = new Lazy<Query>(() => new Query(x => x.Marked("FINISH")));

        public LoadCashViewPage(IApp app) : base(app, "Load Cash", _loadCashPage){}

        public LoadCashViewPage EnterAmount(int amount)
        {
            app.EnterText(_amountTextBox.Value, amount.ToString());
            return this;
        }

        public LoadCashViewPage ClickFinishButton()
        {            
            app.Tap(_finishButton.Value);
            return this;
        }

        public LoadCashViewPage ClickNextButton()
        {
            app.Tap(_nextButton.Value);
            return this;
        }

        public LoadCashViewPage ClickBackButton()
        {
            app.Tap(_backButton.Value);
            return this;
        }

        public bool IsFinishButtonVisible()
        {
            var result = app.Query(_finishButton.Value);
            return result.Length > 0;
        }

        public bool IsNextButtonVisible()
        {
            var result = app.Query(_nextButton.Value);
            return result.Length > 0;
        }

        public LoadCashViewPage EnterAmountAndMoveToNextPage(string amount)
        {
            app.EnterText(_amountTextBox.Value, amount);
            app.Tap(_nextButton.Value);
            return this;
        }
    }
}