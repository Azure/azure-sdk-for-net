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
            Assert.That(testFeature, Is.Not.Null);
            Assert.That(testFeature.Data.Id, Is.Not.Null);
            Assert.That(testFeature.Data.Name, Is.Not.Null);
            Assert.That(testFeature.Data.Properties, Is.Not.Null);
            Assert.That(testFeature.Data.ResourceType, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Get()
        {
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            FeatureResource feature = await provider.GetFeatures().GetAsync("AHUB");
            Assert.That(feature, Is.Not.Null);
            Assert.That(feature.Data.Id, Is.Not.Null);
            Assert.That(feature.Data.Name, Is.EqualTo("Microsoft.Compute/AHUB"));
            Assert.That(feature.Data.Properties, Is.Not.Null);
            Assert.That(feature.Data.ResourceType, Is.Not.Null);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await provider.GetFeatures().GetAsync("DoesNotExist"));
            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [RecordedTest]
        public async Task Exists()
        {
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            Assert.That((bool)await provider.GetFeatures().ExistsAsync("AHUB"), Is.True);
            Assert.That((bool)await provider.GetFeatures().ExistsAsync("DoesNotExist"), Is.False);
        }
    }
}
