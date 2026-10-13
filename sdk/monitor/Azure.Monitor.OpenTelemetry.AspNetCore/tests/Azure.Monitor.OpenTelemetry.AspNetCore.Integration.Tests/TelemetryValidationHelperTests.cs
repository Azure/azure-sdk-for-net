// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class TelemetryValidationHelperTests
    {
        [Test]
        public void ParsesCamelCaseMultiEndpointResources()
        {
            var resources = MultiEndpointResource.Parse("""
                [
                  { "connectionString": "InstrumentationKey=11111111-1111-1111-1111-111111111111;IngestionEndpoint=https://shared.example/", "workspaceId": "workspace-a", "resourceId": "resource-a" },
                  { "connectionString": "InstrumentationKey=22222222-2222-2222-2222-222222222222;IngestionEndpoint=https://shared.example/", "workspaceId": "workspace-b", "resourceId": "resource-b" },
                  { "connectionString": "InstrumentationKey=33333333-3333-3333-3333-333333333333;IngestionEndpoint=https://secondary.example/", "workspaceId": "workspace-c", "resourceId": "resource-c" }
                ]
                """);

            Assert.That(resources[0].InstrumentationKey, Is.EqualTo("11111111-1111-1111-1111-111111111111"));
            Assert.That(resources[0].Endpoint, Is.EqualTo(new System.Uri("https://shared.example/")));
        }

        [TestCase("{\"CustomProperty1\":\"Value1\",\"_MS.ResourceAttributeId\":\"generated-id\"}")]
        [TestCase("{\"CustomProperty1\":\"Value1\"}")]
        public void AcceptsOptionalResourceAttributeId(string properties)
        {
            Assert.DoesNotThrow(() => TelemetryValidationHelper.ValidateProperties(
            "Telemetry", properties, new List<KeyValuePair<string, string>> { new("CustomProperty1", "Value1"), new("_MS.ResourceAttributeId", "*") }));
        }

        [TestCase("{\"CustomProperty1\":\"Value1\",\"_MS.ResourceAttributeId\":null}")]
        [TestCase("{\"CustomProperty1\":\"Value1\",\"_MS.ResourceAttributeId\":\"\"}")]
        [TestCase("{\"CustomProperty1\":\"Value1\",\"_MS.ResourceAttributeId\":\" \"}")]
        [TestCase("{}")]
        [TestCase("{\"CustomProperty1\":\"wrong\"}")]
        [TestCase("{\"CustomProperty1\":\"Value1\",\"Unexpected\":\"value\"}")]
        [TestCase("{\"_MS.ResourceAttributeId\":\"generated-id\"}")]
        [TestCase("{\"CustomProperty1\":\"wrong\",\"_MS.ResourceAttributeId\":\"generated-id\"}")]
        [TestCase("{\"CustomProperty1\":\"Value1\",\"Unexpected\":\"value\",\"_MS.ResourceAttributeId\":\"generated-id\"}")]
        public void RejectsPropertyMismatches(string properties)
        {
            Assert.Throws<AssertionException>(() => TelemetryValidationHelper.ValidateProperties(
                "Telemetry", properties, new List<KeyValuePair<string, string>> { new("CustomProperty1", "Value1"), new("_MS.ResourceAttributeId", "*") }));
        }

        [TestCase("{\"_MS.ResourceAttributeId\":\"wrong\"}")]
        [TestCase("{}")]
        public void ValidatesExplicitlyExpectedResourceAttributeId(string properties)
        {
            Assert.Throws<AssertionException>(() => TelemetryValidationHelper.ValidateProperties(
                "Telemetry", properties,
                new List<KeyValuePair<string, string>> { new("_MS.ResourceAttributeId", "expected-id") }));
        }
    }
}
#endif