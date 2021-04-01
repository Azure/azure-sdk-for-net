using System;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class ArmClientTests
    {
        [TestCase]
        public void CreateResourceFromId()
        {
            //TODO: 4622 needs complete with a Mocked example to fill in this test
            //public ArmResponse<TOperations> CreateResource<TContainer, TOperations, TResource>(string subscription, string resourceGroup, string name, TResource model, azure_proto_core.Location location = default)
            Assert.Ignore();
        }

        [TestCase]
        public void TestArmClientParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(baseUri:null, null, null); });
            Assert.Throws<ArgumentNullException>(() => { new ArmClient(defaultSubscriptionId: null, null, null); });
        }
    }
}
