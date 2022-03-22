using System;
using System.Threading.Tasks;
using Azure.Core;
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
            var resource = Client.GetFeatureResource(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}/providers/Microsoft.Features/providers/Microsoft.FakeNamespace/features/fakeFeature"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceProviderResource provider = await subscription.GetResourceProviders().GetAsync("Microsoft.Compute");
            FeatureResource featureFromCollection = await GetFirst(provider.GetFeatures().GetAllAsync());
            FeatureResource feature = await featureFromCollection.GetAsync();
            Assert.AreEqual(featureFromCollection.Data.Id, feature.Data.Id);
            Assert.AreEqual(featureFromCollection.Data.Name, feature.Data.Name);
            Assert.AreEqual(featureFromCollection.Data.Properties.State, feature.Data.Properties.State);
            Assert.AreEqual(featureFromCollection.Data.ResourceType, feature.Data.ResourceType);

            ResourceIdentifier invalidId = new ResourceIdentifier(feature.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetFeatureResource(invalidId).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private async Task<FeatureResource> GetFirst(AsyncPageable<FeatureResource> asyncPageable, bool? isRegistered = null)
        {
            FeatureResource result = null;
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
            ResourceProviderResource provider = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceProviders().GetAsync("Microsoft.Compute");
            FeatureResource feature = await provider.GetFeatures().GetAsync("AHUB");
            FeatureResource afterRegister = await feature.RegisterAsync();
            Assert.AreEqual(feature.Data.Id, afterRegister.Data.Id);
            Assert.AreEqual(feature.Data.Name, afterRegister.Data.Name);
            Assert.AreEqual("Pending", afterRegister.Data.Properties.State);
            Assert.AreEqual(feature.Data.ResourceType, afterRegister.Data.ResourceType);

            FeatureResource afterUnRegister = await feature.UnregisterAsync();
            Assert.AreEqual(feature.Data.Id, afterUnRegister.Data.Id);
            Assert.AreEqual(feature.Data.Name, afterUnRegister.Data.Name);
            Assert.AreEqual("Unregistering", afterUnRegister.Data.Properties.State);
            Assert.AreEqual(feature.Data.ResourceType, afterUnRegister.Data.ResourceType);
        }
    }
}
