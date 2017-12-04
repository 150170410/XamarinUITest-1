using System;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class SelectPricingPackagePage : BasePage
    {
        private readonly static Query _pricingPackageList = new Query("PricingPackageList");
        private readonly Lazy<Query> _backButton = new Lazy<Query>(() => new Query(x => x.Id("ico_header_back.png")));

        public SelectPricingPackagePage(IApp app): base(app, "Select Pricing Package", _pricingPackageList){}

        public SelectPricingPackagePage SelectPricingPackage(int i)
        {
            var query = new Query(x => x.Id("PricingPackageList").Child(i));
            app.Tap(query);
            return this;
        }

        public SelectPricingPackagePage ClickBackButton()
        {
            app.Tap(_backButton.Value);
            return this;
        }
    }
}