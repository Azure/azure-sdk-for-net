using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core.Tests
{
    public class TestResource<TIdentifier> : Resource<TIdentifier> where TIdentifier : TenantResourceIdentifier
    {
        public TestResource(TIdentifier id)
            :base(id, id.Name, id.ResourceType)
        {
        }
    }
}
