// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class StatsbeatTests
    {
        [Fact]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInEU()
        {
            var customer_ConnectionString = "InstrumentationKey=1aa11111-bbbb-1ccc-8ddd-eeeeffff3333;IngestionEndpoint=https://northeurope-0.in.applicationinsights.azure.com/";
            ConnectionStringParser.GetValues(customer_ConnectionString, out string instrumentationKey, out string ingestionEndpoint);

            // Set ConnectionString to null as it is static and may be impacted by other tests.
            Statsbeat.s_statsBeat_ConnectionString = null;
            Statsbeat.SetStatsbeatConnectionString(ingestionEndpoint);

            Assert.Equal(Statsbeat.StatsBeat_ConnectionString_EU, Statsbeat.s_statsBeat_ConnectionString);
        }

        [Fact]
        public void StatsbeatConnectionStringIsSetBasedOnCustomersConnectionStringEndpointInNonEU()
        {
            var customer_ConnectionString = "InstrumentationKey=1aa11111-bbbb-1ccc-8ddd-eeeeffff3333;IngestionEndpoint=https://westus-2.in.applicationinsights.azure.com/";
            ConnectionStringParser.GetValues(customer_ConnectionString, out string instrumentationKey, out string ingestionEndpoint);

            // Set ConnectionString to null as it is static and may be impacted by other tests.
            Statsbeat.s_statsBeat_ConnectionString = null;
            Statsbeat.SetStatsbeatConnectionString(ingestionEndpoint);

            Assert.Equal(Statsbeat.StatsBeat_ConnectionString_NonEU, Statsbeat.s_statsBeat_ConnectionString);
        }
    }
}
