using System;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Azure.Core.Pipeline;
using System.Threading;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources;

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
            Assert.AreEqual(2, dummyPolicy1.numMsgGot);

            options1.AddPolicy(dummyPolicy2, HttpPipelinePosition.PerCall);

            _ = await (await client1.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(AzureLocation.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test2Rg-"));
            
            Assert.AreEqual(3, dummyPolicy1.numMsgGot);
            Assert.AreEqual(0, dummyPolicy2.numMsgGot);
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
            var y = x.Clone();
            Assert.IsFalse(ReferenceEquals(x.ResourceApiVersions, y.ResourceApiVersions));

            var clientX = GetArmClient(x);
            var clientY = GetArmClient(y);
            var subX = await clientX.GetDefaultSubscriptionAsync();
            var subY = await clientY.GetDefaultSubscriptionAsync();
            var versionX = await subX.GetProviders().TryGetApiVersionAsync(ResourceGroup.ResourceType);
            var versionY = await subY.GetProviders().TryGetApiVersionAsync(ResourceGroup.ResourceType);
            Assert.AreEqual(versionX, versionY);
            Assert.AreNotEqual(versionY, fakeVersion);
            Assert.AreNotEqual(versionX, fakeVersion);

            x.SetApiVersion(ResourceGroup.ResourceType, fakeVersion);
            clientX = GetArmClient(x);
            subX = await clientX.GetDefaultSubscriptionAsync();
            Assert.IsFalse(ReferenceEquals(x.ResourceApiVersions, y.ResourceApiVersions));
            versionX = await subX.GetProviders().TryGetApiVersionAsync(ResourceGroup.ResourceType);
            versionY = await subY.GetProviders().TryGetApiVersionAsync(ResourceGroup.ResourceType);
            Assert.AreNotEqual(versionX, versionY);
        }
    }
}
