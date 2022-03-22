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
            ResourceProvider provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Feature testFeature = null;
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
            ResourceProvider provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Feature feature = await provider.GetFeatures().GetAsync("AHUB");
            Assert.IsNotNull(feature);
            Assert.IsNotNull(feature.Data.Id);
            Assert.AreEqual("Microsoft.Compute/AHUB", feature.Data.Name);
            Assert.IsNotNull(feature.Data.Properties);
            Assert.IsNotNull(feature.Data.ResourceType);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await provider.GetFeatures().GetAsync("DoesNotExist"));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task TryGet()
        {
            ResourceProvider provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Feature feature = await provider.GetFeatures().GetIfExistsAsync("AHUB");
            Assert.IsNotNull(feature);
            Assert.IsNotNull(feature.Data.Id);
            Assert.AreEqual("Microsoft.Compute/AHUB", feature.Data.Name);
            Assert.IsNotNull(feature.Data.Properties);
            Assert.IsNotNull(feature.Data.ResourceType);

            var response = await provider.GetFeatures().GetIfExistsAsync("DoesNotExist");
            Assert.IsNull(response.Value);
        }

        [RecordedTest]
        public async Task Exists()
        {
            ResourceProvider provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Assert.IsTrue(await provider.GetFeatures().ExistsAsync("AHUB"));
            Assert.IsFalse(await provider.GetFeatures().ExistsAsync("DoesNotExist"));
        }
    }
}
