namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceNUnit : Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightService
    {
        public PlaywrightServiceNUnit(Azure.Core.TokenCredential? credential = null) : base (default(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions), default(Azure.Core.TokenCredential), default(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface.IFrameworkLogger)) { }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions playwrightServiceOptions { get { throw null; } }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task SetupAsync() { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public void Teardown() { }
    }
}
