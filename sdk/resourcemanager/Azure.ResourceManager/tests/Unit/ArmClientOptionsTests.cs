using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ArmClientOptionsTests : ResourceManagerTestBase
    {
        public ArmClientOptionsTests(bool isAsync) : base(isAsync) { }

        [TestCase]
        public void ValidateClone()
        {
            var options1 = new ArmClientOptions();
            var options2 = options1.Clone();

            Assert.IsFalse(ReferenceEquals(options1, options2));
            Assert.IsFalse(ReferenceEquals(options1.Diagnostics, options2.Diagnostics));
            Assert.IsFalse(ReferenceEquals(options1.Retry, options2.Retry));
            Assert.IsFalse(ReferenceEquals(options1.ApiVersions, options2.ApiVersions));
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
        public void VersionIsDefault()
        {
            ArmClientOptions options = new ArmClientOptions();
            Assert.AreEqual(FakeResourceApiVersions.Default, options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void MultiClientSeparateVersions()
        {
            ArmClientOptions options1 = new ArmClientOptions();
            ArmClientOptions options2 = new ArmClientOptions();

            options2.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            Assert.AreEqual(FakeResourceApiVersions.Default, options1.FakeRestApiVersions().FakeResourceVersion);
            Assert.AreEqual(FakeResourceApiVersions.V2019_12_01, options2.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        [Ignore("Waiting for ADO 5402")]
        public void VersionExist()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            string result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType);
            Assert.NotNull(result);
        }

        [TestCase]
        [Ignore("Waiting for ADO 5402")]
        public void VersionLoadedChanges()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            string result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType);
            Assert.True(result.Equals(FakeResourceApiVersions.V2019_12_01));

            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.Default;
            result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType.ToString());
            Assert.True(result.Equals(FakeResourceApiVersions.Default));
        }

        [TestCase]
        [Ignore("Waiting for ADO 5402")]
        public void VersionsLoadedChangeSet()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType.ToString(), "2021-01-01-beta");
            string result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType.ToString());
            Assert.True(result.Equals("2021-01-01-beta"));

            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType.ToString());
            Assert.True(result.Equals(FakeResourceApiVersions.V2019_12_01));
        }

        [TestCase]
        public void VersionNonLoadedChanges()
        {
            var apiVersions = "2019-10-01";
            var providerName = "Microsoft.Logic/LogicApps";
            ArmClientOptions options = new ArmClientOptions();
            options.ApiVersions.SetApiVersion(providerName, apiVersions);
            string result = options.ApiVersions.TryGetApiVersion(providerName);
            Assert.True(result.Equals(apiVersions));

            apiVersions = "2021-02-01";
            options.ApiVersions.SetApiVersion(providerName, apiVersions);
            result = options.ApiVersions.TryGetApiVersion(providerName);
            Assert.True(result.Equals(apiVersions));
        }

        [TestCase]
        public void TestKeyDoesNotExist()
        {
            var providerName = "Microsoft.Logic/LogicApps";
            ArmClientOptions options = new ArmClientOptions();
            string result = options.ApiVersions.TryGetApiVersion(providerName);
            Assert.Null(result);
        }
    }
}
