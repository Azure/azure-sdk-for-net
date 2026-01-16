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
                Assert.That(loc.Metadata, Is.Not.Null);
                Assert.That(loc.RegionalDisplayName, Is.Not.Null);

                AzureLocation locStruct = loc;

                Assert.That(locStruct.Name, Is.EqualTo(loc.Name));
                Assert.That(locStruct.DisplayName, Is.EqualTo(loc.DisplayName));
            }
        }
    }
}
