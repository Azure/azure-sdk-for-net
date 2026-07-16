// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    // Phase 2 routes CertificateClient through the generated KeyVaultCertificatesClient
    // by building the HttpPipeline directly from the customer's CertificateClientOptions
    // (the same construction path the legacy hand-written client used). These tests
    // pin that contract end-to-end - so a future refactor cannot silently drop
    // AddPolicy entries, retry config, or Diagnostics allow-lists from the pipeline.
    public class CertificateClientOptionsTests
    {
        private static readonly Uri TestVault = new Uri("https://example.vault.azure.net");

        // ----- ServiceVersion -----

        [Test]
        public void UnsupportedServiceVersionThrows()
        {
            // The ctor stores the unrecognized value (the enum is just an int);
            // the ArgumentException must be raised when CertificateClient asks
            // GetVersionString() to turn it into a wire string.
            var bogus = (CertificateClientOptions.ServiceVersion)9999;
            var options = new CertificateClientOptions(bogus);

            ArgumentException ex = Assert.Catch<ArgumentException>(
                () => new CertificateClient(TestVault, new MockCredential(), options));
            // Either CertificateClient.MapApiVersion (ArgumentOutOfRangeException) or
            // CertificateClientOptions.GetVersionString (ArgumentException) may surface
            // first depending on construction order; both derive from ArgumentException
            // and both must mention the unsupported version value.
            StringAssert.Contains("9999", ex.Message,
                "Exception message should mention the unsupported version value.");
        }

        [Test]
        public void EveryDefinedServiceVersionConstructs()
        {
            foreach (CertificateClientOptions.ServiceVersion v in Enum.GetValues(typeof(CertificateClientOptions.ServiceVersion)))
            {
                CertificateClient client = null;
                Assert.DoesNotThrow(
                    () => client = new CertificateClient(TestVault, new MockCredential(), new CertificateClientOptions(v)),
                    $"CertificateClientOptions.ServiceVersion.{v} must construct successfully (no breaking change for existing customers).");

                Assert.NotNull(client);
                Assert.AreEqual(TestVault, client.VaultUri);
            }
        }

        // Phase 2 keeps the MapApiVersion mapping as identity (each enum value
        // produces its matching wire string) - we are NOT replicating the
        // Secrets PR's V7_0..V7_4 -> "7.5" remap, which is incorrect for this
        // package. Pin the per-enum wire string so any future refactor that
        // tries to introduce a remap fails loudly.
        [TestCase(CertificateClientOptions.ServiceVersion.V7_0,                "7.0")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_1,                "7.1")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_2,                "7.2")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_3,                "7.3")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_4,                "7.4")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_5,                "7.5")]
        [TestCase(CertificateClientOptions.ServiceVersion.V7_6,                "7.6")]
        [TestCase(CertificateClientOptions.ServiceVersion.V2025_07_01,         "2025-07-01")]
        [TestCase(CertificateClientOptions.ServiceVersion.V2026_03_01_Preview, "2026-03-01-preview")]
        public void GetVersionString_MatchesWireString(CertificateClientOptions.ServiceVersion version, string expected)
        {
            var options = new CertificateClientOptions(version);
            Assert.AreEqual(expected, options.GetVersionString());
        }

        [Test]
        public async Task ServiceVersion_PropagatesToWireApiVersionQuery()
        {
            var transport = new MockTransport(MockGetCertificateOk());
            var options = new CertificateClientOptions(CertificateClientOptions.ServiceVersion.V7_6) { Transport = transport };

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");

            string actual = GetApiVersionQuery(transport.Requests[0]);
            Assert.AreEqual("7.6", actual, "Version configured on options must reach the wire as api-version.");
        }

        // ----- Options propagation -----

        [Test]
        public async Task AddPolicyPerCallIsHonored()
        {
            int hits = 0;
            var probe = new ProbePolicy(() => hits++);

            var transport = new MockTransport(MockGetCertificateOk());
            var options = new CertificateClientOptions { Transport = transport };
            options.AddPolicy(probe, HttpPipelinePosition.PerCall);

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");

            Assert.AreEqual(1, hits, "Per-call AddPolicy must execute exactly once for a single GetCertificate call.");
        }

        [Test]
        public async Task AddPolicyPerRetryIsHonored()
        {
            int hits = 0;
            var probe = new ProbePolicy(() => hits++);

            // 503 once, then 200 - PerRetry fires per-attempt (2 attempts).
            var transport = new MockTransport(
                new MockResponse(503),
                MockGetCertificateOk());

            var options = new CertificateClientOptions
            {
                Transport = transport,
                Retry = { MaxRetries = 3, Mode = RetryMode.Fixed, Delay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero },
            };
            options.AddPolicy(probe, HttpPipelinePosition.PerRetry);

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");

            Assert.AreEqual(2, transport.Requests.Count, "Transient 503 must trigger one retry.");
            Assert.AreEqual(2, hits, "Per-retry AddPolicy must fire once per attempt.");
        }

        [Test]
        public void CustomRetryMaxRetriesZeroIsHonored()
        {
            // MaxRetries=0 means a single attempt - 503 must surface immediately
            // as RequestFailedException with no retry.
            var transport = new MockTransport(new MockResponse(503));
            var options = new CertificateClientOptions
            {
                Transport = transport,
                Retry = { MaxRetries = 0 },
            };

            var client = new CertificateClient(TestVault, new MockCredential(), options);

            Assert.ThrowsAsync<RequestFailedException>(() => client.GetCertificateAsync("x"));
            Assert.AreEqual(1, transport.Requests.Count,
                "Retry.MaxRetries=0 must yield exactly one attempt; the new pipeline must respect customer config.");
        }

        [Test]
        public async Task CustomRetryMaxRetriesPositiveIsHonored()
        {
            // MaxRetries=5, transport returns 3x500 then 200 - we expect 4 attempts.
            var transport = new MockTransport(
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                MockGetCertificateOk());
            var options = new CertificateClientOptions
            {
                Transport = transport,
                Retry = { MaxRetries = 5, Mode = RetryMode.Fixed, Delay = TimeSpan.Zero, MaxDelay = TimeSpan.Zero },
            };

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");

            Assert.AreEqual(4, transport.Requests.Count,
                "Customer's Retry.MaxRetries (>0) must be honored by the new pipeline.");
        }

        [Test]
        public async Task CustomTransportIsHonored()
        {
            var transport = new MockTransport(MockGetCertificateOk());
            var options = new CertificateClientOptions { Transport = transport };

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");

            Assert.AreEqual(1, transport.Requests.Count, "Customer-provided Transport must receive requests.");
            StringAssert.Contains("/certificates/x", transport.Requests[0].Uri.Path);
        }

        [Test]
        public async Task DiagnosticsLoggedHeaderNames_AreNotScrubbedInLogs()
        {
            // Stronger guarantee than "the header reaches the transport": prove
            // an allow-listed header is NOT redacted in the Azure-Core event
            // source's request log. Any header that's not on the allow-list is
            // replaced with REDACTED, so finding the unredacted value end-to-end
            // demonstrates the customer's Diagnostics.LoggedHeaderNames flowed
            // through to the logging policy.
            var log = new System.Text.StringBuilder();
            using var listener = new Azure.Core.Diagnostics.AzureEventSourceListener(
                (e, msg) =>
                {
                    if (e.EventSource.Name == "Azure-Core") { log.AppendLine(msg); }
                },
                System.Diagnostics.Tracing.EventLevel.Verbose);

            var transport = new MockTransport(MockGetCertificateOk());
            var options = new CertificateClientOptions
            {
                Transport = transport,
                Diagnostics =
                {
                    IsLoggingEnabled  = true,
                    LoggedHeaderNames = { "x-custom-diag" },
                    ApplicationId     = "kv-cert-test",
                },
            };
            // Stamp the allow-listed header onto the outgoing request so the
            // logger has something to log under that name.
            options.AddPolicy(new StampHeaderPolicy("x-custom-diag", "diag-marker-1234"), HttpPipelinePosition.PerCall);

            var client = new CertificateClient(TestVault, new MockCredential(), options);
            await client.GetCertificateAsync("x");
            await Task.Delay(50);

            string text = log.ToString();
            Assert.That(text, Does.Contain("kv-cert-test"),
                "ApplicationId must reach the logging layer via User-Agent.");
            Assert.That(text, Does.Contain("diag-marker-1234"),
                "LoggedHeaderNames allow-listed value must appear unsanitized in logs.");
        }

        // ----- helpers -----

        private static MockResponse MockGetCertificateOk()
        {
            var r = new MockResponse(200);
            r.AddHeader(HttpHeader.Common.JsonContentType);
            r.SetContent(@"{""id"":""https://example.vault.azure.net/certificates/x/abc""}");
            return r;
        }

        private static string GetApiVersionQuery(Request request)
        {
            string query = request.Uri.Query ?? string.Empty;
            foreach (string kv in query.TrimStart('?').Split('&'))
            {
                int eq = kv.IndexOf('=');
                if (eq < 0) { continue; }
                if (string.Equals(kv.Substring(0, eq), "api-version", StringComparison.OrdinalIgnoreCase))
                {
                    return Uri.UnescapeDataString(kv.Substring(eq + 1));
                }
            }
            return null;
        }

        private sealed class ProbePolicy : HttpPipelineSynchronousPolicy
        {
            private readonly Action _onSend;
            public ProbePolicy(Action onSend) { _onSend = onSend; }
            public override void OnSendingRequest(HttpMessage message)
            {
                _onSend();
                base.OnSendingRequest(message);
            }
        }

        private sealed class StampHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            private readonly string _name;
            private readonly string _value;
            public StampHeaderPolicy(string name, string value) { _name = name; _value = value; }
            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add(_name, _value);
                base.OnSendingRequest(message);
            }
        }
    }
}
