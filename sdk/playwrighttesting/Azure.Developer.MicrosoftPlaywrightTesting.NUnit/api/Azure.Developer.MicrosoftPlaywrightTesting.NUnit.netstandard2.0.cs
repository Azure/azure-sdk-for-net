namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceNUnit : Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightService
    {
        public PlaywrightServiceNUnit(Azure.Core.TokenCredential? credential = null) : base (default(Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceOptions), default(Azure.Core.TokenCredential)) { }
        public static Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceOptions playwrightServiceOptions { get { throw null; } }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task SetupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public void Teardown() { }
    }
}
