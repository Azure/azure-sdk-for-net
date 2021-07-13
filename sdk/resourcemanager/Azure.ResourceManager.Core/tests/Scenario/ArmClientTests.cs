using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    class ArmClientTests : ResourceManagerTestBase
    {
        private string _rgName;
        private readonly string _location = "southcentralus";

        public ArmClientTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [OneTimeSetUp]
        public async Task LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            var subscription = await GlobalClient.GetSubscriptions().TryGetAsync(SessionEnvironment.SubscriptionId);
            _ = subscription.GetResourceGroups().Construct(_location).StartCreateOrUpdateAsync(_rgName).ConfigureAwait(false).GetAwaiter().GetResult().Value;
            StopSessionRecording();
        }

        [TestCase]
        [Ignore("4622 needs complete with a Mocked example to fill in this test")]
        public void CreateResourceFromId()
        {
            //TODO: 4622 needs complete with a Mocked example to fill in this test
            //public ArmResponse<TOperations> CreateResource<TContainer, TOperations, TResource>(string subscription, string resourceGroup, string name, TResource model, azure_proto_core.Location location = default)
        }

        [TestCase]
        public void TestArmClientParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(baseUri: null, null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(defaultSubscriptionId: null, null, null); });
        }

        [TestCase]
        public void GetGenericOperationsTests()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-2/",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-3/",
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-4/"
            };

            var genericResourceOperationsList = Client.GetGenericResourceOperations(ids);

            foreach (GenericResourceOperations operations in genericResourceOperationsList)
            {
                Assert.AreEqual(ids[0], operations.Id.StringValue);
                ids.RemoveAt(0);
            }
        }

        [TestCase]
        public void GetGenericResourcesOperationsTests()
        {
            string id = $"/providers/Microsoft.Compute/virtualMachines/myVm";
            Assert.AreEqual(id, Client.GetGenericResourceOperations(new TenantResourceIdentifier(id)).Id.StringValue);
        }

        [TestCase]
        public void GetGenericResourceOperationsSingleIDTests()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/";
            Assert.AreEqual(id, Client.GetGenericResourceOperations(id).Id.StringValue);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericResourceOperationsWithSingleValidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/";
            var genericResourceOperations = Client.GetGenericResourceOperations(id);
            var genericResource = await genericResourceOperations.GetAsync();
            Assert.AreEqual(200, genericResource.GetRawResponse().Status);
        }

        [TestCase]
        [RecordedTest]
        public void GetGenericResourceOperationsWithSingleInvalidResource()
        {
            string id = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/foo-1/";
            var genericResourceOperations = Client.GetGenericResourceOperations(id);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericOperationsWithListOfValidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/"
            };

            var genericResourceOperationsList = Client.GetGenericResourceOperations(ids);

            foreach (GenericResourceOperations operations in genericResourceOperationsList)
            {
                var genericResource = await operations.GetAsync();
                Assert.AreEqual(200, genericResource.GetRawResponse().Status);
            }
        }

        [TestCase]
        [RecordedTest]
        public void GetGenericOperationsWithListOfInvalidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/non-existent/"
            };

            var genericResourceOperationsList = Client.GetGenericResourceOperations(ids);

            foreach (GenericResourceOperations operations in genericResourceOperationsList)
            {
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operations.GetAsync());
                Assert.AreEqual(404, exception.Status);
            }
        }

        [TestCase]
        public void GetGenericResourceOperationWithNullSetOfIds()
        {
            string[] x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResourceOperations(x); });
        }

        [TestCase]
        public void GetGenericResourceOperationWithNullId()
        {
            string x = null;
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResourceOperations(x); });
        }

        [TestCase]
        public void GetGenericResourceOperationEmptyTest()
        {
            var ids = new List<string>();
            Assert.AreEqual(new List<string>(), Client.GetGenericResourceOperations(ids));
        }
    }
}
