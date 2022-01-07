using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class FeatureOperationsTests : ResourceManagerTestBase
    {
        public FeatureOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ///subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/providers/Microsoft.Features/providers/Microsoft.Compute/features/AHUB
            var resource = Client.GetFeature(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/providers/Microsoft.Features/providers/Microsoft.FakeNamespace/features/fakeFeature"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            Provider provider = await subscription.GetProviders().GetAsync("Microsoft.Compute");
            Feature featureFromCollection = await GetFirst(provider.GetFeatures().GetAllAsync());
            Feature feature = await featureFromCollection.GetAsync();
            Assert.AreEqual(featureFromCollection.Data.Id, feature.Data.Id);
            Assert.AreEqual(featureFromCollection.Data.Name, feature.Data.Name);
            Assert.AreEqual(featureFromCollection.Data.Properties.State, feature.Data.Properties.State);
            Assert.AreEqual(featureFromCollection.Data.Type, feature.Data.Type);

            ResourceIdentifier invalidId = new ResourceIdentifier(feature.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetFeature(invalidId).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private async Task<Feature> GetFirst(AsyncPageable<Feature> asyncPageable, bool? isRegistered = null)
        {
            Feature result = null;
            await foreach (var feature in asyncPageable)
            {
                if(isRegistered.HasValue)
                {
                    if(isRegistered.Value == (feature.Data.Properties.State == "Registered"))
                    {
                        result = feature;
                        break;
                    }
                }
                else
                {
                    result = feature;
                    break;
                }
            }
            return result;
        }

        [RecordedTest]
        public async Task RegisterAndUnregister()
        {
            //testing both register and unregister in the same test to avoid feature creep in our test subscription
            Provider provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetProviders().GetAsync("Microsoft.Compute");
            Feature feature = await provider.GetFeatures().GetAsync("AHUB");
            Feature afterRegister = await feature.RegisterAsync();
            Assert.AreEqual(feature.Data.Id, afterRegister.Data.Id);
            Assert.AreEqual(feature.Data.Name, afterRegister.Data.Name);
            Assert.AreEqual("Pending", afterRegister.Data.Properties.State);
            Assert.AreEqual(feature.Data.Type, afterRegister.Data.Type);

            Feature afterUnRegister = await feature.UnregisterAsync();
            Assert.AreEqual(feature.Data.Id, afterUnRegister.Data.Id);
            Assert.AreEqual(feature.Data.Name, afterUnRegister.Data.Name);
            Assert.AreEqual("Unregistering", afterUnRegister.Data.Properties.State);
            Assert.AreEqual(feature.Data.Type, afterUnRegister.Data.Type);
        }
    }
}
