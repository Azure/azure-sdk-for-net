namespace Azure.ResourceManager.Core.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        public static FakeRpApiVersions FakeRestApiVersions(this ArmClientOptions azureResourceManagerClientOptions)
        {
            return azureResourceManagerClientOptions.GetOverrideObject<FakeRpApiVersions>(() => new FakeRpApiVersions()) as FakeRpApiVersions;
        }
    }
}
