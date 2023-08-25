// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class ConnectionStringParserTests
    {
        [Fact]
        public void TestConnectionString_Full()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://ingestion.azuremonitor.com/;LiveEndpoint=https://live.azuremonitor.com/;AADAudience=https://monitor.azure.com//testing",
                expectedIngestionEndpoint: "https://ingestion.azuremonitor.com/",
                expectedLiveEndpoint: "https://live.azuremonitor.com/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000",
                expectedAadAudience: "https://monitor.azure.com//testing");
        }

        [Fact]
        public void TestInstrumentationKey_IsRequired()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "EndpointSuffix=ingestion.azuremonitor.com",
                expectedIngestionEndpoint: null,
                expectedLiveEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Fact]
        public void TestInstrumentationKey_CannotBeEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "InstrumentationKey=;EndpointSuffix=ingestion.azuremonitor.com",
                expectedIngestionEndpoint: null,
                expectedLiveEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Fact]
        public void TestDefaultEndpoints()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000",
                expectedIngestionEndpoint: Constants.DefaultIngestionEndpoint,
                expectedLiveEndpoint: Constants.DefaultLiveEndpoint,
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestEndpointSuffix()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ingestion.azuremonitor.com",
                expectedIngestionEndpoint: "https://dc.ingestion.azuremonitor.com/",
                expectedLiveEndpoint: "https://live.ingestion.azuremonitor.com/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestEndpointSuffix_WithExplicitOverride()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ingestion.azuremonitor.com;IngestionEndpoint=https://custom.contoso.com:444/;LiveEndpoint=https://custom.contoso.com:555",
                expectedIngestionEndpoint: "https://custom.contoso.com:444/",
                expectedLiveEndpoint: "https://custom.contoso.com:555/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestEndpointSuffix_WithLocation()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ingestion.azuremonitor.com;Location=westus2",
                expectedIngestionEndpoint: "https://westus2.dc.ingestion.azuremonitor.com/",
                expectedLiveEndpoint: "https://westus2.live.ingestion.azuremonitor.com/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestEndpointSuffix_WithLocation_WithExplicitOverride()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ingestion.azuremonitor.com;Location=westus2;IngestionEndpoint=https://custom.contoso.com:444/;LiveEndpoint=https://custom.contoso.com:555",
                expectedIngestionEndpoint: "https://custom.contoso.com:444/",
                expectedLiveEndpoint: "https://custom.contoso.com:555/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestExplicitOverride_PreservesSchema()
        {
            // if "http" has been specified, we should not change it to "https".
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=http://custom.contoso.com:444/;LiveEndpoint=http://custom.contoso.com:555",
                expectedIngestionEndpoint: "http://custom.contoso.com:444/",
                expectedLiveEndpoint: "http://custom.contoso.com:555/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Fact]
        public void TestExplicitOverride_InvalidValue()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https:////custom.contoso.com"));
        }

        [Fact]
        public void TestExplicitOverride_InvalidValue2()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://www.~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_"));
        }

        [Fact]
        public void TestExplicitOverride_InvalidValue3()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_"));
        }

        [Fact]
        public void TestExplicitOverride_InvalidLocation()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ingestion.azuremonitor.com;Location=~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_"));
        }

        [Fact]
        public void TestMaliciousConnectionString()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: new string('*', Constants.ConnectionStringMaxLength + 1)));
        }

        [Fact]
        public void TestParseConnectionString_Empty()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: ""));
        }

        [Fact]
        public void TestEndpointProvider_NoInstrumentationKey()
        {
            Assert.Throws<InvalidOperationException>(() => RunTest(
                connectionString: "key1=value1;key2=value2;key3=value3"));
        }

        private void RunTest(string connectionString,
            string? expectedIngestionEndpoint = null,
            string? expectedLiveEndpoint = null,
            string? expectedInstrumentationKey = null,
            string? expectedAadAudience = null)
        {
            var connectionVars = ConnectionStringParser.GetValues(connectionString);

            Assert.Equal(expectedIngestionEndpoint, connectionVars.IngestionEndpoint);
            Assert.Equal(expectedLiveEndpoint, connectionVars.LiveEndpoint);
            Assert.Equal(expectedInstrumentationKey, connectionVars.InstrumentationKey);
            Assert.Equal(expectedAadAudience, connectionVars.AadAudience);
        }
    }
}
