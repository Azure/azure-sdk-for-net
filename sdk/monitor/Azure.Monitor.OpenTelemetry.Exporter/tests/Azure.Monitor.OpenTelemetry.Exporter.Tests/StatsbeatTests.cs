// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StatsbeatTests
    {
        public static TheoryData<string> EuEndpoints
        {
            get
            {
                var data = new TheoryData<string>();
                foreach (var e in StatsbeatConstants.s_EU_Endpoints.AsEnumerable())
                {
                    data.Add(e);
                }
                return data;
            }
        }

        public static TheoryData<string> NonEuEndpoints
        {
            get
            {
                var data = new TheoryData<string>();
                foreach (var e in StatsbeatConstants.s_non_EU_Endpoints.AsEnumerable())
                {
                    data.Add(e);
                }
                return data;
            }
        }

        [Theory]
        [MemberData(nameof(EuEndpoints))]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInEU(string euEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform(), new MockVmMetadataProvider());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_EU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Theory]
        [MemberData(nameof(NonEuEndpoints))]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInNonEU(string nonEUEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEUEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform(), new MockVmMetadataProvider());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_NonEU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public void StatsbeatIsNotInitializedForUnknownRegions()
        {
            var customer_ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform(), new MockVmMetadataProvider()));
        }

        [Fact]
        public void Verify_GetResourceProviderDetails_Default()
        {
            var platform = new MockPlatform();
            platform.OSPlatformName = "UnitTest";

            var resourceProviderDetails = AzureMonitorStatsbeat.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

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

            var resourceProviderDetails = AzureMonitorStatsbeat.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

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

            var resourceProviderDetails = AzureMonitorStatsbeat.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

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

            var resourceProviderDetails = AzureMonitorStatsbeat.GetResourceProviderDetails(platform, new MockVmMetadataProvider());

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

            var resourceProviderDetails = AzureMonitorStatsbeat.GetResourceProviderDetails(platform, vmMetadataProvider);

            Assert.Equal("vm", resourceProviderDetails.ResourceProvider);
            Assert.Equal("testVmId/testSubscriptionId", resourceProviderDetails.ResourceProviderId);
            Assert.Equal("unittest", resourceProviderDetails.OperatingSystem);
        }
    }
}
