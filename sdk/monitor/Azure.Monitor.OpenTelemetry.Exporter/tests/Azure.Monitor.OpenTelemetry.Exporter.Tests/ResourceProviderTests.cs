// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ResourceProviderTests
    {
        [Fact]
        public void Verify_GetResourceProviderDetails_Default()
        {
            var platform = new MockPlatform();
            platform.OSPlatformName = "UnitTest";

            var resourceProviderDetails = ResourceProvider.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

            Assert.Equal("unknown", resourceProviderDetails.ResourceProvider);
            Assert.Equal("unknown", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("UnitTest", resourceProviderDetails.OperatingSystem);
        }

        [Fact]
        public void Verify_GetResourceProviderDetails_AppService1()
        {
            var platform = new MockPlatform();
            platform.OSPlatformName = "UnitTest";
            platform.SetEnvironmentVariable("WEBSITE_SITE_NAME", "testWebSite");

            var resourceProviderDetails = ResourceProvider.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

            Assert.Equal("appsvc", resourceProviderDetails.ResourceProvider);
            Assert.Equal("testWebSite", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("UnitTest", resourceProviderDetails.OperatingSystem);
        }

        [Fact]
        public void Verify_GetResourceProviderDetails_AppService2()
        {
            var platform = new MockPlatform();
            platform.OSPlatformName = "UnitTest";
            platform.SetEnvironmentVariable("WEBSITE_SITE_NAME", "testWebSite");
            platform.SetEnvironmentVariable("WEBSITE_HOME_STAMPNAME", "testStampName");

            var resourceProviderDetails = ResourceProvider.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

            Assert.Equal("appsvc", resourceProviderDetails.ResourceProvider);
            Assert.Equal("testWebSite/testStampName", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("UnitTest", resourceProviderDetails.OperatingSystem);
        }

        [Fact]
        public void Verify_GetResourceProviderDetails_Functions()
        {
            var platform = new MockPlatform();
            platform.OSPlatformName = "UnitTest";
            platform.SetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME", "test");
            platform.SetEnvironmentVariable("WEBSITE_HOSTNAME", "testHostName");

            var resourceProviderDetails = ResourceProvider.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

            Assert.Equal("functions", resourceProviderDetails.ResourceProvider);
            Assert.Equal("testHostName", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("UnitTest", resourceProviderDetails.OperatingSystem);
        }

        [Fact]
        public void Verify_GetResourceProviderDetails_AzureVM()
        {
            var platform = new MockPlatform();

            var vmMetadataProvider = new MockVmMetadataProvider
            {
                Response = new VmMetadataResponse
                {
                    osType = "UnitTest",
                    vmId = "testVmId",
                    subscriptionId = "testSubscriptionId",
                }
            };

            var resourceProviderDetails = ResourceProvider.GetResourceProviderDetails(platform, vmMetadataProvider);

            Assert.Equal("vm", resourceProviderDetails.ResourceProvider);
            Assert.Equal("testVmId/testSubscriptionId", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("unittest", resourceProviderDetails.OperatingSystem);
        }
    }
}
