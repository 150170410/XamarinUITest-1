using FastBar.Client.Registration.UITest.Pages;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;

namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class AddCashToExistingAttendeeTests : BaseTest
    {
        private AttendeeDetailPage _attendeeDetailPage;

        public AddCashToExistingAttendeeTests(Platform platform) : base(platform)
        {
        }

        [SetUp]
        public void Init()
        {            
            SelectWorkFlowPage selectWorkFlowPage = NavigateToSelectWorkflowScreen(TestUsername, TestPin, 3);
            selectWorkFlowPage.ClickScan();
            ScanExistingWristbandPage scanExistingWristbandPage = new ScanExistingWristbandPage(app);
            scanExistingWristbandPage.SimulateScan();
            _attendeeDetailPage = new AttendeeDetailPage(app);
        }

        [Test]
        public void AddCashToExistingAttendee_Works()
        {
            // Arrange

            // Act
            _attendeeDetailPage.ClickAddCashButton();
            LoadCashViewPage loadCashPage = new LoadCashViewPage(app);
            loadCashPage.EnterAmount(10);
            loadCashPage.ClickFinishButton();

            // Assert        
            Assert.AreEqual("+ $10 pending", _attendeeDetailPage.GetPendingAmountMessage());
        }

        [Test]
        public void AddCashToExistingAttendee_MoveBackFromLoadCashWithoutAddingCash()
        {
            // Arrange

            // Act
            _attendeeDetailPage.ClickAddCashButton();
            LoadCashViewPage loadCashPage = new LoadCashViewPage(app);
            loadCashPage.ClickBackButton();

            // Assert
            Assert.AreEqual(string.Empty, _attendeeDetailPage.GetPendingAmountMessage());
        }
    }
}
