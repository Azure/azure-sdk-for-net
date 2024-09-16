namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceNUnit : Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightService
    {
        public static Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceOptions playwrightServiceOptions;
        public PlaywrightServiceNUnit(Azure.Core.TokenCredential? credential = null) : base (default(Azure.Developer.MicrosoftPlaywrightTesting.PlaywrightServiceOptions), default(Azure.Core.TokenCredential)) { }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task SetupAsync() { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public void Teardown() { }
    }
}
