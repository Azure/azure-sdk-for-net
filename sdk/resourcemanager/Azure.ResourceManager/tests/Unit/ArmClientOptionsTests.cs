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
            options.TryGetApiVersion(vmType, out var actualVersion);
            Assert.AreEqual("bar", actualVersion);
        }

        [TestCase]
        public void ValidateClone()
        {
            var options1 = new ArmClientOptions();
            var options2 = options1.Clone();

            Assert.IsFalse(ReferenceEquals(options1, options2));
            Assert.IsFalse(ReferenceEquals(options1.Diagnostics, options2.Diagnostics));
            Assert.IsFalse(ReferenceEquals(options1.Retry, options2.Retry));
            Assert.IsFalse(ReferenceEquals(options1.ResourceApiVersions, options2.ResourceApiVersions));
            Assert.IsFalse(ReferenceEquals(options1.NamespaceVersions, options2.NamespaceVersions));
        }

        [TestCase]
        public void ValidateInvalidVersionSet()
        {
            var options = new ArmClientOptions();
            Assert.Throws<ArgumentException>(() => { options.SetApiVersion(new ResourceType("Microsoft.Compute/virtualMachines"), ""); });
            Assert.Throws<ArgumentNullException>(() => { options.SetApiVersion(new ResourceType("Microsoft.Compute/virtualMachines"), null); });
        }

        [TestCase]
        public void TestTransportInClone()
        {
            var x = new ArmClientOptions();
            x.Transport = new MyTransport();
            var y = x.Clone();
            Assert.IsTrue(ReferenceEquals(x.Transport, y.Transport));

            x.Transport = new MyTransport();
            Assert.IsFalse(ReferenceEquals(y.Transport, x.Transport));
        }

        private class MyTransport : HttpPipelineTransport
        {
            public override Request CreateRequest()
            {
                throw new NotImplementedException();
            }

            public override void Process(HttpMessage message)
            {
                throw new NotImplementedException();
            }

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                throw new NotImplementedException();
            }
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
