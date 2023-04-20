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
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_EU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Theory]
        [MemberData(nameof(NonEuEndpoints))]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInNonEU(string nonEUEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEUEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform());

            Assert.Equal(StatsbeatConstants.Statsbeat_ConnectionString_NonEU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public void StatsbeatIsNotInitializedForUnknownRegions()
        {
            var customer_ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorStatsbeat(connectionStringVars, new MockPlatform()));
        }
    }
}
