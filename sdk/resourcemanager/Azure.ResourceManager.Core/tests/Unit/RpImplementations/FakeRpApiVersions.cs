namespace Azure.ResourceManager.Core.Tests
{
    public class FakeRpApiVersions
    {
        internal FakeRpApiVersions()
        {
            FakeResourceVersion = FakeResourceApiVersions.Default;
        }

        public FakeResourceApiVersions FakeResourceVersion { get; set; }
    }
}
