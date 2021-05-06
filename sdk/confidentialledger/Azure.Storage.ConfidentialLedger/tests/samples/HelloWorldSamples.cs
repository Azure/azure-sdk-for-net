// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.ConfidentialLedger.Tests.samples
{
    public class HelloWorldSamples : SamplesBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public void CreateClient()
        {
            #region Snippet:CreateIdentityServiceClient

#if SNIPPET
            Uri identityServiceUri = "<the identity service uri>";
#else
            Uri identityServiceUri = TestEnvironment.ConfidentialLedgerIdentityUrl;
#endif
            var identityClient = new ConfidentialLedgerIdentityServiceClient(identityServiceUri, new Identity.DefaultAzureCredential());

            #endregion

            #region Snippet:GetIdentity

            // Get the ledger's  TLS certificate for our ledger.
#if SNIPPET
            string ledgerId = "<the ledger id>"; // ex. "my-ledger" from "https://my-ledger.eastus.cloudapp.azure.com"
#else
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
#endif
            Response response = identityClient.GetLedgerIdentity(ledgerId);

            // extract the ECC PEM value from the response.
            var eccPem = JsonDocument.Parse(response.Content)
                .RootElement
                .GetProperty("ledgerTlsCertificate")
                .GetString();

            // construct an X509Certificate2 with the ECC PEM value.
            X509Certificate2 ledgerTlsCert = new X509Certificate2(Encoding.UTF8.GetBytes(eccPem));

            #endregion

            #region Snippet:CreateClient

            // Define a validation function to ensure that the ledger certificate is trusted by the ledger identity TLS certificate.
            Func<HttpRequestMessage, X509Certificate2, X509Chain, SslPolicyErrors, bool> certValidationCheck;
            certValidationCheck = (_, cert, _, _) =>
            {
                X509Chain certificateChain = new();
                certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                certificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
                certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                certificateChain.ChainPolicy.VerificationTime = DateTime.Now;
                certificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 0, 0);

                certificateChain.ChainPolicy.ExtraStore.Add(ledgerTlsCert);
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid) return false;

                var isCertSignedByTheTlsCert = certificateChain.ChainElements
                    .Cast<X509ChainElement>()
                    .Any(x => x.Certificate.Thumbprint == ledgerTlsCert.Thumbprint);
                return isCertSignedByTheTlsCert;
            };

            // Create an HttpClientHandler to use our certValidationCheck function.
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = certValidationCheck;

            // Create the ledger client using a transport that uses our custom ServerCertificateCustomValidationCallback.
            var options = new ConfidentialLedgerClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var ledgerClient = new ConfidentialLedgerClient(TestEnvironment.ConfidentialLedgerUrl, new DefaultAzureCredential(), options);

            #endregion
        }
    }
}
