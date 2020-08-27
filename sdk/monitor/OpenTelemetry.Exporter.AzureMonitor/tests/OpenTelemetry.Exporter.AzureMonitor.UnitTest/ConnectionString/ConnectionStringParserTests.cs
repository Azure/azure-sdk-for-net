// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    public class ConnectionStringParserTests
    {
        [Test]
        public void TestInstrumentationKey_IsRequired()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "EndpointSuffix=ai.contoso.com",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestInstrumentationKey_CannotBeEmpty()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "InstrumentationKey=;EndpointSuffix=ai.contoso.com",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestDefaultEndpoints()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000",
                expectedIngestionEndpoint: Constants.DefaultIngestionEndpoint,
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestEndpointSuffix()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ai.contoso.com",
                expectedIngestionEndpoint: "https://dc.ai.contoso.com/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestEndpointSuffix_WithExplicitOverride()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ai.contoso.com;IngestionEndpoint=https://custom.profiler.contoso.com:444/",
                expectedIngestionEndpoint: "https://custom.profiler.contoso.com:444/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestEndpointSuffix_WithLocation()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ai.contoso.com;Location=westus2",
                expectedIngestionEndpoint: "https://westus2.dc.ai.contoso.com/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestEndpointSuffix_WithLocation_WithExplicitOverride()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=ai.contoso.com;Location=westus2;IngestionEndpoint=https://custom.profiler.contoso.com:444/",
                expectedIngestionEndpoint: "https://custom.profiler.contoso.com:444/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestExpliticOverride_PreservesSchema()
        {
            RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=http://custom.profiler.contoso.com:444/",
                expectedIngestionEndpoint: "http://custom.profiler.contoso.com:444/",
                expectedInstrumentationKey: "00000000-0000-0000-0000-000000000000");
        }

        [Test]
        public void TestExpliticOverride_InvalidValue()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https:////custom.profiler.contoso.com",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestExpliticOverride_InvalidValue2()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://www.~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestExpliticOverride_InvalidValue3()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestExpliticOverride_InvalidLocation()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "InstrumentationKey=00000000-0000-0000-0000-000000000000;EndpointSuffix=contoso.com;Location=~!@#$%&^*()_{}{}><?<?>:L\":\"_+_+_",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestMaliciousConnectionString()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: new string('*', Constants.ConnectionStringMaxLength + 1),
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestParseConnectionString_Null()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: null,
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestParseConnectionString_Empty()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        [Test]
        public void TestEndpointProvider_NoInstrumentationKey()
        {
            Assert.Throws<Exception>(() => RunTest(
                connectionString: "key1=value1;key2=value2;key3=value3",
                expectedIngestionEndpoint: null,
                expectedInstrumentationKey: null));
        }

        private void RunTest(string connectionString, string expectedIngestionEndpoint, string expectedInstrumentationKey)
        {
            ConnectionStringParser.GetValues(connectionString, out string ikey, out string endpoint);

            Assert.AreEqual(expectedIngestionEndpoint, endpoint);
            Assert.AreEqual(expectedInstrumentationKey, ikey);
        }
    }
}
