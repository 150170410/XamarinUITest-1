using System;
using Xamarin.UITest;
using System.Runtime.InteropServices;

namespace FastBar.Client.Registration.UITest.Pages.Workflows
{
    public class ScanExistingWristbandPage : BasePage
    {
        private static readonly Query _scanExistingWristbandPage = new Query(x => x.Marked("SCAN WRISTBAND"));
        private readonly Lazy<Query> _btnSimulateScan = new Lazy<Query>(() => new Query(x => x.Id("BtnSimulateAutomationId")));

        public ScanExistingWristbandPage(IApp app) : base(app, "Scan Wristband", _scanExistingWristbandPage)
        {
        }

        public ScanExistingWristbandPage SimulateScan()
        {
            app.Tap(_btnSimulateScan.Value);
            return this;
        }
    }
}
