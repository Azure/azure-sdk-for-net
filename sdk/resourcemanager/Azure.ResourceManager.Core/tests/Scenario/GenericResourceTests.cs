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
            : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public void LocalOneTimeSetup()
        {
            _rgName = SessionRecording.GenerateAssetName("testRg-");
            var subscriptionOperations = GlobalClient.GetSubscriptionOperations(SessionEnvironment.SubscriptionId);
            _ = subscriptionOperations.GetResourceGroups().Construct(_location).StartCreateOrUpdateAsync(_rgName).ConfigureAwait(false).GetAwaiter().GetResult().Value;
            StopSessionRecording();
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsConfirmException()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.Compute/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = Client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            try
            {
                await genericResourceOperations.GetAsync();
                Assert.Fail("No RequestFailedException thrown");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(ex.Status, 404);
                Assert.True(ex.Message.Contains("ResourceNotFound"));
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadNameSpace()
        {
            var asetid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}/providers/Microsoft.NotAValidNameSpace123/availabilitySets/testavset";
            ArmClientOptions options = new ArmClientOptions();
            _ = GetArmClient(options); // setup providers client
            var subOp = Client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, asetid);
            try
            {
                await genericResourceOperations.GetAsync();
                Assert.Fail("No InvalidOperationException thrown");
            }
            catch (InvalidOperationException ex)
            {
                Assert.IsTrue(ex.Message.Equals($"An invalid resouce id was given {asetid}"));
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsBadApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(rgid.ResourceType, "1500-10-10");
            var client = GetArmClient(options);
            var subOp = client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            try
            {
                await genericResourceOperations.GetAsync();
                Assert.Fail("No RequestFailedException thrown");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsTrue(ex.Message.Contains("InvalidApiVersionParameter"));
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task GetGenericsGoodApiVersion()
        {
            ResourceGroupResourceIdentifier rgid = $"/subscriptions/{TestEnvironment.SubscriptionId}/resourceGroups/{_rgName}";
            ArmClientOptions options = new ArmClientOptions();
            var client = GetArmClient(options);
            var subOp = client.GetSubscriptionOperations(TestEnvironment.SubscriptionId);
            var genericResourceOperations = new GenericResourceOperations(subOp, rgid);
            var rg = await genericResourceOperations.GetAsync();
            Assert.IsNotNull(rg.Value);
            Assert.IsTrue(rg.Value.Data.Name.Equals(_rgName));
        }
    }
}
