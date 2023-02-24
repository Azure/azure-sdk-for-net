// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StatsbeatTests
    {
        [Theory]
        [InlineData("francecentral")]
        [InlineData("francesouth")]
        [InlineData("northeurope")]
        [InlineData("norwayeast")]
        [InlineData("norwaywest")]
        [InlineData("swedencentral")]
        [InlineData("switzerlandnorth")]
        [InlineData("switzerlandwest")]
        [InlineData("uksouth")]
        [InlineData("ukwest")]
        [InlineData("westeurope")]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInEU(string euEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars);

            Assert.Equal(AzureMonitorStatsbeat.Statsbeat_ConnectionString_EU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Theory]
        [InlineData("australiacentral")]
        [InlineData("australiacentral2")]
        [InlineData("australiaeast")]
        [InlineData("australiasoutheast")]
        [InlineData("brazilsouth")]
        [InlineData("brazilsoutheast")]
        [InlineData("canadacentral")]
        [InlineData("canadaeast")]
        [InlineData("centralindia")]
        [InlineData("centralus")]
        [InlineData("chinaeast2")]
        [InlineData("chinaeast3")]
        [InlineData("chinanorth3")]
        [InlineData("eastasia")]
        [InlineData("eastus")]
        [InlineData("eastus2")]
        [InlineData("japaneast")]
        [InlineData("japanwest")]
        [InlineData("jioindiacentral")]
        [InlineData("jioindiawest")]
        [InlineData("koreacentral")]
        [InlineData("koreasouth")]
        [InlineData("northcentralus")]
        [InlineData("qatarcentral")]
        [InlineData("southafricanorth")]
        [InlineData("southcentralus")]
        [InlineData("southeastasia")]
        [InlineData("southindia")]
        [InlineData("uaecentral")]
        [InlineData("uaenorth")]
        [InlineData("westus")]
        [InlineData("westus2")]
        [InlineData("westus3")]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInNonEU(string nonEUEndpoint)
        {
            var customer_ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://{nonEUEndpoint}.in.applicationinsights.azure.com/";
            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            var statsBeatInstance = new AzureMonitorStatsbeat(connectionStringVars);

            Assert.Equal(AzureMonitorStatsbeat.Statsbeat_ConnectionString_NonEU, statsBeatInstance._statsbeat_ConnectionString);
        }

        [Fact]
        public void StatsbeatIsNotInitializedForUnknownRegions()
        {
            var customer_ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";

            var connectionStringVars = ConnectionStringParser.GetValues(customer_ConnectionString);
            Assert.Throws<InvalidOperationException>(() => new AzureMonitorStatsbeat(connectionStringVars));
        }
    }
}
