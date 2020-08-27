// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    /// <summary>
    /// The <see cref="ConnectionStringParser.TryBuildUri(string, string, out Uri, string)"/> method takes user input to construct an endpoint.
    /// These tests verify that user input is correctly sanitized and that valid endpoints are constructed.
    /// </summary>
    public class ConnectionStringParser_BuildUriTests
    {
        [Test]
        public void VerifyCanHandleExtraPeriods()
        {
            var result = ConnectionStringParser.TryBuildUri(
                location: "westus2.",
                prefix: "dc",
                suffix: ".applicationinsights.azure.com",
                uri: out Uri uri);

            Assert.IsTrue(result);
            Assert.AreEqual("https://westus2.dc.applicationinsights.azure.com/", uri.AbsoluteUri);
        }

        [Test]
        public void VerifyGoodAddress_WithLocation()
        {
            var result = ConnectionStringParser.TryBuildUri(
                location: "westus2",
                prefix: "dc",
                suffix: "applicationinsights.azure.com",
                uri: out Uri uri);

            Assert.IsTrue(result);
            Assert.AreEqual("https://westus2.dc.applicationinsights.azure.com/", uri.AbsoluteUri);
        }

        [Test]
        public void VerifyGoodAddress_WithoutLocation()
        {
            var result = ConnectionStringParser.TryBuildUri(
                location: null,
                prefix: "dc",
                suffix: "applicationinsights.azure.com",
                uri: out Uri uri);

            Assert.IsTrue(result);
            Assert.AreEqual("https://dc.applicationinsights.azure.com/", uri.AbsoluteUri);
        }

        [Test]
        public void VerifyGoodAddress_InvalidCharInLocation()
        {
            Assert.Throws<ArgumentException>(() =>
                ConnectionStringParser.TryBuildUri(
                    location: "westus2/",
                    prefix: "dc",
                    suffix: "applicationinsights.azure.com",
                    uri: out Uri uri));
        }

        [Test]
        public void VerifyGoodAddress_CanHandleExtraSpaces()
        {
            var result = ConnectionStringParser.TryBuildUri(
                location: " westus2 ",
                prefix: "dc",
                suffix: "   applicationinsights.azure.com   ",
                uri: out Uri uri);

            Assert.IsTrue(result);
            Assert.AreEqual("https://westus2.dc.applicationinsights.azure.com/", uri.AbsoluteUri);
        }
    }
}
