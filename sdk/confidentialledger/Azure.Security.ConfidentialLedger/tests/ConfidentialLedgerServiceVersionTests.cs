// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using Azure.Security.ConfidentialLedger.Models;
using NUnit.Framework;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;

namespace Azure.Security.ConfidentialLedger.Tests
{
    /// <summary>
    /// Unit tests covering the "2026-02-23" service version: that it is now the client default,
    /// that both selecting it explicitly and leaving the version unspecified result in exactly
    /// "api-version=2026-02-23" being sent on the wire for transaction writes and receipt reads,
    /// and that <see cref="TransactionReceipt.ApplicationClaims"/> (and the claim kinds it can
    /// contain) deserialize correctly.
    /// </summary>
    public class ConfidentialLedgerServiceVersionTests : ClientTestBase
    {
        public ConfidentialLedgerServiceVersionTests(bool isAsync) : base(isAsync) { }

        private const string LedgerTlsCert =
            @"-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000";

        private static MockTransport CreateCertTransport() => new MockTransport(req =>
        {
            var cert = new MockResponse(200);
            cert.SetContent($@"{{ ""ledgerTlsCertificate"": ""{LedgerTlsCert}"", ""ledgerId"": ""testledger"" }}");
            return cert;
        });

        private ConfidentialLedgerClient CreateClient(HttpPipelineTransport ledgerTransport, ConfidentialLedgerClientOptions options = null)
        {
            options ??= new ConfidentialLedgerClientOptions();
            options.Retry.Delay = TimeSpan.Zero;
            options.Retry.MaxRetries = 0;
            options.Transport = ledgerTransport;
            return InstrumentClient(new ConfidentialLedgerClient(
                new Uri("https://testledger.confidential-ledger.azure.com"),
                new MockCredential(),
                ledgerOptions: options,
                certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = CreateCertTransport(),
                }));
        }

        [Test]
        public async Task V2026_02_23_IsTheDefaultServiceVersion()
        {
            // The parameterless constructor must resolve to the new "2026-02-23" version.
            string capturedQuery = null;
            var transport = new MockTransport(req =>
            {
                capturedQuery = req.Uri.Query;
                var response = new MockResponse(200);
                response.AddHeader("x-ms-ccf-transaction-id", "1.1");
                response.SetContent(@"{ ""state"": ""Ready"", ""transactionId"": ""1.1"" }");
                return response;
            });

            var client = CreateClient(transport);
            await client.GetReceiptAsync("1.1", new RequestContext());

            Assert.AreEqual("?api-version=2026-02-23", capturedQuery);
        }

        [Test]
        public void ConfigurationDefault_ResolvesTo_V2026_02_23()
        {
            // ConfidentialLedgerClientOptions() and ConfidentialLedgerClientOptions(ServiceVersion.V2026_02_23)
            // must produce the identical wire api-version, since V2026_02_23 is now the default.
            var defaultOptions = new ConfidentialLedgerClientOptions();
            var explicitOptions = new ConfidentialLedgerClientOptions(ServiceVersion.V2026_02_23);

            Assert.AreEqual(explicitOptions.Version, defaultOptions.Version);
        }

        [TestCase(null)]
        [TestCase(ServiceVersion.V2026_02_23)]
        public async Task GetReceipt_SendsExactApiVersionQueryParameter(ServiceVersion? version)
        {
            string capturedQuery = null;
            var transport = new MockTransport(req =>
            {
                capturedQuery = req.Uri.Query;
                var response = new MockResponse(200);
                response.SetContent(@"{ ""state"": ""Ready"", ""transactionId"": ""1.2"" }");
                return response;
            });

            var options = version.HasValue ? new ConfidentialLedgerClientOptions(version.Value) : new ConfidentialLedgerClientOptions();
            var client = CreateClient(transport, options);

            await client.GetReceiptAsync("1.2", new RequestContext());

            Assert.AreEqual("?api-version=2026-02-23", capturedQuery);
        }

