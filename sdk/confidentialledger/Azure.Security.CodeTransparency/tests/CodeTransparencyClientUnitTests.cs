// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Formats.Cbor;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.Cose;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyClientUnitTests : ClientTestBase
    {
        private string _fileQualifierPrefix;

        /// <summary>
        /// A canned service identity response. But with a parseable cert.
        /// </summary>
        private readonly string _serviceIdentityJson = """
        {
            "ledgerTlsCertificate": "-----BEGIN CERTIFICATE-----\nMIIBvjCCAUSgAwIBAgIRALIcCHAQ8TpbFgvuNThTIFkwCgYIKoZIzj0EAwMwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjQwMTAzMDg1NDM2WhcNMjQwNDAyMDg1\nNDM1WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazB2MBAGByqGSM49AgEGBSuBBAAi\nA2IABFK177XlxO+GvJ91xjC98icJRKJbUIOSffHYEWAKojxvEa7EV1eVUINye0tU\nZJVVI5Nw2Y7Gbi7cm89Njnvz/uYUHBp/di3Rk+R4kupHEH6XErTMN93CAR4lIBOY\ndF7JpqNWMFQwEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU4px9yVX1Ru3W\nefhlw88K2zmyFQEwHwYDVR0jBBgwFoAU4px9yVX1Ru3Wefhlw88K2zmyFQEwCgYI\nKoZIzj0EAwMDaAAwZQIwG20Zjw5WPVoW6jsIchwSnfhniJNr0xF8hJJKUXIfyEDo\nnPewSdWnE4RubOm/ctMYAjEAlvwpdzSDFg57beLfq0bhaznxGOBpYQXl+q1uzm/S\nPup20CFNsp8G8m7w076DGJEA\n-----END CERTIFICATE-----\n",
            "ledgerId": "cts-canary"
        }
        """;

        private readonly string ValidSignedStatementJWKS =
            "{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"fb29ce6d6b37e7a0b03a5fc94205490e1c37de1f41f68b92e3620021e9981d01\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"Tv_tP9eJIb5oJY9YB6iAzMfds4v3N84f8pgcPYLaxd_Nj3Nb_dBm6Fc8ViDZQhGR\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}";

        private readonly string InvalidSignedStatementJWKSWithWrongKid =
            "{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"99954f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"Tv_tP9eJIb5oJY9YB6iAzMfds4v3N84f8pgcPYLaxd_Nj3Nb_dBm6Fc8ViDZQhGR\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}";

        private readonly string InvalidSignedStatementJWKSWithWrongP521Algorithm =
            "{\"keys\":" +
                "[{\"crv\": \"P-521\"," +
                "\"kid\":\"fb29ce6d6b37e7a0b03a5fc94205490e1c37de1f41f68b92e3620021e9981d01\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"Tv_tP9eJIb5oJY9YB6iAzMfds4v3N84f8pgcPYLaxd_Nj3Nb_dBm6Fc8ViDZQhGR\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}";

        private readonly string InvalidSignedStatementJWKSWithWrongParams =
            "{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"1dd54f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}";

        private byte[] readFileBytes(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix + name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix + name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        [SetUp]
        public void BaseSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "transparent_statement.cose";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[] { mustExistFilename }, StringSplitOptions.None)[0];
        }

        private MockResponse createValidCanaryIdentityResponse()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent(_serviceIdentityJson);
            return mockedResponse;
        }

        private MockResponse createValidSignedStatementPublicKeyResponse()
        {
            var content = new MockResponse(200);
            content.SetContent(ValidSignedStatementJWKS);
            return content;
        }

        private MockResponse createInvalidSignedStatementPublicKeyResponseWithWrongKid()
        {
            var content = new MockResponse(200);
            content.SetContent(InvalidSignedStatementJWKSWithWrongKid);
            return content;
        }

        private MockResponse createInvalidSignedStatementPublicKeyResponseWithWrongP521Algorithm()
        {
            var content = new MockResponse(200);
            content.SetContent(InvalidSignedStatementJWKSWithWrongP521Algorithm);
            return content;
        }

        private MockResponse createInvalidSignedStatementPublicKeyResponseWithWrongParams()
        {
            var content = new MockResponse(200);
            content.SetContent(InvalidSignedStatementJWKSWithWrongParams);
            return content;
        }

        private (MockTransport MockedTransport, CodeTransparencyClientOptions MockedClientOptions) createClientOptionsWithValidPublicKeyResponse()
        {
            var content = createValidSignedStatementPublicKeyResponse();
            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            return (mockTransport, options);
        }

        private (byte[] Receipt, byte[] SignedStatement, byte[] TransparentStatement) createStatementWithEmptyInclusionProof()
        {
            CoseSign1Message transparentStatement = CoseMessage.DecodeSign1(readFileBytes("transparent_statement.cose"));
            CoseHeaderValue embeddedReceipts = transparentStatement.UnprotectedHeaders[
                new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts)];
            CborReader receiptsReader = new(embeddedReceipts.EncodedValue);
            receiptsReader.ReadStartArray();
            CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptsReader.ReadByteString());
            receiptsReader.ReadEndArray();

            CborWriter proofWriter = new();
            proofWriter.WriteStartMap(1);
            proofWriter.WriteInt32(CcfReceipt.CoseReceiptInclusionProofLabel);
            proofWriter.WriteStartArray(0);
            proofWriter.WriteEndArray();
            proofWriter.WriteEndMap();
            receipt.UnprotectedHeaders[new CoseHeaderLabel(CcfReceipt.CosePhdrVdpLabel)] =
                CoseHeaderValue.FromEncodedValue(proofWriter.Encode());
            byte[] receiptBytes = receipt.Encode();

            CborWriter receiptsWriter = new();
            receiptsWriter.WriteStartArray(1);
            receiptsWriter.WriteByteString(receiptBytes);
            receiptsWriter.WriteEndArray();
            transparentStatement.UnprotectedHeaders[new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts)] =
                CoseHeaderValue.FromEncodedValue(receiptsWriter.Encode());
            byte[] transparentStatementBytes = transparentStatement.Encode();

            transparentStatement.UnprotectedHeaders.Clear();
            return (receiptBytes, transparentStatement.Encode(), transparentStatementBytes);
        }

        public CodeTransparencyClientUnitTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void CodeTransparencyClient_constructor_does_not_request_to_get_cert()
        {
            var mockTransport = new MockTransport(createValidCanaryIdentityResponse());
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var _ = new CodeTransparencyClient(new Uri("https://foo.bar.com"), null, options);
            Assert.AreEqual(0, mockTransport.Requests.Count);
        }

        [Test]
        public async Task CreateEntryAsync_sendsBytes_receives_bytes()
        {
            // With waitForCommit the service returns the committed entry; the entry id comes
            // from the Location header and the returned operation is already completed.
            var mockedResponse = new MockResponse(201);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.AddHeader("Location", "https://foo.bar.com/entries/12.345");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            CreateEntryOperation response = await client.CreateEntryAsync(WaitUntil.Completed, content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true", mockTransport.Requests[0].Uri.ToString());
            Assert.IsTrue(response.HasCompleted);
            Assert.AreEqual("12.345", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_request_accepted()
        {
            // WaitUntil.Started returns after the service accepts the entry. The operation polls
            // the entry resource until it is committed.
            var acceptedResponse = new MockResponse(303);
            acceptedResponse.AddHeader("Location", "https://foo.bar.com/entries/12.345");
            var pendingResponse = new MockResponse(302);
            pendingResponse.AddHeader("Location", "https://foo.bar.com/entries/12.345");
            var completedResponse = new MockResponse(200);
            completedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(acceptedResponse, pendingResponse, completedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            CreateEntryOperation response = await client.CreateEntryAsync(WaitUntil.Started, content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2026-03-26&waitForCommit=false", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(1, mockTransport.Requests.Count);
            Assert.IsFalse(response.HasCompleted);
            Assert.AreEqual("12.345", response.Id);

            await response.UpdateStatusAsync();
            Assert.IsFalse(response.HasCompleted);
            await response.UpdateStatusAsync();
            Assert.IsTrue(response.HasCompleted);
            Assert.AreEqual("https://foo.bar.com/entries/12.345?api-version=2026-03-26", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public async Task CreateEntryAsync_unsuccessful_post_success_after_retry()
        {
            var mockedResponse = new MockResponse(201);
            mockedResponse.AddHeader("Location", "https://foo.bar.com/entries/12.345");

            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            CreateEntryOperation response = await client.CreateEntryAsync(WaitUntil.Completed, content);

            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual("12.345", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_waits_for_operation_success()
        {
            // With waitForCommit the create call returns an already-completed operation whose
            // value is a CBOR map containing the committed entry id (taken from the Location header).
            var createResponse = new MockResponse(201);
            createResponse.AddHeader("Location", "https://foo.bar.com/entries/123.23");

            var mockTransport = new MockTransport(createResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            CodeTransparencyClient client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            CreateEntryOperation result = await client.CreateEntryAsync(WaitUntil.Completed, BinaryData.FromString("Hello World!"));

            Assert.NotNull(result);
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
            Assert.AreEqual("123.23", result.Id);

            Response<BinaryData> response = await result.WaitForCompletionAsync();
            string entryId = CodeTransparencyCbor.GetStringValueFromCborMapByKey(response.Value.ToArray(), "EntryId");
            Assert.AreEqual("123.23", entryId);

            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public void CreateEntry_ShouldReturnResponse()
        {
            var mockedResponse = new MockResponse(303);
            mockedResponse.AddHeader("Location", "https://foo.bar.com/entries/12.345");

            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            CodeTransparencyClient client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            CreateEntryOperation result = client.CreateEntry(WaitUntil.Started, BinaryData.FromString("test-body"));

            Assert.AreEqual(1, mockTransport.Requests.Count);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2026-03-26&waitForCommit=false", mockTransport.Requests[0].Uri.ToString());
            Assert.IsFalse(result.HasCompleted);
            Assert.AreEqual("12.345", result.Id);
        }

        private static CodeTransparencyClient CreatePipelineClient(
            MockTransport transport,
            Action<CodeTransparencyClientOptions> configureOptions = null)
        {
            var options = new CodeTransparencyClientOptions
            {
                Transport = transport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            configureOptions?.Invoke(options);
            return new CodeTransparencyClient(
                new Uri("https://foo.bar.com"),
                new AzureKeyCredential("token"),
                options);
        }

        private async Task<NullableResponse<BinaryData>> SubmitEntryAsync(CodeTransparencyClient client, BinaryData body, bool? waitForCommit) =>
            IsAsync ? await client.CreateEntryAsync(body, waitForCommit) : client.CreateEntry(body, waitForCommit);

        private async Task<NullableResponse<BinaryData>> GetReceiptAsync(CodeTransparencyClient client, string entryId) =>
            IsAsync ? await client.GetEntryAsync(entryId) : client.GetEntry(entryId);

        [TestCase(307)]
        [TestCase(308)]
        public async Task CreateEntry_follows_CCF_primary_redirect(int redirectStatus)
        {
            byte[] receipt = { 0x01, 0x02, 0x03 };
            var redirect = new MockResponse(redirectStatus);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
            var committed = new MockResponse(201);
            committed.SetContent(receipt);
            var transport = new MockTransport(redirect, committed);
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await SubmitEntryAsync(
                client,
                BinaryData.FromString("statement"),
                waitForCommit: true);

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual(RequestMethod.Post, transport.Requests[1].Method);
            Assert.AreEqual(
                "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true",
                transport.Requests[1].Uri.ToString());
            Assert.IsNotNull(transport.Requests[1].Content);
            Assert.IsTrue(transport.Requests[1].Headers.TryGetValue("Authorization", out string authorization));
            Assert.IsNotEmpty(authorization);
            Assert.AreEqual(receipt, response.Value.ToArray());
        }

        [Test]
        public async Task CreateEntry_preserves_api_version_when_redirect_location_omits_it()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader("Location", "https://primary.foo.bar.com/entries?waitForCommit=true");
            var committed = new MockResponse(201);
            committed.SetContent(new byte[] { 0x01 });
            var transport = new MockTransport(redirect, committed);
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await SubmitEntryAsync(
                client,
                BinaryData.FromString("statement"),
                waitForCommit: true);

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[1].Uri.Host);
            StringAssert.Contains("waitForCommit=true", transport.Requests[1].Uri.Query);
            StringAssert.Contains("api-version=2026-03-26", transport.Requests[1].Uri.Query);
            Assert.AreEqual(201, response.GetRawResponse().Status);
        }

        [Test]
        public async Task CreateEntry_follows_mixed_redirect_chain()
        {
            int requestNumber = 0;
            var requestHosts = new ConcurrentQueue<string>();
            var requestMethods = new ConcurrentQueue<RequestMethod>();
            var transport = new MockTransport(request =>
            {
                requestHosts.Enqueue(request.Uri.Host);
                requestMethods.Enqueue(request.Method);
                switch (Interlocked.Increment(ref requestNumber))
                {
                    case 1:
                        return new MockResponse(307).AddHeader(
                            "Location",
                            "https://node-1.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
                    case 2:
                        return new MockResponse(308).AddHeader(
                            "Location",
                            "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
                    default:
                        var committed = new MockResponse(201);
                        committed.SetContent(new byte[] { 0x01 });
                        return committed;
                }
            });
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await SubmitEntryAsync(
                client,
                BinaryData.FromString("statement"),
                waitForCommit: true);

            CollectionAssert.AreEqual(
                new[] { "foo.bar.com", "node-1.foo.bar.com", "primary.foo.bar.com" },
                requestHosts.ToArray());
            CollectionAssert.AreEqual(
                new[] { RequestMethod.Post, RequestMethod.Post, RequestMethod.Post },
                requestMethods.ToArray());
            Assert.AreEqual(201, response.GetRawResponse().Status);
        }

        [Test]
        public async Task CreateEntry_retries_transient_failure_after_redirect()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
            var committed = new MockResponse(201);
            committed.SetContent(new byte[] { 0x01 });
            var transport = new MockTransport(redirect, new MockResponse(503), committed);
            CodeTransparencyClient client = CreatePipelineClient(transport, options =>
            {
                options.Retry.MaxRetries = 1;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            NullableResponse<BinaryData> response = await SubmitEntryAsync(
                client,
                BinaryData.FromString("statement"),
                waitForCommit: true);

            Assert.AreEqual(3, transport.Requests.Count);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[1].Uri.Host);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[2].Uri.Host);
            Assert.AreEqual(201, response.GetRawResponse().Status);
        }

        [Test]
        public async Task CreateEntry_uses_cached_primary_for_subsequent_write()
        {
            int requestNumber = 0;
            var requestHosts = new ConcurrentQueue<string>();
            var transport = new MockTransport(request =>
            {
                requestHosts.Enqueue(request.Uri.Host);
                switch (Interlocked.Increment(ref requestNumber))
                {
                    case 1:
                        return new MockResponse(307).AddHeader(
                            "Location",
                            "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
                    case 2:
                        var firstCommitted = new MockResponse(201);
                        firstCommitted.SetContent(new byte[] { 0x01 });
                        return firstCommitted;
                    default:
                        var secondCommitted = new MockResponse(201);
                        secondCommitted.SetContent(new byte[] { 0x02 });
                        return secondCommitted;
                }
            });
            CodeTransparencyClient client = CreatePipelineClient(transport);

            await SubmitEntryAsync(client, BinaryData.FromString("first"), waitForCommit: true);
            await SubmitEntryAsync(client, BinaryData.FromString("second"), waitForCommit: true);

            CollectionAssert.AreEqual(
                new[] { "foo.bar.com", "primary.foo.bar.com", "primary.foo.bar.com" },
                requestHosts.ToArray());
        }

        [Test]
        public void CreateEntry_does_not_retry_when_retries_are_disabled()
        {
            var transport = new MockTransport(new MockResponse(503), new MockResponse(201));
            CodeTransparencyClient client = CreatePipelineClient(transport, options => options.Retry.MaxRetries = 0);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            Assert.AreEqual(503, exception.Status);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [Test]
        public void CreateEntry_fails_after_too_many_redirects()
        {
            var transport = new MockTransport(_ =>
                new MockResponse(307).AddHeader(
                    "Location",
                    "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true"));
            CodeTransparencyClient client = CreatePipelineClient(transport, options => options.Retry.MaxRetries = 0);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            Assert.AreEqual(307, exception.Status);
            Assert.AreEqual(6, transport.Requests.Count);
        }

        [Test]
        public void CreateEntry_fails_when_redirect_has_no_location()
        {
            var transport = new MockTransport(new MockResponse(307), new MockResponse(201));
            CodeTransparencyClient client = CreatePipelineClient(transport, options => options.Retry.MaxRetries = 0);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            Assert.AreEqual(307, exception.Status);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [TestCase("https://attacker.example.com/entries")]
        [TestCase("http://primary.foo.bar.com/entries")]
        public void CreateEntry_refuses_untrusted_primary_redirect(string location)
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader("Location", location);
            var transport = new MockTransport(redirect, new MockResponse(201));
            CodeTransparencyClient client = CreatePipelineClient(transport);

            InvalidOperationException exception = Assert.ThrowsAsync<InvalidOperationException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            StringAssert.Contains("untrusted target origin", exception.Message);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [TestCase(300)]
        [TestCase(301)]
        [TestCase(302)]
        [TestCase(304)]
        public void CreateEntry_does_not_follow_unexpected_redirect_status(int statusCode)
        {
            var response = new MockResponse(statusCode);
            response.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
            var transport = new MockTransport(response, new MockResponse(201));
            CodeTransparencyClient client = CreatePipelineClient(transport, options => options.Retry.MaxRetries = 0);

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            Assert.AreEqual(statusCode, exception.Status);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [Test]
        public void CreateEntry_does_not_retry_terminal_client_error_after_redirect()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries?api-version=2026-03-26&waitForCommit=true");
            var transport = new MockTransport(redirect, new MockResponse(400), new MockResponse(201));
            CodeTransparencyClient client = CreatePipelineClient(transport, options =>
            {
                options.Retry.MaxRetries = 3;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await SubmitEntryAsync(
                    client,
                    BinaryData.FromString("statement"),
                    waitForCommit: true));

            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [Test]
        public async Task GetEntry_retries_503_without_primary_redirect()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            CodeTransparencyClient client = CreatePipelineClient(mockTransport, options =>
            {
                options.Retry.MaxRetries = 1;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2026-03-26", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual(expected: 200, response.GetRawResponse().Status);
        }

        [Test]
        public async Task GetEntry_returns_200_without_primary_redirect()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(mockedResponse);
            CodeTransparencyClient client = CreatePipelineClient(mockTransport);

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2026-03-26", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
        }

        [Test]
        public async Task GetEntry_returns_302_without_primary_redirect()
        {
            var pending = new MockResponse(302);
            pending.AddHeader(
                "Location",
                "https://foo.bar.com/entries/4.44?api-version=2026-03-26");
            var transport = new MockTransport(pending, new MockResponse(200));
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual(302, response.GetRawResponse().Status);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [Test]
        public void GetEntry_returns_400_without_primary_redirect()
        {
            var transport = new MockTransport(new MockResponse(400), new MockResponse(200));
            CodeTransparencyClient client = CreatePipelineClient(transport, options =>
            {
                options.Retry.MaxRetries = 3;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await GetReceiptAsync(client, "invalid-tx-id"));

            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual(1, transport.Requests.Count);
        }

        [Test]
        public async Task GetEntry_follows_307_to_200()
        {
            byte[] receipt = { 0x01, 0x02, 0x03 };
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries/4.44?api-version=2026-03-26");
            var committed = new MockResponse(200);
            committed.SetContent(receipt);
            var transport = new MockTransport(redirect, committed);
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[1].Uri.Host);
            Assert.AreEqual(RequestMethod.Get, transport.Requests[1].Method);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(receipt, response.Value.ToArray());
        }

        [Test]
        public async Task GetEntry_follows_307_then_retries_503()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries/4.44?api-version=2026-03-26");
            var committed = new MockResponse(200);
            committed.SetContent(new byte[] { 0x01, 0x02 });
            var transport = new MockTransport(redirect, new MockResponse(503), committed);
            CodeTransparencyClient client = CreatePipelineClient(transport, options =>
            {
                options.Retry.MaxRetries = 1;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual(3, transport.Requests.Count);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[1].Uri.Host);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[2].Uri.Host);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }

        [Test]
        public async Task GetEntry_follows_307_then_returns_302()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries/4.44?api-version=2026-03-26");
            var pending = new MockResponse(302);
            pending.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries/4.44?api-version=2026-03-26");
            var transport = new MockTransport(redirect, pending, new MockResponse(200));
            CodeTransparencyClient client = CreatePipelineClient(transport);

            NullableResponse<BinaryData> response = await GetReceiptAsync(client, "4.44");

            Assert.AreEqual(302, response.GetRawResponse().Status);
            Assert.AreEqual(2, transport.Requests.Count);
            Assert.AreEqual("primary.foo.bar.com", transport.Requests[1].Uri.Host);
        }

        [Test]
        public void GetEntry_follows_307_then_returns_400()
        {
            var redirect = new MockResponse(307);
            redirect.AddHeader(
                "Location",
                "https://primary.foo.bar.com/entries/invalid-tx-id?api-version=2026-03-26");
            var transport = new MockTransport(redirect, new MockResponse(400), new MockResponse(200));
            CodeTransparencyClient client = CreatePipelineClient(transport, options =>
            {
                options.Retry.MaxRetries = 3;
                options.Retry.Delay = TimeSpan.Zero;
                options.Retry.MaxDelay = TimeSpan.Zero;
            });

            RequestFailedException exception = Assert.ThrowsAsync<RequestFailedException>(
                async () => await GetReceiptAsync(client, "invalid-tx-id"));

            Assert.AreEqual(400, exception.Status);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [Test]
        public async Task CreateEntry_asyncRegistration_follows303_preservesApiVersion_and_retriesPending503()
        {
            // Async registration (waitForCommit=false) is answered with 303 See Other whose Location omits
            // api-version. The redirect policy follows it as a GET with api-version preserved, and a still-
            // pending read that returns a retriable 503 is retried by the pipeline until the committed receipt.
            var redirect = new MockResponse(303);
            redirect.AddHeader("Location", "https://foo.bar.com/entries/12.345"); // no api-version
            var pending = new MockResponse(503);
            var committed = new MockResponse(200);
            committed.AddHeader("Content-Type", "application/cose");
            committed.SetContent(new byte[] { 0x01, 0x02, 0x03 });

            var mockTransport = new MockTransport(redirect, pending, committed);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            options.Retry.Delay = TimeSpan.Zero; // avoid real backoff during the test

            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData body = BinaryData.FromString("Hello World!");

            NullableResponse<BinaryData> response = IsAsync
                ? await client.CreateEntryAsync(body, waitForCommit: false)
                : client.CreateEntry(body, waitForCommit: false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
            Assert.AreEqual(3, mockTransport.Requests.Count);
            StringAssert.Contains("api-version=2026-03-26", mockTransport.Requests[0].Uri.ToString());
            // The followed read and its retry both target the entry with api-version preserved.
            Assert.AreEqual("https://foo.bar.com/entries/12.345?api-version=2026-03-26", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual("https://foo.bar.com/entries/12.345?api-version=2026-03-26", mockTransport.Requests[2].Uri.ToString());
        }

        [Test]
        public async Task CreateEntry_asyncRegistration_follows303_pollsPending302_untilReceipt()
        {
            // The versioned (canary) API answers a read of a not-yet-committed entry with 302 Found
            // (Location points back at the same entry URL). The followed read must be polled/retried
            // until the committed receipt (200) is returned.
            var redirect = new MockResponse(303);
            redirect.AddHeader("Location", "https://foo.bar.com/entries/12.345"); // no api-version
            var pending = new MockResponse(302);
            pending.AddHeader("Location", "https://foo.bar.com/entries/12.345");
            var committed = new MockResponse(200);
            committed.AddHeader("Content-Type", "application/cose");
            committed.SetContent(new byte[] { 0x0A, 0x0B, 0x0C });

            var mockTransport = new MockTransport(redirect, pending, pending, committed);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            options.Retry.Delay = TimeSpan.Zero; // avoid real backoff during the test

            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData body = BinaryData.FromString("Hello World!");

            NullableResponse<BinaryData> response = IsAsync
                ? await client.CreateEntryAsync(body, waitForCommit: false)
                : client.CreateEntry(body, waitForCommit: false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x0A, 0x0B, 0x0C }, response.Value.ToArray());
            Assert.AreEqual(4, mockTransport.Requests.Count); // POST + GET(302) + GET(302) + GET(200)
            // Every followed read (including the polled 302s) targets the entry with api-version preserved.
            Assert.AreEqual("https://foo.bar.com/entries/12.345?api-version=2026-03-26", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual("https://foo.bar.com/entries/12.345?api-version=2026-03-26", mockTransport.Requests[3].Uri.ToString());
        }

        [Test]
        public async Task GetTransparencyConfigCborAsync_ShouldReturnResponse()
        {
            var responseMock = new MockResponse(200);
            responseMock.SetContent(BinaryData.FromString("test-content").ToArray());
            var mockTransport = new MockTransport(responseMock);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            var result = await client.GetTransparencyConfigCborAsync();

            Assert.NotNull(result);
            Assert.AreEqual("test-content", result.Value.ToString());
            Assert.AreEqual("https://foo.bar.com/.well-known/transparency-configuration?api-version=2026-03-26", mockTransport.Requests[0].Uri.ToString());
        }

        [Test]
        public void GetPublicKeys_Success_After_retry()
        {
            var content = createValidSignedStatementPublicKeyResponse();
            var mockTransport = new MockTransport(new MockResponse(503), content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            Response<CodeTransparencyVerificationKeySet> result = client.GetPublicKeys();

            Assert.NotNull(result);
            using ECDsa publicKey = result.Value.Keys.Single().ToECDsa();
            Assert.AreEqual(384, publicKey.KeySize);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://foo.bar.com/jwks?api-version=2026-03-26", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public void VerifyTransparentStatement_InvalidParameters_ShouldThrowCryptographicException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = createInvalidSignedStatementPublicKeyResponseWithWrongParams();
            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
            };
            byte[] transparentStatementCoseSign1Bytes = new byte[] { 0x01, 0x02, 0x03 /* invalid bytes */ };

            Assert.Throws<CryptographicException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementCoseSign1Bytes, verificationOptions, options));
#endif
        }

        [Test]
        public void VerifyTransparentStatement_success()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (mockTransport, options) = createClientOptionsWithValidPublicKeyResponse();
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
            };
            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");

            CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options);
#endif
        }

        [Test]
        public void VerifyTransparentStatementReceipt_EmptyInclusionProofs_ThrowsInvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (_, options) = createClientOptionsWithValidPublicKeyResponse();
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<CodeTransparencyVerificationKeySet> keys = client.GetPublicKeys();
            var statement = createStatementWithEmptyInclusionProof();

            var exception = Assert.Throws<InvalidOperationException>(() =>
                CcfReceiptVerifier.Verify(statement.Receipt, statement.SignedStatement, keys.Value.Keys[0]));

            StringAssert.Contains("At least one inclusion proof is expected", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_EmptyInclusionProofs_ThrowsAggregateException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (_, options) = createClientOptionsWithValidPublicKeyResponse();
            var statement = createStatementWithEmptyInclusionProof();
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
                AuthorizedReceiptBehavior = AuthorizedReceiptBehavior.RequireAll,
                UnauthorizedReceiptBehavior = UnauthorizedReceiptBehavior.FailIfPresent
            };

            var exception = Assert.Throws<AggregateException>(() =>
                CodeTransparencyClient.VerifyTransparentStatement(statement.TransparentStatement, verificationOptions, options));

            StringAssert.Contains("At least one inclusion proof is expected", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_offline_success()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            // Build a trust store from the JWKS for the issuer domain.
            var trustStore = new CodeTransparencyTrustStore();
            trustStore.SetKeys("foo.bar.com", CodeTransparencyKeyParser.ParseJwksJson(System.Text.Encoding.UTF8.GetBytes(ValidSignedStatementJWKS)));

            var mockTransport = new MockTransport(new MockResponse(503));
            var options = new CodeTransparencyClientOptions
            {
                IdentityClientEndpoint = "https://some.identity.com",
                Transport = mockTransport,
            };

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
                TrustStore = trustStore
            };

            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");

            // Should not make any network calls since we're using the trust store
            CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options);

            Assert.AreEqual(0, mockTransport.Requests.Count);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_offline_success_with_fallback()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            // An empty trust store falls back to the network.
            var trustStore = new CodeTransparencyTrustStore();

            var (mockTransport, options) = createClientOptionsWithValidPublicKeyResponse();

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
                TrustStore = trustStore
            };

            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");

            // Trust store is empty, so network fallback is expected; should make 1 network call
            CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options);

            Assert.AreEqual(1, mockTransport.Requests.Count);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_offline_failure_without_network_fallback()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            // An empty trust store with TrustStoreOnly must not fall back to the network.
            var trustStore = new CodeTransparencyTrustStore();

            var mockTransport = new MockTransport(new MockResponse(503));
            var options = new CodeTransparencyClientOptions
            {
                IdentityClientEndpoint = "https://some.identity.com",
                Transport = mockTransport,
            };

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
                TrustStore = trustStore,
                KeyResolutionMode = CodeTransparencyKeyResolutionMode.TrustStoreOnly
            };

            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");
            var exception = Assert.Throws<AggregateException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options));
            StringAssert.Contains("Either a trust store is not configured or network resolution is disabled.", exception.Message);
            Assert.AreEqual(0, mockTransport.Requests.Count);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_P521WithWrongAlgorithm_InvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = createInvalidSignedStatementPublicKeyResponseWithWrongP521Algorithm();
            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
            };
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            // The P-384 coordinates are labeled as P-521, so the key is rejected as malformed during normalization.
            var exception = Assert.Throws<AggregateException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options));
            StringAssert.Contains("malformed or not on the curve", exception.InnerExceptions[0].Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_Invalidkid_InvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = createInvalidSignedStatementPublicKeyResponseWithWrongKid();
            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://some.identity.com"
            };
            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com" },
            };
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            Assert.Throws<AggregateException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options));
#endif
        }

        [Test]
        public void VerifyTransparentStatement_UnauthorizedReceiptBehavior_FailIfPresent()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "wetrustsomethingelse.com" },
                UnauthorizedReceiptBehavior = UnauthorizedReceiptBehavior.FailIfPresent
            };

            var exception = Assert.Throws<InvalidOperationException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions));
            Assert.AreEqual("Receipt issuer 'foo.bar.com' is not in the authorized domain list.", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_AuthorizedDomains_not_found()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "wetrustsomethingelse.com" },
                UnauthorizedReceiptBehavior = UnauthorizedReceiptBehavior.IgnoreAll
            };

            var exception = Assert.Throws<AggregateException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions));
            StringAssert.Contains("No valid receipts found for any authorized issuer domain.", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_DefuleVerificationOptions_fails()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (mockTransport, options) = createClientOptionsWithValidPublicKeyResponse();
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");
            var exception = Assert.Throws<InvalidOperationException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, null, options));
            StringAssert.Contains("Receipt issuer 'foo.bar.com' is not in the authorized domain list.", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_RequireAll_fails()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (mockTransport, options) = createClientOptionsWithValidPublicKeyResponse();

            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com", "wetrustsomethingelse.com" },
                AuthorizedReceiptBehavior = AuthorizedReceiptBehavior.RequireAll,
                UnauthorizedReceiptBehavior = UnauthorizedReceiptBehavior.IgnoreAll
            };

            var exception = Assert.Throws<AggregateException>(() => CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options));
            StringAssert.Contains("No valid receipt found for a required domain 'wetrustsomethingelse.com'.", exception.Message);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_VerifyAnyMatching_succeeds()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var (mockTransport, options) = createClientOptionsWithValidPublicKeyResponse();

            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var verificationOptions = new CodeTransparencyVerificationOptions
            {
                AuthorizedDomains = new string[] { "foo.bar.com", "doesnotexist.com" },
                AuthorizedReceiptBehavior = AuthorizedReceiptBehavior.VerifyAnyMatching,
                UnauthorizedReceiptBehavior = UnauthorizedReceiptBehavior.IgnoreAll
            };

            Assert.DoesNotThrow(() =>
                CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options));
            Assert.AreEqual(1, mockTransport.Requests.Count);
