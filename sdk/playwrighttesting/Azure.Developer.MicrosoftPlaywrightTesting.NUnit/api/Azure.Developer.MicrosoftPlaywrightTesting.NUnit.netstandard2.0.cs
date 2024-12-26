namespace Azure.Developer.MicrosoftPlaywrightTesting.NUnit
{
    [NUnit.Framework.SetUpFixtureAttribute]
    public partial class PlaywrightServiceNUnit : Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightService
    {
        public PlaywrightServiceNUnit(Azure.Core.TokenCredential? credential = null) : base (default(Azure.Core.TokenCredential), default(Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions)) { }
        public static Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.PlaywrightServiceOptions options { get { throw null; } }
        [NUnit.Framework.OneTimeSetUpAttribute]
        public System.Threading.Tasks.Task SetupAsync() { throw null; }
        [NUnit.Framework.OneTimeTearDownAttribute]
        public void Teardown() { }
    }
}
