using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    class ArmClientTests : ResourceManagerTestBase
    {
        private string _rgName;
        private readonly string _location = "southcentralus";

        public ArmClientTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            Subscription subscription = await GlobalClient.GetSubscriptions().GetIfExistsAsync(SessionEnvironment.SubscriptionId);
            _ = subscription.GetResourceGroups().Construct(_location).StartCreateOrUpdateAsync(_rgName).ConfigureAwait(false).GetAwaiter().GetResult().Value;
            StopSessionRecording();
        }

        [RecordedTest]
        [SyncOnly]
        public void ConstructWithInvalidSubscription()
        {
            var ex = Assert.Throws<RequestFailedException>(() => new ArmClient(Guid.NewGuid().ToString(), TestEnvironment.Credential));
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public void TestArmClientParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(baseUri: null, null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(defaultSubscriptionId: null, null, null); });
        }

        [RecordedTest]
        public void GetGenericOperationsTests()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-2",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-3",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-4"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            int index = 0;
            foreach (GenericResource operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[index], operations.Id.StringValue);
                index++;
            }

            genericResourceOperationsList = Client.GetGenericResources(ids[0], ids[1], ids[2], ids[3]);

            index = 0;
            foreach (GenericResource operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[index], operations.Id.StringValue);
                index++;
            }
        }

        [RecordedTest]
        public void GetGenericResourcesOperationsTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/providers/Microsoft.Compute/virtualMachines/myVm";
            Assert.AreEqual(id, Client.GetGenericResource(new ResourceIdentifier(id)).Id.StringValue);
        }

        [RecordedTest]
        public void GetGenericResourceOperationsSingleIDTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            Assert.AreEqual(id, Client.GetGenericResource(id).Id.StringValue);
        }

        [RecordedTest]
        public async Task GetGenericResourceOperationsWithSingleValidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            var genericResourceOperations = Client.GetGenericResource(id);
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.AreEqual(200, genericResource.GetRawResponse().Status);
        }

        [RecordedTest]
        public void GetGenericResourceOperationsWithSingleInvalidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1";
            var genericResourceOperations = Client.GetGenericResource(id);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        [RecordedTest]
        public async Task GetGenericOperationsWithListOfValidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            foreach (GenericResource operations in genericResourceOperationsList)
            {
                var genericResource = await operations.GetAsync();
                Assert.AreEqual(200, genericResource.GetRawResponse().Status);
            }
        }

        [RecordedTest]
        public void GetGenericOperationsWithListOfInvalidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/non-existent"
            };

            var genericResourceOperationsList = Client.GetGenericResources(ids);

            foreach (GenericResource operations in genericResourceOperationsList)
            {
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operations.GetAsync());
                Assert.AreEqual(404, exception.Status);
            }
        }

        [RecordedTest]
        public void GetGenericResourceOperationWithNullSetOfIds()
        {
            string[] x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResources(x); });
        }

        [RecordedTest]
        public void GetGenericResourceOperationWithNullId()
        {
            string x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResource(x); });
        }

        [RecordedTest]
        public void GetGenericResourceOperationEmptyTest()
        {
            var ids = new List<string>();
            Assert.AreEqual(new List<string>(), Client.GetGenericResources(ids));
        }
    }
}
