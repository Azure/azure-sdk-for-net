using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class TenantOperationTests : ResourceManagerTestBase
    {
        public TenantOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task ValidateResourceType()
        {
            await foreach (var provider in Client.GetTenantResourceProvidersAsync())
            {
                foreach (var providerResourceType in provider.ResourceTypes)
                {
                    Assert.DoesNotThrow(() => new ResourceType($"{provider.Namespace}/{providerResourceType.ResourceType}"), $"{provider.Namespace}/{providerResourceType.ResourceType} was not able to convert to a ResourceType struct");
                }
            }
        }
    }
}
