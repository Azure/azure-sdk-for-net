namespace Azure.Developer.Playwright.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceBrowserNUnit : Azure.Developer.Playwright.PlaywrightServiceBrowserClient
    {
        public PlaywrightServiceBrowserNUnit() { }
        public PlaywrightServiceBrowserNUnit(Azure.Core.TokenCredential credential) { }
        public PlaywrightServiceBrowserNUnit(Azure.Core.TokenCredential credential, Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        public PlaywrightServiceBrowserNUnit(Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions options) { }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public override System.Threading.Tasks.Task DisposeAsync() { throw null; }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task InitializeAsync() { throw null; }
    }
}
