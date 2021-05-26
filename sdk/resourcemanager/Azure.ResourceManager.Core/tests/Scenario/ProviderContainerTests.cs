using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;

namespace Azure.ResourceManager.Core.Tests
{
    public class ProviderContainerTests : ResourceManagerTestBase
    {
        public ProviderContainerTests(bool isAsync)
         : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public void Get()
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            Assert.IsNotNull(providerContainer.Id);
            providerContainer.List();
        }

        [TestCase]
        [RecordedTest]
        public void List()
        {
            var providerContainer = Client.DefaultSubscription.GetProviders();
            var x = providerContainer.List();
            foreach (var p in x)
            {
                Console.WriteLine(p.Id);
            }
        }
    }
}
