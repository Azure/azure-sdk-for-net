using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class TenantCollectionTests : ResourceManagerTestBase
    {
        public TenantCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task List()
        {
            int count = 0;
            await foreach (var tenant in Client.GetTenants().GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [RecordedTest]
        public async Task CheckResourceName()
        {
            ResourceNameValidationContent content = new ResourceNameValidationContent("mysubs", "Microsoft.Resources/subscriptions");
            var result = await Client.GetTenants().CheckResourceNameAsync(content);
            Assert.AreEqual(result.Value.Status, ResourceNameValidationStatus.Allowed);
        }
    }
}
