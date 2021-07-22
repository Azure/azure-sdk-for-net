using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
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
            var listLocs = Client.DefaultSubscription.ListLocationsAsync();
            await foreach (LocationExpanded loc in listLocs)
            {
                Assert.IsNotNull(loc.Metadata);
                Assert.IsNotNull(loc.SubscriptionId);
                Assert.IsNotNull(loc.CanonicalName);
            }
        }
    }
}
