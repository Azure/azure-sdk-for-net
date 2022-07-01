using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class FeatureCollectionTests : ResourceManagerTestBase
    {
        public FeatureCollectionTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public async Task List()
        {
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            FeatureResource testFeature = null;
            await foreach (var feature in provider.GetFeatures().GetAllAsync())
            {
                testFeature = feature;
                break;
            }
            Assert.IsNotNull(testFeature);
            Assert.IsNotNull(testFeature.Data.Id);
            Assert.IsNotNull(testFeature.Data.Name);
            Assert.IsNotNull(testFeature.Data.Properties);
            Assert.IsNotNull(testFeature.Data.ResourceType);
        }

        [RecordedTest]
        public async Task Get()
        {
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            FeatureResource feature = await provider.GetFeatures().GetAsync("AHUB");
            Assert.IsNotNull(feature);
            Assert.IsNotNull(feature.Data.Id);
            Assert.AreEqual("Microsoft.Compute/AHUB", feature.Data.Name);
            Assert.IsNotNull(feature.Data.Properties);
            Assert.IsNotNull(feature.Data.ResourceType);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await provider.GetFeatures().GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task Exists()
        {
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Assert.IsTrue(await provider.GetFeatures().ExistsAsync("AHUB"));
            Assert.IsFalse(await provider.GetFeatures().ExistsAsync("DoesNotExist"));
        }
    }
}
