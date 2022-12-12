using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Windows;
using TechTalk.SpecFlow;

namespace PlayWrightWithBDD.StepDefinitions
{
    [Binding]
    public class DocAppoitmentStepDefinitions
    {
        IPage page;
        IPlaywright playwright;

        [BeforeScenario]
        public async Task TestInitialize()
        {
            playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page = await browser.NewPageAsync();
        }

        [Given(@"Open Url ""([^""]*)""")]
        public async Task GivenOpenUrl(string p0)
        {
            await page.GotoAsync(p0);
            await page.ClickAsync("#btn-make-appointment");
        }

        [When(@"Click Make Opitment")]
        public async void WhenClickMakeOpitment()
        {
           
        }

        [Then(@"Enter username ""([^""]*)""")]
        public async Task ThenEnterUsername(string p0)
        {
            await page.FillAsync("#txt-username", p0);
        }

        [Then(@"Enter Passowrd ""([^""]*)""")]
        public async Task ThenEnterPassowrd(string thisIsNotAPassword)
        {
            await page.FillAsync("#txt-password", thisIsNotAPassword);
        }

        [Then(@"Click Login Button")]
        public async Task ThenClickLoginButton()
        {
            await page.ClickAsync("#btn-login");
        }

        [When(@"Loged In Checked Header ""([^""]*)""")]
        public async Task WhenLogedInCheckedHeader(string p0)
        {
            var actualMessage = await page.InnerTextAsync("#appointment > div > div > div > h2");
            Assert.AreEqual(actualMessage, "Make Appointment");
        }

        [Then(@"Select Faculty")]
        public async Task ThenSelectFaculty()
        {
            await page.SelectOptionAsync("#combo_facility", "Hongkong CURA Healthcare Center");
        }

        [Then(@"Check Apply")]
        public async Task ThenCheckApply()
        {
            await page.ClickAsync("#chk_hospotal_readmission");
        }

        [Then(@"Select Radio button Medicare")]
        public async Task ThenSelectRadioButtonMedicare()
        {
            await page.ClickAsync("#radio_program_medicaid");
        }

        [Then(@"Visit Date")]
        public async Task ThenVisitDate()
        {
            //await page.EvaluateAsync(DateTime.Now.ToString());
            await page.ClickAsync("#txt_visit_date");
            await page.ClickAsync("body > div > div.datepicker-days > table > tbody > tr:nth-child(1) > td:nth-child(7)");
        }

        [Then(@"Write Comment")]
        public async Task ThenWriteComment()
        {
            await page.FillAsync("#txt_comment","Jaffar");
        }

        [Then(@"Click Book Appoitement")]
        public async Task ThenClickBookAppoitement()
        {
            await page.ClickAsync("#btn-book-appointment");
            var actualMessage = await page.InnerTextAsync("#summary > div > div > div.col-xs-12.text-center > h2");
            Assert.AreEqual(actualMessage, "Appointment Confirmation");
            page.CloseAsync();
        }
    }
}
