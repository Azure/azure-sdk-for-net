using NUnit.Framework;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Core.Tests
{
    public class ArmBuilderTests
    {
        [TestCase(null)]
        [TestCase(" ")]
        public void TestCreateOrUpdate(string value)
        {
            var armClient = new AzureResourceManagerClient();
            Assert.Throws<ArgumentException>(delegate { armClient.DefaultSubscription.GetResourceGroupContainer().Construct(LocationData.WestUS2).CreateOrUpdate(value); });
        }

        [TestCase(null)]
        [TestCase("  ")]
        public void TestCreateOrUpdateAsync(string value)
        {
            var armClient = new AzureResourceManagerClient();
            Assert.ThrowsAsync<ArgumentException>(async delegate { await armClient.DefaultSubscription.GetResourceGroupContainer().Construct(LocationData.WestUS2).CreateOrUpdateAsync(value); });
        }

        [TestCase(null)]
        [TestCase("")]
        public void TestStartCreateOrUpdate(string value)
        {
            var armClient = new AzureResourceManagerClient();
            Assert.Throws<ArgumentException>(delegate { armClient.DefaultSubscription.GetResourceGroupContainer().Construct(LocationData.WestUS2).StartCreateOrUpdate(value); });
        }

        [TestCase(null)]
        [TestCase("    ")]
        public void TestStartCreateOrUpdateAsync(string value)
        {
            var armClient = new AzureResourceManagerClient();
            Assert.ThrowsAsync<ArgumentException>(async delegate { await armClient.DefaultSubscription.GetResourceGroupContainer().Construct(LocationData.WestUS2).StartCreateOrUpdateAsync(value); });
        }
    }
}
