// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
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
            var customer_ConnectionString = $"InstrumentationKey=1aa11111-bbbb-1ccc-8ddd-eeeeffff3333;IngestionEndpoint=https://{euEndpoint}.in.applicationinsights.azure.com/";
            var parsedConectionString = ConnectionStringParser.GetValues(customer_ConnectionString);

            Statsbeat.SetStatsbeatConnectionString(parsedConectionString.IngestionEndpoint);

            Assert.Equal(Statsbeat.StatsBeat_ConnectionString_EU, Statsbeat.s_statsBeat_ConnectionString);

            // Reset Statsbeat Connection String
            Statsbeat.s_statsBeat_ConnectionString = null;
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
            var customer_ConnectionString = $"InstrumentationKey=1aa11111-bbbb-1ccc-8ddd-eeeeffff3333;IngestionEndpoint=https://{nonEUEndpoint}.in.applicationinsights.azure.com/";
            var parsedConectionString = ConnectionStringParser.GetValues(customer_ConnectionString);

            Statsbeat.SetStatsbeatConnectionString(parsedConectionString.IngestionEndpoint);

            Assert.Equal(Statsbeat.StatsBeat_ConnectionString_NonEU, Statsbeat.s_statsBeat_ConnectionString);

            // Reset Statsbeat Connection String
            Statsbeat.s_statsBeat_ConnectionString = null;
        }

        [Fact]
        public void StatsbeatIsNotInitializedForUnknownRegions()
        {
            var customer_ConnectionString = "InstrumentationKey=1aa11111-bbbb-1ccc-8ddd-eeeeffff3333;IngestionEndpoint=https://foo.in.applicationinsights.azure.com/";
            var parsedConectionString = ConnectionStringParser.GetValues(customer_ConnectionString);

            Statsbeat.SetStatsbeatConnectionString(parsedConectionString.IngestionEndpoint);

            Assert.Null(Statsbeat.s_statsBeat_ConnectionString);

            // Reset Statsbeat Connection String
            Statsbeat.s_statsBeat_ConnectionString = null;
        }
    }
}
