using System;
using System.Linq;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ArmClientOptionsTests
    {
        [Test]
        public void DoubleAddOverride()
        {
            var vmType = new ResourceType("Microsoft.Compute/virtualMachines");
            var options = new ArmClientOptions();
            options.SetApiVersion(vmType, "foo");
            options.SetApiVersion(vmType, "bar");
            options.ResourceApiVersionOverrides.TryGetValue(vmType, out var actualVersion);
            Assert.AreEqual("bar", actualVersion);
        }

        [Test]
        public void CaseInsensitiveAddOverride()
        {
            var options = new ArmClientOptions();
            options.SetApiVersion("Microsoft.Compute/virtualMachines", "foo");
            options.ResourceApiVersionOverrides.TryGetValue("microsoft.compute/virtualmachines", out var actualVersion);
            Assert.AreEqual("foo", actualVersion);
            options.SetApiVersion("MICROSOFT.COMPUTE/VIRTUALMACHINES", "bar");
            options.ResourceApiVersionOverrides.TryGetValue("Microsoft.Compute/virtualMachines", out actualVersion);
            Assert.AreEqual("bar", actualVersion);
        }

        [Test]
        public void SetApiVersionsFromProfile()
        {
            var options = new ArmClientOptions();
            options.SetApiVersionsFromProfile(AzureStackProfile.Profile20200901Hybrid);
            options.ResourceApiVersionOverrides.TryGetValue("Microsoft.Resources/subscriptions", out var subscriptionApiVersion);
            Assert.AreEqual("2016-06-01", subscriptionApiVersion);
            options.ResourceApiVersionOverrides.TryGetValue("Microsoft.Resources/resourceGroups", out var resourceGroupApiVersion);
            Assert.AreEqual("2019-10-01", resourceGroupApiVersion);
        }

        [Test]
        public void SetApiVersionsFromProfileWithApiVersionOverride()
        {
            var options = new ArmClientOptions();
            options.SetApiVersion("Microsoft.Resources/Subscriptions", "2021-01-01");
            options.SetApiVersionsFromProfile(AzureStackProfile.Profile20200901Hybrid);
            options.SetApiVersion("microsoft.resources/ResourceGroups", "2021-01-01");
            options.ResourceApiVersionOverrides.TryGetValue("Microsoft.Resources/subscriptions", out var subscriptionApiVersion);
            Assert.AreEqual("2016-06-01", subscriptionApiVersion);
            options.ResourceApiVersionOverrides.TryGetValue("Microsoft.Resources/resourceGroups", out var resourceGroupApiVersion);
            Assert.AreEqual("2021-01-01", resourceGroupApiVersion);
        }

        [Test]
        public void EnsureAllProfilesCanGetManifestName()
        {
            var values = Enum.GetValues(typeof(AzureStackProfile)).Cast<AzureStackProfile>();
            foreach (var value in values)
            {
                var name = value.GetManifestName();
                Assert.NotNull(name);
            }
        }

        [TestCase]
        public void ValidateInvalidVersionSet()
        {
            var options = new ArmClientOptions();
            Assert.Throws<ArgumentException>(() => { options.SetApiVersion(new ResourceType("Microsoft.Compute/virtualMachines"), ""); });
            Assert.Throws<ArgumentNullException>(() => { options.SetApiVersion(new ResourceType("Microsoft.Compute/virtualMachines"), null); });
        }

        [TestCase]
        [Ignore("Waiting for ADO 5402")]
        public void VersionExist()
        {
            //verify default version from enum is found during api call
        }

        [TestCase]
        [Ignore("Waiting for ADO 5402")]
        public void VersionLoadedChanges()
        {
            //verify override is taken instead of default enum in api call
        }
    }
}
