namespace Azure.ResourceManager.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        internal static FakeRpApiVersions FakeRestApiVersions(this ArmClientOptions azureResourceManagerClientOptions)
        {
            return azureResourceManagerClientOptions.GetOverrideObject<FakeRpApiVersions>(() => new FakeRpApiVersions()) as FakeRpApiVersions;
        }
    }
}