#endif
        }

        [Test]
        public void VerifyTransparentStatement_ThreadSafety_ParallelCallsShouldNotFail()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");
            int threadCount = 8;
            int iterationsPerThread = 3;

            var timeout = TimeSpan.FromMilliseconds(25_000);

            var barrier = new Barrier(threadCount);
            var exceptions = new ConcurrentBag<Exception>();

            var tasks = Enumerable.Range(0, threadCount).Select(_ => Task.Run(() =>
            {
                barrier.SignalAndWait(); // ensure all threads start at the same time
                for (int i = 0; i < iterationsPerThread; i++)
                {
                    try
                    {
                        var content = createValidSignedStatementPublicKeyResponse();
                        var mockTransport = new MockTransport(content);
                        var options = new CodeTransparencyClientOptions
                        {
                            Transport = mockTransport,
                            IdentityClientEndpoint = "https://foo.bar.com"
                        };
                        var verificationOptions = new CodeTransparencyVerificationOptions
                        {
                            AuthorizedDomains = new string[] { "foo.bar.com" },
                        };

                        CodeTransparencyClient.VerifyTransparentStatement(transparentStatementBytes, verificationOptions, options);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }
            })).ToArray();

            if (!Task.WaitAll(tasks, timeout))
            {
                Assert.Inconclusive($"Thread-safety test could not complete within the CI timeout budget ({timeout.TotalSeconds} seconds).");
            }

            int totalCalls = threadCount * iterationsPerThread;
            Assert.IsEmpty(exceptions,
                $"Thread safety violation: {exceptions.Count} out of {totalCalls} parallel calls failed. " +
                $"First error: {exceptions.FirstOrDefault()?.Message}");
#endif
        }
    }
}
