// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class SubscriptionOperationsTests : ResourceManagerTestBase
    {
        public SubscriptionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [SyncOnly]
        public void NoDataValidation()
        {
            ///subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c
            var resource = Client.GetSubscription(new ResourceIdentifier($"/subscriptions/{Guid.NewGuid()}"));
            Assert.Throws<InvalidOperationException>(() => { var data = resource.Data; });
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSubscriptionOperation()
        {
            Subscription sub = await Client.GetSubscriptions().GetIfExistsAsync(TestEnvironment.SubscriptionId);
            Assert.AreEqual(sub.Id.SubscriptionId, TestEnvironment.SubscriptionId);
        }

        [TestCase(null)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgNullException(string resourceGroupName)
        {
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentNullException)
            {
            }
        }

        [TestCase("te%st")]        
        [TestCase("te$st")]
        [TestCase("te#st")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsArgException(string resourceGroupName)
        {
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                ResourceGroup rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (RequestFailedException e) when (e.Status == 400)
            {
            }
        }

        [TestCase("")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsEmptyString(string resourceGroupName)
        {
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                ResourceGroup rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (ArgumentException)
            {
            }
        }

        [TestCase(91)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsOutOfRangeArgException(int length)
        {
            var resourceGroupName = GetLongString(length);
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                var rg = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected exception was not thrown");
            }
            catch (RequestFailedException e) when (e.Status == 400)
            {
            }
        }

        [TestCase("test ")]
        [TestCase("te.st")]
        [TestCase("te")]
        [TestCase("t")]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsValid(string resourceGroupName)
        {
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
            }
        }

        [TestCase(89)]
        [TestCase(90)]
        [RecordedTest]
        public async Task TestGetResourceGroupOpsLong(int length)
        {
            var resourceGroupName = GetLongString(length);
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            try
            {
                _ = await subOps.GetResourceGroups().GetAsync(resourceGroupName);
                Assert.Fail("Expected 404 from service");
            }
            catch(RequestFailedException e) when (e.Status == 404)
            {
            }
        }

        [RecordedTest]
        public async Task TestListLocations()
        {
            var subOps = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            var locations = await subOps.GetLocationsAsync().ToEnumerableAsync();
            Assert.IsTrue(locations.Count != 0);
            var location = locations.First();
            Assert.IsNotNull(location.Metadata, "Metadata was null");
            Assert.IsNotNull(location.Id, "Id was null");
            Assert.AreEqual(subOps.Id.SubscriptionId, location.SubscriptionId);
        }

        [RecordedTest]
        public async Task TestGetSubscription()
        {
            var subscription = await (await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetAsync();
            Assert.NotNull(subscription.Value.Data.Id);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => _ = await Client.GetSubscription(new ResourceIdentifier($"/subscriptions/{new Guid()}")).GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        private string GetLongString(int length)
        {
            StringBuilder builder = new StringBuilder();
            for(int i=0; i<length; i++)
            {
                builder.Append('a');
            }
            return builder.ToString();
        }

        [RecordedTest]
        public async Task ListFeatures()
        {
            Feature testFeature = null;
            Subscription subscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
            await foreach (var feature in subscription.GetFeaturesAsync())
            {
                testFeature = feature;
                break;
            }
            Assert.IsNotNull(testFeature);
            Assert.IsNotNull(testFeature.Data.Id);
            Assert.IsNotNull(testFeature.Data.Name);
            Assert.IsNotNull(testFeature.Data.Properties);
            Assert.IsNotNull(testFeature.Data.Type);
        }
    }
}
