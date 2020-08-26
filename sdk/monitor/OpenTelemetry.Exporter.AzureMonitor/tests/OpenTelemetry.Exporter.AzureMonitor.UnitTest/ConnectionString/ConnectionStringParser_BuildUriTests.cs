// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

using NUnit.Framework;

namespace OpenTelemetry.Exporter.AzureMonitor.ConnectionString
{
    public class ConnectionStringParser_BuildUriTests
    {
        /// <summary>
        /// Location and Endpoint are user input fields (via connection string).
        /// Need to ensure that if the user inputs extra periods, that we don't crash.
        /// </summary>
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
