using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    internal class ArmResourceTests : ResourceManagerTestBase
    {
        public ArmResourceTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private class TestObject
        {
            public ArmClient Client { get; }

            public TestObject(ArmClient client)
            {
                Client = client;
            }
        }

        [RecordedTest]
        public async Task GetCachedClient()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            Func<ArmClient, TestObject> factory = (armClient) => { return new TestObject(armClient); };
            TestObject obj1 = subscription.GetCachedClient(factory);
            Assert.IsNotNull(obj1);
            Assert.IsNotNull(obj1.Client);
            TestObject obj2 = subscription.GetCachedClient(factory);
            Assert.IsNotNull(obj2);
            Assert.IsNotNull(obj2.Client);
            Assert.IsTrue(ReferenceEquals(obj1, obj2));
            Assert.IsTrue(ReferenceEquals(obj1.Client, obj2.Client));
        }
    }
}
