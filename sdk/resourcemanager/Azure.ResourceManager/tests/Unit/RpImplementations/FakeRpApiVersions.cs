namespace Azure.ResourceManager.Tests
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
