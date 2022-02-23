using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Tests
{
    public class TestTrackedResource : TrackedResourceData
    {
        public TestTrackedResource(ResourceIdentifier id) : this(id, AzureLocation.WestUS)
        {
        }

        public TestTrackedResource(ResourceIdentifier id, string location)
            :base(id, id.Name, id.ResourceType, null, null, location)
        {
        }
    }
}
