using System;
using System.Threading.Tasks;
using Azure.Core;
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
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

        private class TestObjectWithClosure
        {
            public ArmClient Client { get; }
            public ResourceIdentifier Id { get; }

            public TestObjectWithClosure(ArmClient client, ResourceIdentifier id)
            {
                Client = client;
                Id = id;
            }
        }

        private class ArmClientExtensionClient : ArmResource
        {
            public ArmClientExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
            {
            }

            public TestObjectWithClosure GetTestObject()
            {
                return GetCachedClient(Client => new TestObjectWithClosure(Client, Id));
            }
        }

        [RecordedTest]
        public async Task GetCachedClientWithClosure()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceIdentifier scope1 = new(subscription.Id + "/resourceGroups/rg1");
            var extensionClient1 = new ArmClientExtensionClient(Client, scope1);
            var obj1 = extensionClient1.GetTestObject();
            var obj2 = extensionClient1.GetTestObject();
            Assert.IsTrue(ReferenceEquals(obj1, obj2));
            Assert.IsTrue(ReferenceEquals(obj1.Client, obj2.Client));
            ResourceIdentifier scope2 = new(subscription.Id + "/resourceGroups/rg2");
            var extensionClient2 = new ArmClientExtensionClient(Client, scope2);
            var obj3 = extensionClient2.GetTestObject();
            Assert.IsFalse(ReferenceEquals(obj1, obj3));
            Assert.IsTrue(ReferenceEquals(obj1.Client, obj3.Client));
        }
    }
}
