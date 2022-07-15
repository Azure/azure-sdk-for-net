// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
            Uri identityServiceEndpoint = new("https://identity.confidential-ledger.core.azure.com") // The hostname from the identityServiceUri
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

            #endregion

            #region Snippet:CreateClient

            // Create a certificate chain rooted with our TLS cert.
            X509Chain certificateChain = new();
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
            certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);
            certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);

            var f = certificateChain.Build(ledgerTlsCert);

            // Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
            bool CertValidationCheck(HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
            {
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                var isCertSignedByTheTlsCert = certificateChain.ChainElements.Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == ledgerTlsCert.Thumbprint);
                return isCertSignedByTheTlsCert || httpRequestMessage.RequestUri.Host == "identity.confidential-ledger.core.azure.com";
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
