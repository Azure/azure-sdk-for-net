using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class LocationExpandedTests : ResourceManagerTestBase
    {
        public LocationExpandedTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task VerifyMetadata()
        {
            var listLocs = (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetLocationsAsync();
            await foreach (LocationExpanded loc in listLocs)
            {
                Assert.IsNotNull(loc.Metadata);
                Assert.IsNotNull(loc.RegionalDisplayName);

                AzureLocation locStruct = loc;

                Assert.AreEqual(loc.Name, locStruct.Name);
                Assert.AreEqual(loc.DisplayName, locStruct.DisplayName);
            }
        }
    }
}
