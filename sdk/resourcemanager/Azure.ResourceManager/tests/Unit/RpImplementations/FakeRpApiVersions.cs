namespace Azure.ResourceManager.Tests
{
    internal class FakeRpApiVersions
    {
        internal FakeRpApiVersions()
        {
            FakeResourceVersion = FakeResourceApiVersions.Default;
        }

        public FakeResourceApiVersions FakeResourceVersion { get; set; }
    }
}
