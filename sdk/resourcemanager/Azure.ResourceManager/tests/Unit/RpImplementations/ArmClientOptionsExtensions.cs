using System.Collections.Generic;

namespace Azure.ResourceManager.Tests
{
    public static class AzureResourceManagerClientOptionsExtensions
    {
        internal static FakeRpApiVersions FakeRestApiVersions(this ArmClientOptions azureResourceManagerClientOptions)
        {
            Dictionary<ResourceType, string> versions = new Dictionary<ResourceType, string>();
            versions.Add(new ResourceType("Microsoft.fakedService/fakedApi"), FakeResourceApiVersions.Default);
            return new FakeRpApiVersions();
        }
    }
}
