using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Azure.Developer.MicrosoftPlaywrightTesting;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    public IPage _page;

    [SetUp]
    public async Task PageSetup()
    {
        _playwright = await Playwright.CreateAsync();

        // Old code
        //Browser = await _playwright.Chromium.LaunchAsync();

        // New code
        var playwrightService = new PlaywrightService();
        var connectOptions = await playwrightService.GetConnectOptionsAsync<BrowserTypeConnectOptions>(os: ServiceOs.LINUX, runId: $"Manual Launch - {DateTime.UtcNow}");
        _browser = await _playwright.Chromium.ConnectAsync(connectOptions.WsEndpoint!, connectOptions.Options!);
        // End new code

        _page = await _browser.NewPageAsync();
    }

    [TearDown]
    public async Task PageTeardown()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    public async Task HasTitle()
    {
        await _page.GotoAsync("https://playwright.dev");
    }
}
