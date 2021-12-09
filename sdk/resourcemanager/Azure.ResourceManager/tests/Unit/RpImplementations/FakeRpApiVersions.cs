namespace Azure.ResourceManager.Tests
{
    public class FakeRpApiVersions
    {
        public FakeRpApiVersions()
        {
            FakeResourceVersion = FakeResourceApiVersions.Default;
        }

        public FakeResourceApiVersions FakeResourceVersion { get; set; }
    }
}
