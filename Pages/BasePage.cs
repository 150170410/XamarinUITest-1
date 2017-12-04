using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages
{
    public class BasePage
    {
        public TimeSpan DefaultApiCallTimeout => TimeSpan.FromSeconds(Common.Constants.ServiceClientConstants.DefaultTimeoutSeconds);
        public TimeSpan DefaultTimeoutForUiElementToRenderInSeconds => TimeSpan.FromSeconds(UITestConstants.TimeoutForUiElementToRenderInSeconds);

        public string PageName { get; protected set; }
        protected IApp app { get; private set; }
        private Query _trait;

        public BasePage(IApp app)
        {
            this.app = app;
        }

        /// <summary>
        /// Create a new instance of the page.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="pageName">The name of the page. This will be used in screenshots.</param>
        /// <param name="trait">A query representing a uniquely identifiable UI element that, when visible, means the page has loaded and the user is ready to begin interacting with it, such as a logo or username field.</param>
        public BasePage(IApp app, string pageName, Query trait = null)
        {
            this.app = app;
            this.PageName = pageName;

            if (trait != null)
            {
                _trait = trait;
                CheckForTrait();
            }
        }

        private void CheckForTrait()
        {            
            app.WaitForElement(_trait.Func, timeout: DefaultTimeoutForUiElementToRenderInSeconds);
            app.Screenshot($"On the {PageName} page");
        }
    }
}