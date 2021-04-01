namespace Azure.ResourceManager.Core.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        public static FakeRpApiVersions FakeRestApiVersions(this ArmClientOptions AzureResourceManagerClientOptions)
        {
            return AzureResourceManagerClientOptions.GetOverrideObject<FakeRpApiVersions>(() => new FakeRpApiVersions()) as FakeRpApiVersions;
        }
    }
}
