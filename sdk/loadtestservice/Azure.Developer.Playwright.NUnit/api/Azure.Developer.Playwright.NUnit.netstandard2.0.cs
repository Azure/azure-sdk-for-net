namespace Azure.Developer.Playwright.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceBrowserNUnit : Azure.Developer.Playwright.PlaywrightServiceBrowserClient
    {
        public PlaywrightServiceBrowserNUnit() { }
        public PlaywrightServiceBrowserNUnit(Azure.Core.TokenCredential credential) { }
        public PlaywrightServiceBrowserNUnit(Azure.Core.TokenCredential credential, Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        public PlaywrightServiceBrowserNUnit(Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task SetupAsync() { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public System.Threading.Tasks.Task TearDownAsync() { throw null; }
    }
}
