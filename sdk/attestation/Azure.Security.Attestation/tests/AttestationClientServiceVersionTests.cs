// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.Attestation.Tests
{
    /// <summary>
    /// Guards that each <see cref="AttestationClientOptions.ServiceVersion"/> is sent as its api-version query parameter.
    /// </summary>
    public class AttestationClientServiceVersionTests
    {
        [TestCase(AttestationClientOptions.ServiceVersion.V2020_10_01, "2020-10-01")]
        [TestCase(AttestationClientOptions.ServiceVersion.V2025_06_01, "2025-06-01")]
        public void SendsSelectedApiVersion(AttestationClientOptions.ServiceVersion version, string expectedApiVersion)
        {
            MockTransport transport = CreateTransport();
            var options = new AttestationClientOptions(version) { Transport = transport };

            new AttestationClient(new Uri("https://contoso.attest.azure.net"), new MockCredential(), options).GetSigningCertificates();

            StringAssert.Contains($"api-version={expectedApiVersion}", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public void DefaultsToLatestApiVersion()
        {
            MockTransport transport = CreateTransport();
            var options = new AttestationClientOptions() { Transport = transport };

            new AttestationClient(new Uri("https://contoso.attest.azure.net"), new MockCredential(), options).GetSigningCertificates();

            StringAssert.Contains("api-version=2025-06-01", transport.SingleRequest.Uri.ToString());
        }

        private static MockTransport CreateTransport() => new MockTransport(new MockResponse(200).SetContent("{\"keys\":[]}"));
    }
}
