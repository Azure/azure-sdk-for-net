namespace Azure.ResourceManager.Tests
{
    internal class FakeRpApiVersions
    {
        public FakeRpApiVersions()
        {
            FakeResourceVersion = FakeResourceApiVersions.Default;
        }

        public FakeResourceApiVersions FakeResourceVersion { get; set; }
    }
}
