using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Core.Tests.Scenario
{
    class ArmClientTests : ResourceManagerTestBase
    {
        private string _rgName;
        private readonly string _location = "southcentralus";
        
        public ArmClientTests(bool isAsync)
            : base(isAsync)
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

            foreach(GenericResourceOperations operations in genericResourceOperationsList)
            {
                Assert.AreEqual(operations.Id, ids[0]);
                ids.RemoveAt(0);
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericOperationsWithValidResource()
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
        public void GetGenericOperationsWithInvalidResource()
        {
            var ids = new List<string>()
            {
                $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/non-existant/"
            };

            var genericResourceOperationsList = Client.GetGenericResourceOperations(ids);

            foreach (GenericResourceOperations operations in genericResourceOperationsList)
            {
                RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await operations.GetAsync());
                Assert.AreEqual(404, exception.Status);
            }
        }

        [TestCase]
        public void TestNullGetGenericResourceOperation()
        {
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResourceOperations(null); });
        }

        [TestCase]
        public void TestEmptyGetGenericResourceOperation()
        {
            var ids = new List<string>();
            bool x = ids.Any();
            Assert.Throws<ArgumentNullException>(() => { Client.GetGenericResourceOperations(ids); });
        }
    }
}
