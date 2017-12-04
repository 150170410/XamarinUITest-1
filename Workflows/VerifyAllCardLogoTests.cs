// VerifyAllCardLogoTests.cs
//
// Author:
//       RaviKiran <>
//
// Copyright (c) 2017 FastBar Technologies Inc.
//
using System;
using FastBar.Client.Registration.UITest.Pages.Workflows;
using NUnit.Framework;
using Xamarin.UITest;
namespace FastBar.Client.Registration.UITest.Workflows
{
    [TestFixture(Platform.iOS)]
    public class VerifyAllCardLogoTests : BaseTest
    {
        private SwipeCardPage _swipeCardPage;
        public VerifyAllCardLogoTests(Platform platform) : base(platform){} 

        [SetUp]
        public void Init()
        {
            // Arrange
            SelectWorkFlowPage selectWorkFlowPage = NavigateToSelectWorkflowScreen(TestUsername, TestPin, 3);
            selectWorkFlowPage.ClickSwipeCard();
            SelectPricingPackagePage selectPricingPackage = new SelectPricingPackagePage(app);
            selectPricingPackage.SelectPricingPackage(0);
            _swipeCardPage = new SwipeCardPage(app);
        }

        [Test]
        public void IsBlankCardLogoShownWhenThereIsNoCardEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            // Assert for blank card logo
            Assert.IsTrue(manualcardentrypage.IsBlankCardLogoVisible());
        }

        [Test]
        public void IsVisaCardLogoVisibleWhenCardNumberIsEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.VisaCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsVisaLogoVisible());
        }

        [Test]
        public void IsMasterCardLogoVisibleWhenCardNumberIsEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.MasterCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsMasterCardLogoVisible());
            
        }

        [Test]
        public void IsAmexCardLogoVisibleWhenCardNumberIsEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.AmexCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsAmexCardLogoVisible()); 
        }

        [Test]
        public void IsDinersClubCardLogoVisibleWhenCardNumberEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.DinersClubCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsDinersClubCardLogoVisible());
        }

        [Test]
        public void IsDiscoverCardLogoVisibleWhenCardNumberEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.DiscoverCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsDiscoverCardLogoVisible());
        }

        [Test]
        public void IsJCBCardLogoVisibleWhenCardNumberEntered()
        {
            // Act
            _swipeCardPage.ClickCloseSimulationButton()
                          .ClickManualCardButton();

            ManualCardEntryPage manualcardentrypage = new ManualCardEntryPage(app);

            manualcardentrypage.EnterCreditCardNumberInTextBox(TestCardNumbers.JCBCardNumber);

            // Assert for visa card logo
            Assert.IsTrue(manualcardentrypage.IsJcbCardLogoVisible());
        }
    }
}
