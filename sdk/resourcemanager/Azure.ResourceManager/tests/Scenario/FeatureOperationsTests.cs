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
            Assert.That(feature.Data.Id, Is.EqualTo(featureFromCollection.Data.Id));
            Assert.That(feature.Data.Name, Is.EqualTo(featureFromCollection.Data.Name));
            Assert.That(feature.Data.Properties.State, Is.EqualTo(featureFromCollection.Data.Properties.State));
            Assert.That(feature.Data.ResourceType, Is.EqualTo(featureFromCollection.Data.ResourceType));

            ResourceIdentifier invalidId = new ResourceIdentifier(feature.Data.Id.ToString() + "x");
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetFeatureResource(invalidId).GetAsync());
            Assert.That(ex.Status, Is.EqualTo(404));
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
            Assert.That(afterRegister.Data.Id, Is.EqualTo(feature.Data.Id));
            Assert.That(afterRegister.Data.Name, Is.EqualTo(feature.Data.Name));
            Assert.That(afterRegister.Data.Properties.State, Is.EqualTo("Pending"));
            Assert.That(afterRegister.Data.ResourceType, Is.EqualTo(feature.Data.ResourceType));

            FeatureResource afterUnRegister = await feature.UnregisterAsync();
            Assert.That(afterUnRegister.Data.Id, Is.EqualTo(feature.Data.Id));
            Assert.That(afterUnRegister.Data.Name, Is.EqualTo(feature.Data.Name));
            Assert.That(afterUnRegister.Data.Properties.State, Is.EqualTo("Unregistering"));
            Assert.That(afterUnRegister.Data.ResourceType, Is.EqualTo(feature.Data.ResourceType));
        }
    }
}
