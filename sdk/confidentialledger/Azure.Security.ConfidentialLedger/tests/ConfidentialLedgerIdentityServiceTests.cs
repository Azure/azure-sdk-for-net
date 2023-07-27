// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerIdentityServiceTests
    {
        [Test]
        public void ParseCertificate()
        {
            var ledgerCert =
                new LedgerIdentityResponse
                {
                    ledgerTlsCertificate =
                        "-----BEGIN CERTIFICATE-----\nMIIBezCCASGgAwIBAgIRAJm8lmSE26KV0eDDXrRD6LQwCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABJDsxegT33aucCNaiHPK2YNPqwRg1Y2xxVVkII9yUCs6QyNJoCWI4Zfv\nj7iCOpaaBFxDBOuXcqyzXix\u002Be0r3rZyjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFLmINpd7X6PFiqD3z0FsjUgDyHtDMB8GA1UdIwQYMBaAFLmINpd7X6PFiqD3\nz0FsjUgDyHtDMAoGCCqGSM49BAMCA0gAMEUCIQD13yI1tEd9m0CtyfSqUnN80wYr\n6QRh9JO3tuSMA10b2gIgGZTs\u002BkowdDjP//U5fgCBovlcGIhdiBBF2wuHnLfqAkI=\n-----END CERTIFICATE-----\n\u0000"
                };

            var response = new MockResponse(200);
            response.SetContent(System.Text.Json.JsonSerializer.Serialize(ledgerCert));

            var cert = ConfidentialLedgerCertificateClient.ParseCertificate(response);

            Assert.AreEqual("5D2E98B216B73220C960EE2978E56EEFEEACA30D", cert.Thumbprint);
        }

        public class LedgerIdentityResponse
        {
            public string ledgerTlsCertificate { get; set; }
            public string ledgerId { get; set; }
        }
    }
}