        [TestCase(null)]
        [TestCase(ServiceVersion.V2026_02_23)]
        public async Task PostLedgerEntry_SendsExactApiVersionQueryParameter(ServiceVersion? version)
        {
            string capturedQuery = null;
            var transport = new MockTransport(req =>
            {
                capturedQuery = req.Uri.Query;
                var response = new MockResponse(200);
                response.AddHeader("x-ms-ccf-transaction-id", "1.3");
                response.SetContent("Committed");
                return response;
            });

            var options = version.HasValue ? new ConfidentialLedgerClientOptions(version.Value) : new ConfidentialLedgerClientOptions();
            var client = CreateClient(transport, options);

            await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "test" }), null, default);

            Assert.AreEqual("?api-version=2026-02-23", capturedQuery);
        }

        [Test]
        public async Task TransactionReceipt_Deserializes_ClaimDigestApplicationClaim()
        {
            var transport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent(@"{
                    ""state"": ""Ready"",
                    ""transactionId"": ""2.1"",
                    ""applicationClaims"": [
                        {
                            ""kind"": ""ClaimDigest"",
                            ""digest"": {
                                ""value"": ""abc123def456"",
                                ""protocol"": ""LedgerEntryV1""
                            }
                        }
                    ]
                }");
                return response;
            });

            var client = CreateClient(transport);
            Response<TransactionReceipt> result = await client.GetReceiptAsync("2.1");

            Assert.AreEqual(1, result.Value.ApplicationClaims.Count);
            ApplicationClaim claim = result.Value.ApplicationClaims[0];
            Assert.AreEqual(ApplicationClaimKind.ClaimDigest, claim.Kind);
            Assert.IsNotNull(claim.Digest);
            Assert.AreEqual("abc123def456", claim.Digest.Value);
            Assert.AreEqual(ApplicationClaimProtocol.LedgerEntryV1, claim.Digest.Protocol);
            Assert.IsNull(claim.LedgerEntry);
        }

        [Test]
        public async Task TransactionReceipt_Deserializes_LedgerEntryApplicationClaim()
        {
            var transport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent(@"{
                    ""state"": ""Ready"",
                    ""transactionId"": ""2.2"",
                    ""applicationClaims"": [
                        {
                            ""kind"": ""LedgerEntry"",
                            ""ledgerEntry"": {
                                ""collectionId"": ""my-collection"",
                                ""contents"": ""hello world"",
                                ""secretKey"": ""c2VjcmV0"",
                                ""protocol"": ""LedgerEntryV1""
                            }
                        }
                    ]
                }");
                return response;
            });

            var client = CreateClient(transport);
            Response<TransactionReceipt> result = await client.GetReceiptAsync("2.2");

            Assert.AreEqual(1, result.Value.ApplicationClaims.Count);
            ApplicationClaim claim = result.Value.ApplicationClaims[0];
            Assert.AreEqual(ApplicationClaimKind.LedgerEntry, claim.Kind);
            Assert.IsNull(claim.Digest);
            Assert.IsNotNull(claim.LedgerEntry);
            Assert.AreEqual("my-collection", claim.LedgerEntry.CollectionId);
            Assert.AreEqual("hello world", claim.LedgerEntry.Contents);
            Assert.AreEqual("c2VjcmV0", claim.LedgerEntry.SecretKey);
            Assert.AreEqual(ApplicationClaimProtocol.LedgerEntryV1, claim.LedgerEntry.Protocol);
        }

        [Test]
        public async Task TransactionReceipt_ApplicationClaims_AbsentFromPayload_IsEmpty()
        {
            var transport = new MockTransport(req =>
            {
                var response = new MockResponse(200);
                response.SetContent(@"{ ""state"": ""Ready"", ""transactionId"": ""2.3"" }");
                return response;
            });

            var client = CreateClient(transport);
            Response<TransactionReceipt> result = await client.GetReceiptAsync("2.3");

            Assert.IsNotNull(result.Value.ApplicationClaims);
            Assert.AreEqual(0, result.Value.ApplicationClaims.Count);
        }
    }
}
