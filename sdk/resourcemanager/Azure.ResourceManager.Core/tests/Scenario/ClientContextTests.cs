using System;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using Azure.Core.Pipeline;
using System.Threading;
using Azure.Core.TestFramework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
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
            await foreach (var sub in client1.GetSubscriptions().ListAsync())
            {
                Console.WriteLine($"Check 1: Found {sub.Data.DisplayName}");
            }
            Assert.AreEqual(2, dummyPolicy1.numMsgGot);

            options1.AddPolicy(dummyPolicy2, HttpPipelinePosition.PerCall);
            await foreach (var sub in client1.GetSubscriptions().ListAsync())
            {
                Console.WriteLine($"Check 2: Found {sub.Data.DisplayName}");
            }

            Assert.AreEqual(3, dummyPolicy1.numMsgGot);
            //Assert.AreEqual(0, dummyPolicy2.numMsgGot); uncomment for ADO #5572
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
    }
}
