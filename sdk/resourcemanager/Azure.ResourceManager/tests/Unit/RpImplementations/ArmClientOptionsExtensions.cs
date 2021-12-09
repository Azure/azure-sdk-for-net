using System.Collections.Generic;

namespace Azure.ResourceManager.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        public static FakeRpApiVersions FakeRestApiVersions(this ArmClientOptions azureResourceManagerClientOptions)
        {
            Dictionary<ResourceType, string> versions = new Dictionary<ResourceType, string>();
            versions.Add(new ResourceType("Microsoft.fakedService/fakedApi"), FakeResourceApiVersions.Default);
            return azureResourceManagerClientOptions.GetOverrideObject<FakeRpApiVersions>(() => versions) as FakeRpApiVersions;
        }
    }
}
