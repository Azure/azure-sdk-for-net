// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientTests : ClientTestBase
    {
        public ConfidentialLedgerClientTests(bool isAsync) : base(isAsync) { }
        private const string transactionId = "1234";

        [Test]
        public async Task FailedTransaction()
        {
            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                if (req.Uri.Path.Contains($"transactions/{transactionId}/status"))
                                {
                                    var success = new MockResponse(500);
                                    success.SetContent("success");
                                    return success;
                                }
                                var failed = new MockResponse(200);
                                failed.AddHeader("x-ms-ccf-transaction-id", transactionId);
                                failed.SetContent("failed");
                                return failed;
                            }),
                    },
                    certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                var cert = new MockResponse(200);
                                cert.SetContent(
                                    @" {
                                    ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                                    ""ledgerId"": ""chrissconfidentialledger""}");
                                return cert;
                            })
                    }
                    ));
            var operation = await client.PostLedgerEntryAsync(WaitUntil.Started, RequestContent.Create(new { contents = "test" }), null, default);
            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await operation.WaitForCompletionResponseAsync());
            Assert.That(ex.Message, Does.Contain(transactionId));
        }

        [Test]
        public void VerifyConnectionDefaultsToTrue()
        {
            var options = new ConfidentialLedgerClientOptions();
            Assert.IsTrue(options.VerifyConnection, "VerifyConnection should default to true to ensure TLS verification is enabled by default.");
        }

        [Test]
        public void CustomCertUri()
        {
            Uri customUri = new Uri("http://my-custom-uri.com");

            var client = InstrumentClient(
                new ConfidentialLedgerClient(
                    new("https://client.name"),
                    new MockCredential(),
                    ledgerOptions: new ConfidentialLedgerClientOptions
                    {
                        CertificateEndpoint = customUri,
                    },
                    certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                    {
                        Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                        Transport = new MockTransport(
                            req =>
                            {
                                Assert.AreEqual(customUri.Host, req.Uri.Host);
                                var cert = new MockResponse(200);
                                cert.SetContent(
                                    @" {
                                    ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                                    ""ledgerId"": ""chrissconfidentialledger""}");
                                return cert;
                            })
                    }
                ));
        }

        // Cert payload reused by GetLedgerEntry tests for the certificate
        // bootstrap call the client makes during construction.
        private const string LedgerIdentityCert =
            @" {
                ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
                ""ledgerId"": ""chrissconfidentialledger""}";

        private static ConfidentialLedgerCertificateClientOptions CreateCertOptions() =>
            new ConfidentialLedgerCertificateClientOptions
            {
                Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                Transport = new MockTransport(req =>
                {
                    var cert = new MockResponse(200);
                    cert.SetContent(LedgerIdentityCert);
                    return cert;
                })
            };

        private static MockResponse LoadingResponse()
        {
            var r = new MockResponse(200);
            r.SetContent(@"{""state"":""Loading"",""transactionId"":""1.2""}");
            return r;
        }

        private static MockResponse LoadedResponse()
        {
            var r = new MockResponse(200);
            r.SetContent(@"{""state"":""Ready"",""transactionId"":""1.2"",""entry"":{""contents"":""hello"",""collectionId"":""subledger:0"",""transactionId"":""1.2""}}");
            return r;
        }

        private ConfidentialLedgerClient CreateClientWithLedgerEntryResponses(params Func<MockResponse>[] ledgerEntryResponses)
        {
            int callIndex = 0;
            return InstrumentClient(new ConfidentialLedgerClient(
                new Uri("https://client.name"),
                new MockCredential(),
                ledgerOptions: new ConfidentialLedgerClientOptions
                {
                    // Drives both pipeline retries AND the SDK's loading-poll delay (zero so tests are fast).
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = new MockTransport(req =>
                    {
                        if (req.Uri.Path.Contains("/app/transactions/"))
                        {
                            int i = Math.Min(callIndex, ledgerEntryResponses.Length - 1);
                            callIndex++;
                            return ledgerEntryResponses[i]();
                        }
                        return new MockResponse(200);
                    }),
                },
                certificateClientOptions: CreateCertOptions()));
        }

        [Test]
        public async Task GetLedgerEntry_ReturnsImmediatelyWhenLoaded()
        {
            var client = CreateClientWithLedgerEntryResponses(LoadedResponse);

            Response response = await client.GetLedgerEntryAsync(transactionId);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            Assert.AreEqual("Ready", doc.RootElement.GetProperty("state").GetString());
            Assert.AreEqual("hello", doc.RootElement.GetProperty("entry").GetProperty("contents").GetString());
        }

        [Test]
        public async Task GetLedgerEntry_PollsThroughLoadingResponses()
        {
            // Three loading responses, then a loaded response.
            var client = CreateClientWithLedgerEntryResponses(
                LoadingResponse, LoadingResponse, LoadingResponse, LoadedResponse);

            Response response = await client.GetLedgerEntryAsync(transactionId);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            Assert.AreEqual("Ready", doc.RootElement.GetProperty("state").GetString());
            Assert.IsTrue(doc.RootElement.TryGetProperty("entry", out _));
        }

        [Test]
        public async Task GetLedgerEntry_StopsAfterMaxLoadingRetries()
        {
            // Always returns "Loading" — should poll up to the bound and then
            // return the last loading response (no infinite loop).
            var client = CreateClientWithLedgerEntryResponses(LoadingResponse);

            Response response = await client.GetLedgerEntryAsync(transactionId);

            using JsonDocument doc = JsonDocument.Parse(response.Content);
            Assert.AreEqual("Loading", doc.RootElement.GetProperty("state").GetString());
        }
    }
}
