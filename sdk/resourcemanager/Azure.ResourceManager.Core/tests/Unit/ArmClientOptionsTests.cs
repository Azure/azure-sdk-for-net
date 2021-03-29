using System;
using Azure.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class AzureResourceManagerClientOptionsTests
    {
        [TestCase]
        public void VersionIsDefault()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            Assert.AreEqual(FakeResourceApiVersions.Default, options.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void MultiClientSeparateVersions()
        {
            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();

            options2.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            Assert.AreEqual(FakeResourceApiVersions.Default, options1.FakeRestApiVersions().FakeResourceVersion);
            Assert.AreEqual(FakeResourceApiVersions.V2019_12_01, options2.FakeRestApiVersions().FakeResourceVersion);
        }

        [TestCase]
        public void TestClientOptionsParamCheck()
        {
            Assert.Throws<ArgumentNullException>(() => { new AzureResourceManagerClientOptions(null); });
            Assert.Throws<ArgumentNullException>(() => { new AzureResourceManagerClientOptions(null, null); });

            var options = new AzureResourceManagerClientOptions();
            Assert.Throws<ArgumentNullException>(() => { options.AddPolicy(null, HttpPipelinePosition.PerCall); });
        }

        [TestCase]
        public void VersionExist()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            string result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType);
            Assert.NotNull(result);
        }

        [TestCase]
        public void VersionLoadedChanges()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.V2019_12_01;
            string result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType);
            Assert.True(result.Equals(FakeResourceApiVersions.V2019_12_01));

            options.FakeRestApiVersions().FakeResourceVersion = FakeResourceApiVersions.Default;
            result = options.ApiVersions.TryGetApiVersion(options.FakeRestApiVersions().FakeResourceVersion.ResourceType.ToString());
            Assert.True(result.Equals(FakeResourceApiVersions.Default));
        }

        [TestCase]
        public void VersionsLoadedChangeSet()
        {
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
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
            var providerName = "providers/Microsoft.Logic/LogicApps";
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
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
            var providerName = "providers/Microsoft.Logic/LogicApps";
            AzureResourceManagerClientOptions options = new AzureResourceManagerClientOptions();
            string result = options.ApiVersions.TryGetApiVersion(providerName);
            Assert.Null(result);
        }
    }
}
