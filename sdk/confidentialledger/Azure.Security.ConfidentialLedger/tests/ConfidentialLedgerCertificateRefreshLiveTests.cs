// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Net;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Live tests for refreshing a pinned ledger identity TLS certificate from the Identity Service.
    /// </summary>
    /// <remarks>
    /// These tests deliberately bypass the test proxy: the proxy terminates TLS itself, so the SDK's
    /// server-certificate validation callback would never observe the ledger's real certificate. The client
    /// is pinned to a freshly generated self-signed certificate, which simulates a stale pin left behind
    /// after the ledger's service identity changes (for example after disaster recovery).
    /// </remarks>
    public class ConfidentialLedgerCertificateRefreshLiveTests : LiveTestBase<ConfidentialLedgerEnvironment>
    {
        [Test]
        public async Task StalePinnedCertificateIsRefreshedFromIdentityService()
        {
            using X509Certificate2 stalePin = CreateSelfSignedCertificate();
            var identityRequests = new IdentityRequestCounter();
            var certificateClientOptions = new ConfidentialLedgerCertificateClientOptions();
            certificateClientOptions.AddPolicy(identityRequests, HttpPipelinePosition.PerCall);

            var client = new ConfidentialLedgerClient(
                TestEnvironment.ConfidentialLedgerUrl,
                credential: TestEnvironment.Credential,
                certificateClientOptions: certificateClientOptions,
                ledgerOptions: new ConfidentialLedgerClientOptions
                {
                    CertificateEndpoint = TestEnvironment.ConfidentialLedgerIdentityUrl,
                },
                identityServiceCert: stalePin);

            Assert.AreEqual(0, identityRequests.Count, "Supplying the pinned certificate must skip the construction-time lookup.");

            // The ledger presents its real certificate, which does not chain to the stale pin. The trust store
            // must refresh from the Identity Service and accept the handshake instead of failing TLS.
            Response response = await client.GetConstitutionAsync(new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.AreEqual(1, identityRequests.Count, "The stale pin must trigger exactly one Identity Service refresh.");

            // The refreshed certificate is now pinned, so later requests do not query the Identity Service again.
            response = await client.GetConstitutionAsync(new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.AreEqual(1, identityRequests.Count, "A refreshed pin must be reused without another lookup.");
        }

        [Test]
        public void StalePinnedCertificateFailsTlsWithoutRefresh()
        {
            using X509Certificate2 stalePin = CreateSelfSignedCertificate();
            Uri ledgerEndpoint = TestEnvironment.ConfidentialLedgerUrl;
            string ledgerId = ledgerEndpoint.Host.Substring(0, ledgerEndpoint.Host.IndexOf('.'));
            var trustStore = new ConfidentialLedgerCertificateTrustStore(verifyConnection: true);
            trustStore.Trust(ledgerId, stalePin, ledgerEndpoint);

            var options = new ConfidentialLedgerClientOptions
            {
                Retry = { MaxRetries = 0 },
            };
            HttpPipeline pipeline = HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                Array.Empty<HttpPipelinePolicy>(),
                new HttpPipelineTransportOptions
                {
                    ServerCertificateCustomValidationCallback = args => trustStore.Validate(ledgerId, args.Certificate),
                },
                new ResponseClassifier());
            using HttpMessage message = pipeline.CreateMessage();
            message.Request.Method = RequestMethod.Get;
            message.Request.Uri.Reset(new Uri(ledgerEndpoint, "/app/governance/constitution"));

            // Control case: without an Identity Service refresher, the same stale pin rejects the ledger's
            // real certificate during the TLS handshake.
            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await pipeline.SendAsync(message, CancellationToken.None));

            Assert.IsTrue(HasInnerException<AuthenticationException>(exception),
                $"Expected a TLS authentication failure, but got: {exception}");
        }

        private static X509Certificate2 CreateSelfSignedCertificate()
        {
            using ECDsa key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            var request = new CertificateRequest("CN=Stale Ledger Identity", key, HashAlgorithmName.SHA256);
            return request.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(1));
        }

        private static bool HasInnerException<T>(Exception exception) where T : Exception
        {
            for (Exception current = exception; current != null; current = current.InnerException)
            {
                if (current is T)
                {
                    return true;
                }
            }
            return false;
        }

        private sealed class IdentityRequestCounter : HttpPipelineSynchronousPolicy
        {
            private int _count;

            public int Count => Volatile.Read(ref _count);

            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Uri.Path.StartsWith("/ledgerIdentity/", StringComparison.OrdinalIgnoreCase))
                {
                    Interlocked.Increment(ref _count);
                }
            }
        }
    }
}
#endif
