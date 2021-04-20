using System.Runtime.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Identity;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class GenericResourceTests : ResourceManagerTestBase
    {
        private string _rgName;

        private readonly string _location = "southcentralus";

        public GenericResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
        [RecordedTest]
        public async Task GetGenericsConfirmException()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = await Client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.AreEqual(404, exception.Status);
            Assert.True(exception.Message.Contains("ResourceNotFound"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadNameSpace()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = await Client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Equals($"An invalid resouce id was given {asetid}"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(rgid.ResourceType, "1500-10-10");
            var client = GetArmClient(options);
            var subOp = await client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(async () => await genericResourceOperations.GetAsync());
            Assert.IsTrue(exception.Message.Contains("InvalidApiVersionParameter"));
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsGoodApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            var client = GetArmClient(options);
            var subOp = await client.GetSubscriptions().TryGetAsync(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            var rg = await genericResourceOperations.GetAsync();
            Assert.IsNotNull(rg.Value);
            Assert.IsTrue(rg.Value.Data.Name.Equals(_rgName));
        }
    }
}
