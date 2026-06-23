// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    public class SecretClientTests: ClientTestBase
    {
        public SecretClientTests(bool isAsync) : base(isAsync)
        {
            SecretClientOptions options = new SecretClientOptions
            {
                Transport = new MockTransport(),
            };

            Client = InstrumentClient(new SecretClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public SecretClient Client { get; }

        [Test]
        public void SetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync(null, "value"));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync("name", null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.SetSecretAsync(null));

            Assert.ThrowsAsync<ArgumentException>(() => Client.SetSecretAsync("", "value"));
        }

        [Test]
        public void UpdatePropertiesArgumentValidation()
        {
            SecretProperties secret = new SecretProperties("secret-name");
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateSecretPropertiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.UpdateSecretPropertiesAsync(secret));
        }

        [Test]
        public void RestoreArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RestoreSecretBackupAsync(null));
        }

        [Test]
        public void PurgeDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.PurgeDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.PurgeDeletedSecretAsync(""));
        }

        [Test]
        public void GetArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetSecretAsync(""));
        }

        [Test]
        public void DeleteArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartDeleteSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartDeleteSecretAsync(""));
        }

        [Test]
        public void GetDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.GetDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.GetDeletedSecretAsync(""));
        }

        [Test]
        public void RecoverDeletedArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartRecoverDeletedSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartRecoverDeletedSecretAsync(""));
        }

        [Test]
        public void GetSecretVersionsArgumentValidation()
        {
            Assert.Throws<ArgumentNullException>(() => Client.GetPropertiesOfSecretVersionsAsync(null));
            Assert.Throws<ArgumentException>(() => Client.GetPropertiesOfSecretVersionsAsync(""));
        }

        [Test]
        public void ChallengeBasedAuthenticationRequiresHttps()
        {
            // After passing parameter validation, ChallengeBasedAuthenticationPolicy should throw for "http" requests.
            Assert.ThrowsAsync<InvalidOperationException>(() => Client.GetSecretAsync("test"));
        }

        [Test]
        public async Task PagesResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1""},
                        {""id"": ""https://test/secrets/2""}
                    ],
                    ""nextLink"": ""https://test/secrets?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/secrets?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var secrets = await client.GetPropertiesOfSecretsAsync().ToEnumerableAsync();
            Assert.AreEqual(3, secrets.Count);
        }

        [Test]
        public async Task PagesVersionsResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1/1""},
                        {""id"": ""https://test/secrets/1/2""}
                    ],
                    ""nextLink"": ""https://test/secrets/1/versions?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/secrets/1/versions?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var versions = await client.GetPropertiesOfSecretVersionsAsync("1").ToEnumerableAsync();
            Assert.AreEqual(3, versions.Count);
        }

        [Test]
        public async Task PagesDeletedResults()
        {
            MockTransport transport = new(
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/1""},
                        {""id"": ""https://test/secrets/2""}
                    ],
                    ""nextLink"": ""https://test/deletedsecrets?$skiptoken=1""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [],
                    ""nextLink"": ""https://test/deletedsecrets?$skiptoken=2""
                }"),
                new MockResponse(200).WithJson(@"
                {
                    ""value"": [
                        {""id"": ""https://test/secrets/3""}
                    ]
                }"));

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://test"), new MockCredential(), new() { Transport = transport }));

            var secrets = await client.GetDeletedSecretsAsync().ToEnumerableAsync();
            Assert.AreEqual(3, secrets.Count);
        }

        // -------------------------------------------------------------------
        // Service-version mapping. Pre-7.5 enum values are mapped to wire
        // api-version 7.5 (the operations exposed by this client are identical
        // on those versions). All values must construct successfully — silent
        // breaking changes for customers who pinned an older enum value are
        // not acceptable.
        // -------------------------------------------------------------------

        [Test]
        public void AllServiceVersionsConstructSuccessfully()
        {
            foreach (SecretClientOptions.ServiceVersion v in Enum.GetValues(typeof(SecretClientOptions.ServiceVersion)))
            {
                Assert.DoesNotThrow(
                    () => new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), new SecretClientOptions(v)),
                    $"SecretClientOptions.ServiceVersion.{v} must construct successfully (no breaking change for existing customers)");
            }
        }

        // Proves the wire api-version that goes on every request for each
        // SecretClientOptions.ServiceVersion enum value. V7_0..V7_4 are
        // intentionally mapped to "7.5" — those older spec versions only
        // differ from 7.5 in operations this client does not expose, so the
        // result is functionally identical for every existing caller. This
        // test pins that mapping so a future refactor cannot silently change
        // the wire api-version a caller experiences.
        [TestCase(SecretClientOptions.ServiceVersion.V7_0,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_1,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_2,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_3,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_4,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_5,        "7.5")]
        [TestCase(SecretClientOptions.ServiceVersion.V7_6,        "7.6")]
        [TestCase(SecretClientOptions.ServiceVersion.V2025_07_01,         "2025-07-01")]
        [TestCase(SecretClientOptions.ServiceVersion.V2026_05_01_Preview, "2026-05-01-preview")]
        public async Task ServiceVersion_SendsExpectedWireApiVersion(SecretClientOptions.ServiceVersion version, string expectedWireVersion)
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            var options = new SecretClientOptions(version) { Transport = transport };

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), options));
            await client.GetSecretAsync("x");

            // The api-version is a query parameter on every Key Vault request.
            // Parse it manually to stay BCL-clean (System.Web is not available
            // on net462 and we don't want a netstandard polyfill just for tests).
            string query = transport.SingleRequest.Uri.Query ?? string.Empty;
            string actual = null;
            foreach (string kv in query.TrimStart('?').Split('&'))
            {
                int eq = kv.IndexOf('=');
                if (eq < 0) continue;
                if (string.Equals(kv.Substring(0, eq), "api-version", StringComparison.OrdinalIgnoreCase))
                {
                    actual = System.Uri.UnescapeDataString(kv.Substring(eq + 1));
                    break;
                }
            }
            Assert.AreEqual(expectedWireVersion, actual,
                $"ServiceVersion.{version} should result in api-version={expectedWireVersion} on the wire");
        }

        // -------------------------------------------------------------------
        // Options pass-through. Before this PR's rewire SecretClient handed
        // the user's SecretClientOptions directly to HttpPipelineBuilder.Build;
        // every ClientOptions field (Retry, Diagnostics allow-lists, Transport,
        // AddPolicy entries) flowed through automatically. The rewire keeps
        // that contract — these tests guard it.
        // -------------------------------------------------------------------

        [Test]
        public async Task AddPolicy_PerCall_IsInvoked()
        {
            int hits = 0;
            var probe = new ProbePolicy(() => hits++);

            var transport = new MockTransport(new MockResponse(200).WithJson(@"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            var options = new SecretClientOptions { Transport = transport };
            options.AddPolicy(probe, HttpPipelinePosition.PerCall);

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), options));
            await client.GetSecretAsync("x");

            Assert.Greater(hits, 0, "Per-call AddPolicy must execute on the request pipeline.");
        }

        [Test]
        public async Task AddPolicy_PerRetry_IsInvoked()
        {
            int hits = 0;
            var probe = new ProbePolicy(() => hits++);

            var transport = new MockTransport(new MockResponse(200).WithJson(@"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            var options = new SecretClientOptions { Transport = transport };
            options.AddPolicy(probe, HttpPipelinePosition.PerRetry);

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), options));
            await client.GetSecretAsync("x");

            Assert.Greater(hits, 0, "Per-retry AddPolicy must execute on the request pipeline.");
        }

        [Test]
        public async Task CustomRetry_MaxRetries_IsHonored()
        {
            // Three 500s then a 200; the legacy client would retry up to
            // MaxRetries times. Confirm the rewire honors that.
            var transport = new MockTransport(
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(200).WithJson(@"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));

            var options = new SecretClientOptions
            {
                Transport = transport,
                Retry =
                {
                    MaxRetries = 5,
                    Mode       = RetryMode.Fixed,
                    Delay      = TimeSpan.Zero,
                    MaxDelay   = TimeSpan.Zero,
                },
            };

            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), options));
            Response<KeyVaultSecret> response = await client.GetSecretAsync("x");

            Assert.AreEqual("v", response.Value.Value);
            Assert.AreEqual(4, transport.Requests.Count,
                "Customer's Retry.MaxRetries must be honored by the new pipeline.");
        }

        [Test]
        public async Task Diagnostics_LoggedHeaderNames_Propagate()
        {
            // Stronger guarantee than "ApplicationId is in User-Agent": prove that
            // a custom header on the LoggedHeaderNames allow-list actually appears
            // in the AzureEventSourceListener's log records. The listener emits the
            // request as text; sanitization replaces non-allowed header values with
            // "REDACTED". Asserting that our custom header VALUE is present proves
            // the allow-list was honored end-to-end by the new pipeline.
            var capturedLogContent = new System.Text.StringBuilder();
            using var listener = new Azure.Core.Diagnostics.AzureEventSourceListener(
                (e, msg) =>
                {
                    if (e.EventSource.Name == "Azure-Core" && e.EventId == 1 /* Request */)
                    {
                        capturedLogContent.AppendLine(msg);
                    }
                },
                System.Diagnostics.Tracing.EventLevel.Verbose);

            var transport = new MockTransport(new MockResponse(200).WithJson(@"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            // A probe policy stamps the headers + query that our allow-lists permit,
            // so the logger has something to actually log under those names.
            var stamp = new HttpPipelineSynchronousPolicyForTest(message =>
            {
                message.Request.Headers.Add("x-custom-diag", "diag-marker-1234");
                message.Request.Uri.AppendQuery("audit", "audit-marker-5678");
            });
            var options = new SecretClientOptions
            {
                Transport = transport,
                Diagnostics =
                {
                    IsLoggingEnabled      = true,
                    LoggedHeaderNames     = { "x-custom-diag" },
                    LoggedQueryParameters = { "audit" },
                    ApplicationId         = "kv-pt-test",
                },
            };
            options.AddPolicy(stamp, HttpPipelinePosition.PerCall);
            SecretClient client = InstrumentClient(new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), options));

            await client.GetSecretAsync("x");
            // Allow EventListener to flush.
            await Task.Delay(50);

            string log = capturedLogContent.ToString();
            Assert.That(log, Does.Contain("kv-pt-test"),                 "ApplicationId must reach the logging layer via User-Agent.");
            Assert.That(log, Does.Contain("diag-marker-1234"),           "LoggedHeaderNames allow-listed value must appear unsanitized in logs.");
            Assert.That(log, Does.Contain("audit-marker-5678"),          "LoggedQueryParameters allow-listed value must appear unsanitized in logs.");
        }

        // Tiny no-op policy used by the AddPolicy tests above. Increments a
        // counter every time the pipeline invokes it.
        private sealed class ProbePolicy : Azure.Core.Pipeline.HttpPipelineSynchronousPolicy
        {
            private readonly Action _onSend;
            public ProbePolicy(Action onSend) { _onSend = onSend; }
            public override void OnSendingRequest(HttpMessage message)
            {
                _onSend();
                base.OnSendingRequest(message);
            }
        }

        // Stamp a header / query parameter onto outgoing requests so the
        // diagnostics test has something concrete the allow-list can let through.
        private sealed class HttpPipelineSynchronousPolicyForTest : Azure.Core.Pipeline.HttpPipelineSynchronousPolicy
        {
            private readonly Action<HttpMessage> _onSend;
            public HttpPipelineSynchronousPolicyForTest(Action<HttpMessage> onSend) { _onSend = onSend; }
            public override void OnSendingRequest(HttpMessage message)
            {
                _onSend(message);
                base.OnSendingRequest(message);
            }
        }

        // Snapshot the outgoing request body bytes before the transport consumes
        // them. RequestContent is a one-shot reader so reading it post-hoc from
        // MockTransport.SingleRequest.Content throws NRE.
        private sealed class BodyCapturePolicy : Azure.Core.Pipeline.HttpPipelineSynchronousPolicy
        {
            private readonly Action<byte[]> _onCapture;
            public BodyCapturePolicy(Action<byte[]> onCapture) { _onCapture = onCapture; }
            public override void OnSendingRequest(HttpMessage message)
            {
                if (message.Request.Content != null)
                {
                    using var ms = new System.IO.MemoryStream();
                    message.Request.Content.WriteTo(ms, default);
                    _onCapture(ms.ToArray());
                }
                base.OnSendingRequest(message);
            }
        }

        // -------------------------------------------------------------------
        // SecretMapper.WriteUpdateBody — wire-shape correctness for the PATCH
        // body produced by UpdateSecretProperties. These tests guard the most
        // dangerous regression in the rewire: silently wiping server tags by
        // emitting an empty "tags" object when the caller didn't intend to
        // change them. The legacy hand-written SecretClient only emitted the
        // tags field when the backing dictionary was non-null AND non-empty.
        // -------------------------------------------------------------------

        [Test]
        public void WriteUpdateBody_TagsNotRead_DoesNotEmitTagsField()
        {
            // Customer never touched .Tags — _tags is null — server tags
            // must be left as-is, so the PATCH body must not contain "tags".
            var props = new SecretProperties("name") { Version = "ver" };

            using var body = SecretMapper.WriteUpdateBody(props);
            using var doc = System.Text.Json.JsonDocument.Parse(body);

            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _),
                "Untouched .Tags must not emit a 'tags' field; otherwise server tags would be wiped.");
        }

        [Test]
        public void WriteUpdateBody_EmptyTagsRead_DoesNotEmitTagsField()
        {
            // Customer reads .Tags (e.g. to inspect them) but does not add or
            // remove anything. The getter eagerly initializes an empty dictionary,
            // but we still must not send "tags": {} to the server. This mirrors
            // the legacy KeyVaultPipeline behavior exactly.
            var props = new SecretProperties("name") { Version = "ver" };
            _ = props.Tags; // triggers LazyInitializer.EnsureInitialized

            using var body = SecretMapper.WriteUpdateBody(props);
            using var doc = System.Text.Json.JsonDocument.Parse(body);

            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _),
                "Empty .Tags must not emit a 'tags' field; an empty object would replace server tags with {}.");
        }

        [Test]
        public void WriteUpdateBody_TagsSet_EmitsTagsField()
        {
            var props = new SecretProperties("name") { Version = "ver" };
            props.Tags["env"]   = "prod";
            props.Tags["owner"] = "rohit";

            using var body = SecretMapper.WriteUpdateBody(props);
            using var doc = System.Text.Json.JsonDocument.Parse(body);

            Assert.IsTrue(doc.RootElement.TryGetProperty("tags", out var tags));
            Assert.AreEqual("prod",  tags.GetProperty("env").GetString());
            Assert.AreEqual("rohit", tags.GetProperty("owner").GetString());
        }

        [Test]
        public void WriteUpdateBody_AttributesSet_EmitsExpectedFields()
        {
            // Wire shape sanity: enabled / nbf / exp are emitted as the
            // legacy SecretClient did (unix-seconds for nbf/exp, boolean
            // for enabled), and the read-only attributes (created/updated/
            // recoverableDays/recoveryLevel) are never echoed back.
            var pivot = new DateTimeOffset(2026, 6, 15, 12, 0, 0, TimeSpan.Zero);
            var props = new SecretProperties("name")
            {
                Version   = "ver",
                Enabled   = false,
                NotBefore = pivot,
                ExpiresOn = pivot.AddDays(30),
                ContentType = "application/json",
            };

            using var body = SecretMapper.WriteUpdateBody(props);
            using var doc = System.Text.Json.JsonDocument.Parse(body);

            Assert.AreEqual("application/json", doc.RootElement.GetProperty("contentType").GetString());
            System.Text.Json.JsonElement attrs = doc.RootElement.GetProperty("attributes");
            Assert.IsFalse(attrs.GetProperty("enabled").GetBoolean());
            Assert.AreEqual(pivot.ToUnixTimeSeconds(),               attrs.GetProperty("nbf").GetInt64());
            Assert.AreEqual(pivot.AddDays(30).ToUnixTimeSeconds(),   attrs.GetProperty("exp").GetInt64());
            // read-only fields must not be present
            Assert.IsFalse(attrs.TryGetProperty("created",         out _));
            Assert.IsFalse(attrs.TryGetProperty("updated",         out _));
            Assert.IsFalse(attrs.TryGetProperty("recoverableDays", out _));
            Assert.IsFalse(attrs.TryGetProperty("recoveryLevel",   out _));
        }

        [Test]
        public void WriteUpdateBody_NoAttributesTouched_OmitsAttributesObject()
        {
            // No enabled/nbf/exp set, no content type, no tags → body should
            // be {} (an empty JSON object). The PATCH semantics on the
            // server side are "leave everything as-is" for unspecified fields.
            var props = new SecretProperties("name") { Version = "ver" };

            using var body = SecretMapper.WriteUpdateBody(props);
            using var doc = System.Text.Json.JsonDocument.Parse(body);

            Assert.AreEqual(System.Text.Json.JsonValueKind.Object, doc.RootElement.ValueKind);
            Assert.IsFalse(doc.RootElement.TryGetProperty("attributes",  out _));
            Assert.IsFalse(doc.RootElement.TryGetProperty("contentType", out _));
            Assert.IsFalse(doc.RootElement.TryGetProperty("tags",        out _));
        }
        // -------------------------------------------------------------------
        // Wire-shape guards for GetSecret(outContentType), SetSecret tags,
        // DisableChallengeResourceVerification, and DeleteSecretOperation's
        // immediate-success path when the server omits RecoveryId.
        // -------------------------------------------------------------------

        [TestCase("application/x-pem-file")]
        [TestCase("application/x-pkcs12")]
        public async Task GetSecret_OutContentType_AddedAsQueryParameter(string contentType)
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            await client.GetSecretAsync("x", version: null, outContentType: new SecretContentType(contentType));

            string query = transport.SingleRequest.Uri.Query ?? string.Empty;
            string actual = null;
            foreach (string kv in query.TrimStart('?').Split('&'))
            {
                int eq = kv.IndexOf('=');
                if (eq < 0) continue;
                if (string.Equals(kv.Substring(0, eq), "outContentType", StringComparison.OrdinalIgnoreCase))
                {
                    actual = System.Uri.UnescapeDataString(kv.Substring(eq + 1));
                    break;
                }
            }
            Assert.AreEqual(contentType, actual, "outContentType should be passed as a query parameter.");
        }

        [Test]
        public async Task GetSecret_NoOutContentType_OmitsQueryParameter()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            await client.GetSecretAsync("x");

            string query = transport.SingleRequest.Uri.Query ?? string.Empty;
            Assert.IsFalse(query.Contains("outContentType", StringComparison.OrdinalIgnoreCase),
                "outContentType must not appear when the caller didn't specify it.");
        }

        [Test]
        public async Task SetSecret_WithTags_EmitsTagsInBody()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            byte[] captured = null;
            var capture = new BodyCapturePolicy(bytes => captured = bytes);
            var options = new SecretClientOptions { Transport = transport };
            options.AddPolicy(capture, HttpPipelinePosition.PerCall);
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                options));

            var secret = new KeyVaultSecret("x", "value");
            secret.Properties.Tags["env"] = "prod";
            secret.Properties.Tags["region"] = "westus";
            await client.SetSecretAsync(secret);

            Assert.IsNotNull(captured, "Request body was not captured.");
            using var doc = System.Text.Json.JsonDocument.Parse(captured);
            Assert.IsTrue(doc.RootElement.TryGetProperty("tags", out var tags));
            Assert.AreEqual("prod",   tags.GetProperty("env").GetString());
            Assert.AreEqual("westus", tags.GetProperty("region").GetString());
            Assert.AreEqual("value",  doc.RootElement.GetProperty("value").GetString());
        }

        [Test]
        public async Task SetSecret_NoTags_OmitsTagsInBody()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}"));
            byte[] captured = null;
            var capture = new BodyCapturePolicy(bytes => captured = bytes);
            var options = new SecretClientOptions { Transport = transport };
            options.AddPolicy(capture, HttpPipelinePosition.PerCall);
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                options));

            await client.SetSecretAsync(new KeyVaultSecret("x", "value"));

            Assert.IsNotNull(captured, "Request body was not captured.");
            using var doc = System.Text.Json.JsonDocument.Parse(captured);
            // Tags collection was never touched - wire body should not carry an
            // empty {} that could be misread as "wipe tags" on a future server.
            Assert.IsFalse(doc.RootElement.TryGetProperty("tags", out _));
        }

        [Test]
        public void DisableChallengeResourceVerification_HonoredByOptions()
        {
            var opts = new SecretClientOptions { DisableChallengeResourceVerification = true };
            var client = new SecretClient(new Uri("https://example.vault.azure.net"), new MockCredential(), opts);
            Assert.IsTrue(opts.DisableChallengeResourceVerification);
            Assert.IsNotNull(client);
        }

        // Strengthened guard: prove the DisableChallengeResourceVerification flag
        // actually reaches the ChallengeBasedAuthenticationPolicy on the pipeline.
        // The flag toggles whether the auth policy validates that the
        // WWW-Authenticate resource matches the requested vault URI; a regression
        // (e.g. the SecretClient ctor dropping the flag when constructing the
        // policy) would let mismatched resources flow undetected. Here we hit a
        // vault, follow the 401 challenge, and observe that a second request is
        // emitted with a bearer token even though the challenge resource
        // (https://attacker.example) does NOT match the vault host.
        [Test]
        public async Task DisableChallengeResourceVerification_True_AllowsMismatchedChallengeResource()
        {
            var challenge = new MockResponse(401);
            challenge.AddHeader("WWW-Authenticate",
                "Bearer authorization=\"https://login.microsoftonline.com/common\", resource=\"https://attacker.example\"");
            var success = new MockResponse(200).WithJson(
                @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}");

            var transport = new MockTransport(challenge, success);
            var opts = new SecretClientOptions
            {
                Transport = transport,
                DisableChallengeResourceVerification = true,
            };
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                opts));

            await client.GetSecretAsync("x");

            // Two requests sent (challenge + retry with bearer) means the policy
            // accepted the mismatched challenge resource. With the flag off, the
            // policy would throw before the retry.
            Assert.AreEqual(2, transport.Requests.Count, "Expected challenge + authorized retry.");
            Assert.IsTrue(transport.Requests[1].Headers.TryGetValue("Authorization", out string auth));
            StringAssert.StartsWith("Bearer", auth);
        }

        [Test]
        public async Task DeleteSecretOperation_NullRecoveryId_CompletesImmediately()
        {
            // A vault with soft-delete disabled returns a delete shape that has
            // no recoveryId. The legacy SecretClient surfaced this as a completed
            // operation on the first response; guard the same here.
            var deletePayload = @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}";
            var transport = new MockTransport(new MockResponse(200).WithJson(deletePayload));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            DeleteSecretOperation op = await client.StartDeleteSecretAsync("x");
            Assert.IsTrue(op.HasCompleted,
                "Soft-delete-disabled vault response (no recoveryId) must complete immediately.");
            Assert.IsNotNull(op.Value);
            Assert.AreEqual("x", op.Value.Name);
        }
        [Test]
        public void BackupArgumentValidation()
        {
            // Use only the async path - InstrumentClient wraps `Client` to
            // require async invocation (matches the rest of this file's pattern,
            // e.g. GetArgumentValidation above).
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.BackupSecretAsync(null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.BackupSecretAsync(string.Empty));
        }

        // -------------------------------------------------------------------
        // LRO status-code mapping: 200 -> Success, 403 -> Success (access denied
        // but proves the operation completed), 404 -> Pending, 5xx -> Failure.
        // -------------------------------------------------------------------

        [TestCase(200, true)]
        [TestCase(403, true)]
        [TestCase(404, false)]
        public async Task DeleteSecretOperation_PollStatusMapping(int statusCode, bool expectCompleted)
        {
            var payload = @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1"",""recoveryId"":""https://example.vault.azure.net/deletedsecrets/x""}";
            var pollResponse = new MockResponse(statusCode);
            if (statusCode == 200) pollResponse = pollResponse.WithJson(payload);

            var transport = new MockTransport(
                new MockResponse(200).WithJson(payload),
                pollResponse);

            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            DeleteSecretOperation op = await client.StartDeleteSecretAsync("x");
            Assert.IsFalse(op.HasCompleted, "Should be pending before first poll.");
            await op.UpdateStatusAsync();
            Assert.AreEqual(expectCompleted, op.HasCompleted,
                $"HTTP {statusCode} should map to {(expectCompleted ? "Completed" : "Pending")}.");
        }

        [Test]
        public async Task DeleteSecretOperation_ServerError_Fails()
        {
            var payload = @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1"",""recoveryId"":""https://example.vault.azure.net/deletedsecrets/x""}";
            // Repeat the 500 response so retry-policy can drain its retries.
            var transport = new MockTransport(
                new MockResponse(200).WithJson(payload),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500));

            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            DeleteSecretOperation op = await client.StartDeleteSecretAsync("x");
            Assert.ThrowsAsync<RequestFailedException>(() => op.UpdateStatusAsync().AsTask());
        }

        [TestCase(200, true)]
        [TestCase(403, true)]
        [TestCase(404, false)]
        public async Task RecoverDeletedSecretOperation_PollStatusMapping(int statusCode, bool expectCompleted)
        {
            var payload = @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}";
            var pollResponse = new MockResponse(statusCode);
            if (statusCode == 200) pollResponse = pollResponse.WithJson(payload);

            var transport = new MockTransport(
                new MockResponse(200).WithJson(payload),
                pollResponse);

            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            RecoverDeletedSecretOperation op = await client.StartRecoverDeletedSecretAsync("x");
            Assert.IsFalse(op.HasCompleted, "Should be pending before first poll.");
            await op.UpdateStatusAsync();
            Assert.AreEqual(expectCompleted, op.HasCompleted,
                $"HTTP {statusCode} should map to {(expectCompleted ? "Completed" : "Pending")}.");
        }

        [Test]
        public async Task RecoverDeletedSecretOperation_ServerError_Fails()
        {
            var payload = @"{""value"":""v"",""id"":""https://example.vault.azure.net/secrets/x/1""}";
            // Repeat the 500 response so retry-policy can drain its retries.
            var transport = new MockTransport(
                new MockResponse(200).WithJson(payload),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500),
                new MockResponse(500));

            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            RecoverDeletedSecretOperation op = await client.StartRecoverDeletedSecretAsync("x");
            Assert.ThrowsAsync<RequestFailedException>(() => op.UpdateStatusAsync().AsTask());
        }
        // Wire-shape end-to-end: UpdateSecretProperties must hit
        // PATCH /secrets/{name}/{version}. Guards directly against the
        // UpdateSecret arg-order emitter bug Patch 1 fixes. If the regex
        // silently no-ops on a future emitter change, this test fails fast
        // instead of waiting for a recording to drift.
        [Test]
        public async Task UpdateSecretProperties_PathHasNameThenVersion()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(
                @"{""id"":""https://example.vault.azure.net/secrets/x/abc123""}"));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            var props = new SecretProperties("x") { Version = "abc123" };
            props.Enabled = true;
            await client.UpdateSecretPropertiesAsync(props);

            string path = transport.SingleRequest.Uri.Path;
            Assert.AreEqual("/secrets/x/abc123", path,
                "UpdateSecretProperties must build /secrets/{name}/{version}; the emitter arg-order bug would produce /secrets/abc123/x.");
            Assert.AreEqual(RequestMethod.Patch, transport.SingleRequest.Method);
        }

        // RecoverDeletedSecretOperation.Id used to throw NullReferenceException
        // when the server response omitted the "id" field, because
        // _value.Id.AbsoluteUri was unconditional. Commit 03821dc made it
        // null-conditional (?.AbsoluteUri ?? string.Empty). Pin that contract.
        [Test]
        public async Task RecoverDeletedSecretOperation_NullId_OperationIdIsEmpty()
        {
            // Response body intentionally omits "id".
            var transport = new MockTransport(new MockResponse(200).WithJson(@"{""value"":""v""}"));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            RecoverDeletedSecretOperation op = await client.StartRecoverDeletedSecretAsync("x");
            Assert.DoesNotThrow(() => { _ = op.Id; });
            Assert.AreEqual(string.Empty, op.Id);
        }

        // Same null-id guard for DeleteSecretOperation. Both LRO classes do
        // the same null-conditional pattern - pin it in both.
        [Test]
        public async Task DeleteSecretOperation_NullId_OperationIdIsEmpty()
        {
            var transport = new MockTransport(new MockResponse(200).WithJson(@"{""value"":""v""}"));
            SecretClient client = InstrumentClient(new SecretClient(
                new Uri("https://example.vault.azure.net"),
                new MockCredential(),
                new SecretClientOptions { Transport = transport }));

            DeleteSecretOperation op = await client.StartDeleteSecretAsync("x");
            Assert.DoesNotThrow(() => { _ = op.Id; });
            Assert.AreEqual(string.Empty, op.Id);
        }
    }
}
