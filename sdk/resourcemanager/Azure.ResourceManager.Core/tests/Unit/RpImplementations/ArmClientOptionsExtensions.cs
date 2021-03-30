namespace Azure.ResourceManager.Core.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        public static FakeRpApiVersions FakeRpApiVersions(this ArmClientOptions AzureResourceManagerClientOptions)
        {
            return AzureResourceManagerClientOptions.GetOverrideObject<FakeRpApiVersions>(() => new FakeRpApiVersions()) as FakeRpApiVersions;
        }
    }
}
