// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests.samples
{
    public class AdvancedSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public void TrustServiceCertificate()
        {
            #region Snippet:GetIdentity

#if SNIPPET
            Uri identityServiceEndpoint = new("https://identity.confidential-ledger.core.azure.com"); // The hostname from the identityServiceUri
#else
            Uri identityServiceEndpoint = TestEnvironment.ConfidentialLedgerIdentityUrl;
#endif
            var identityClient = new ConfidentialLedgerCertificateClient(identityServiceEndpoint);

            // Get the ledger's  TLS certificate for our ledger.
#if SNIPPET
            string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
#else
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
#endif
            Response response = identityClient.GetLedgerIdentity(ledgerId);
            X509Certificate2 ledgerTlsCert = ConfidentialLedgerCertificateClient.ParseCertificate(response);

            X509Chain certificateChain = new();
            // Revocation is not required by CCF. Hence revocation checks must be skipped to avoid validation failing unnecessarily.
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            // Add the ledger identity TLS certificate to the ExtraStore.
            certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);
            // AllowUnknownCertificateAuthority will NOT allow validation of all unknown self-signed certificates.
            // It extends trust to the ExtraStore, which in this case contains the trusted ledger identity TLS certificate.
            // This makes it possible for validation of certificate chains terminating in the ledger identity TLS certificate to pass.
            // Note: .NET 5 introduced `CustomTrustStore` but we cannot use that here as we must support older versions of .NET.
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;

            // Define a validation function to ensure that certificates presented to the client only pass validation if
            // they are trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
            {
                // Validate the presented certificate chain, using the ChainPolicy defined above.
                // Note: this check will allow certificates signed by standard CAs as well as those signed by the ledger identity TLS certificate.
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                // Ensure that the presented certificate chain passes validation only if it is rooted in the the ledger identity TLS certificate.
                var rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
                var isChainRootedInTheTlsCert = rootCert.RawData.SequenceEqual(ledgerTlsCert.RawData);
                return isChainRootedInTheTlsCert;
            }

            // Create an HttpClientHandler to use our certValidationCheck function.
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = CertValidationCheck;

            // Create the ledger client using a transport that uses our custom ServerCertificateCustomValidationCallback.
            var options = new ConfidentialLedgerClientOptions { Transport = new HttpClientTransport(httpHandler) };
#if SNIPPET
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);
#else
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, TestEnvironment.Credential, options);
#endif

            #endregion
        }
    }
}
