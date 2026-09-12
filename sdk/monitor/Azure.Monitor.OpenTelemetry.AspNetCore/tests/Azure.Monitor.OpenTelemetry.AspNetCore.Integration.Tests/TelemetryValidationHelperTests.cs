// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    public class TelemetryValidationHelperTests
    {
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