// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        #region GetLedgerEntry polling

        private const string CertJson = @"{
            ""ledgerTlsCertificate"": ""-----BEGIN CERTIFICATE-----\nMIIBejCCASGgAwIBAgIRANPpW17pcDYr1KnqsJH5yC8wCgYIKoZIzj0EAwIwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjEwMzExMDAwMDAwWhcNMjMwNjExMjM1\nOTU5WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazBZMBMGByqGSM49AgEGCCqGSM49\nAwEHA0IABOCPGnfcmfm5Vyax3bvg5Xqg6RUZtda0U5qpmxqGgLfL3LYJd3heTPd\u002B\n51o29pMtKJGG4cWeZ3\u002BYbhZzHnetf8WjUDBOMAwGA1UdEwQFMAMBAf8wHQYDVR0O\nBBYEFFxq\u002BImyEVh4u4BfynwnEAsbvRJBMB8GA1UdIwQYMBaAFFxq\u002BImyEVh4u4Bf\nynwnEAsbvRJBMAoGCCqGSM49BAMCA0cAMEQCIC597R3C89/IzfqjkO31XKy4Rnfy\nXauWszBChtH1v2CoAiAS0tmFNjD3fweHH8O2ySXK/tPCBTq877pIjFGwvuj2uw==\n-----END CERTIFICATE-----\n\u0000"",
            ""ledgerId"": ""chrissconfidentialledger""}";

        private static MockTransport CreateCertTransport() =>
            new MockTransport(req =>
            {
                var cert = new MockResponse(200);
                cert.SetContent(CertJson);
                return cert;
            });

        private ConfidentialLedgerClient CreateClient(MockTransport ledgerTransport)
        {
            var client = InstrumentClient(new ConfidentialLedgerClient(
                new Uri("https://client.name"),
                new MockCredential(),
                ledgerOptions: new ConfidentialLedgerClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = ledgerTransport,
                },
                certificateClientOptions: new ConfidentialLedgerCertificateClientOptions
                {
                    Retry = { Delay = TimeSpan.Zero, MaxRetries = 0 },
                    Transport = CreateCertTransport(),
                }));
            // Avoid sleeping in unit tests.
            client.LoadingPollingInterval = TimeSpan.Zero;
            return client;
        }

        [Test]
        public async Task GetLedgerEntry_ReturnsImmediatelyWhenReady()
        {
            int callCount = 0;
            var transport = new MockTransport(req =>
            {
                callCount++;
                var resp = new MockResponse(200);
                resp.SetContent(@"{""state"":""Ready"",""entry"":{""contents"":""hello"",""transactionId"":""1.1""}}");
                return resp;
            });

            var client = CreateClient(transport);

            Response response = await client.GetLedgerEntryAsync("1.1");

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(1, callCount, "Should not retry when entry is ready on the first call.");
            Assert.That(response.Content.ToString(), Does.Contain("hello"));
        }

        [Test]
        public async Task GetLedgerEntry_PollsUntilEntryIsReady()
        {
            int callCount = 0;
            var transport = new MockTransport(req =>
            {
                callCount++;
                var resp = new MockResponse(200);
                if (callCount < 4)
                {
                    resp.SetContent(@"{""state"":""Loading""}");
                }
                else
                {
                    resp.SetContent(@"{""state"":""Ready"",""entry"":{""contents"":""ready-now"",""transactionId"":""2.5""}}");
                }
                return resp;
            });

            var client = CreateClient(transport);

            Response response = await client.GetLedgerEntryAsync("2.5");

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual(4, callCount);
            Assert.That(response.Content.ToString(), Does.Contain("ready-now"));
        }

        [Test]
        public async Task GetLedgerEntry_StopsAfterMaxLoadingRetries()
        {
            int callCount = 0;
            var transport = new MockTransport(req =>
            {
                callCount++;
                var resp = new MockResponse(200);
                resp.SetContent(@"{""state"":""Loading""}");
                return resp;
            });

            var client = CreateClient(transport);

            Response response = await client.GetLedgerEntryAsync("3.7");

            // Initial call + MaxLoadingRetries follow-up calls.
            Assert.AreEqual(ConfidentialLedgerClient.MaxLoadingRetries + 1, callCount);
            Assert.AreEqual(200, response.Status);
            Assert.That(response.Content.ToString(), Does.Contain("Loading"));
        }

        [Test]
        public async Task GetLedgerEntry_NonOkResponseIsReturnedWithoutPolling()
        {
            int callCount = 0;
            var transport = new MockTransport(req =>
            {
                callCount++;
                var resp = new MockResponse(404);
                resp.SetContent(@"{""error"":""not found""}");
                return resp;
            });

            var client = CreateClient(transport);
            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetLedgerEntryAsync("9.9"));

            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual(1, callCount, "Non-OK responses should not be retried by the loading-poll loop.");
        }

        [Test]
        public void GetLedgerEntry_RejectsNullTransactionId()
        {
            var client = CreateClient(new MockTransport(req => new MockResponse(200)));
            // Use the async overload - the test instrumentation routes to the sync path when IsAsync is false.
            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await client.GetLedgerEntryAsync(null));
        }

        #endregion
    }
}
