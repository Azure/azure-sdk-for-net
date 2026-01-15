using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    public class ClientContextTests : ResourceManagerTestBase
    {
        public ClientContextTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TestClientContextPolicy()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            var dummyPolicy1 = new dummyPolicy();
            var dummyPolicy2 = new dummyPolicy2();
            options1.AddPolicy(dummyPolicy1, HttpPipelinePosition.PerCall);
            var client1 = GetArmClient(options1);
            
            Console.WriteLine("-----Client 1-----");
            _ = await (await client1.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            Assert.That(dummyPolicy1.numMsgGot, Is.EqualTo(2));

            options1.AddPolicy(dummyPolicy2, HttpPipelinePosition.PerCall);

            _ = await (await client1.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test2Rg-"));

            Assert.That(dummyPolicy1.numMsgGot, Is.EqualTo(3));
            Assert.That(dummyPolicy2.numMsgGot, Is.EqualTo(0));
        }

        private class dummyPolicy : HttpPipelineSynchronousPolicy
        {
            public int numMsgGot = 0;

            public override void OnReceivedResponse(HttpMessage message)
            {
                Interlocked.Increment(ref numMsgGot);
            }
        }

        private class dummyPolicy2 : HttpPipelineSynchronousPolicy
        {
            public int numMsgGot = 0;

            public override void OnReceivedResponse(HttpMessage message)
            {
                Interlocked.Add(ref numMsgGot, 2);
            }
        }

        [RecordedTest]
        public async Task ValidateOptionsTestApiVersions()
        {
            var fakeVersion = "1500-10-10";
            var x = new ArmClientOptions();
            var y = new ArmClientOptions();

            var clientX = GetArmClient(x);
            var clientY = GetArmClient(y);
            var subX = await clientX.GetDefaultSubscriptionAsync();
            var subY = await clientY.GetDefaultSubscriptionAsync();
            var versionX = await subX.GetResourceProviders().GetApiVersionAsync(ResourceGroupResource.ResourceType);
            var versionY = await subY.GetResourceProviders().GetApiVersionAsync(ResourceGroupResource.ResourceType);
            Assert.That(versionY, Is.EqualTo(versionX));
            Assert.That(fakeVersion, Is.Not.EqualTo(versionY));
            Assert.That(fakeVersion, Is.Not.EqualTo(versionX));

            x = new ArmClientOptions();
            x.SetApiVersion(ResourceGroupResource.ResourceType, fakeVersion);
            clientX = GetArmClient(x);
            subX = await clientX.GetDefaultSubscriptionAsync();
            versionX = await subX.GetResourceProviders().GetApiVersionAsync(ResourceGroupResource.ResourceType);
            versionY = await subY.GetResourceProviders().GetApiVersionAsync(ResourceGroupResource.ResourceType);
            Assert.That(versionY, Is.Not.EqualTo(versionX));
        }
    }
}
