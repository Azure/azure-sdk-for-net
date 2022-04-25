using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
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
