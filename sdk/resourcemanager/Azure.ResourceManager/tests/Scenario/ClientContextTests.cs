using System;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Azure.Core.Pipeline;
using System.Threading;
using Azure.Core.TestFramework;
using System.Threading.Tasks;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Tests
{
    public class ClientContextTests : ResourceManagerTestBase
    {
        public ClientContextTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
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
            _ = await (await client1.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("testrg"));
            Assert.AreEqual(2, dummyPolicy1.numMsgGot);

            options1.AddPolicy(dummyPolicy2, HttpPipelinePosition.PerCall);

            _ = await (await client1.GetDefaultSubscriptionAsync().ConfigureAwait(false)).GetResourceGroups().Construct(Location.WestUS2).CreateOrUpdateAsync(Recording.GenerateAssetName("test2Rg-"));
            
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

        [TestCase]
        [RecordedTest]
        public void ValidateOptionsTestApiVersions()
        {
            var x = new ArmClientOptions();
            var y = x.Clone();
            Assert.IsFalse(ReferenceEquals(x.ApiVersions, y.ApiVersions));
            Assert.AreEqual(x.ApiVersions.TryGetApiVersion("{Microsoft.Resources/subscriptions/resourceGroups}"), y.ApiVersions.TryGetApiVersion("{Microsoft.Resources/subscriptions/resourceGroups}"));

            x.ApiVersions.SetApiVersion("{Microsoft.Resources/subscriptions/resourceGroups}", "1500-10-10");
            Assert.IsFalse(ReferenceEquals(x.ApiVersions, y.ApiVersions));
            Assert.AreNotEqual(x.ApiVersions, y.ApiVersions);
        }
    }
}
