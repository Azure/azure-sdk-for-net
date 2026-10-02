// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class CertificatePlaybackTimePolicyTests : SyncAsyncPolicyTestBase
    {
        public CertificatePlaybackTimePolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(3600)]
        [TestCase(0)]
        [TestCase(-3600)]
        public async Task PreservesRecordedExpirationInterval(int remainingSeconds)
        {
            DateTimeOffset recordedDate = new(2025, 9, 29, 12, 0, 0, TimeSpan.Zero);
            DateTimeOffset now = new(2026, 10, 1, 12, 0, 0, TimeSpan.Zero);
            MockResponse response = new MockResponse(200)
                .WithHeader("Date", recordedDate.ToString("R"))
                .WithJson($"{{\"attributes\":{{\"exp\":{recordedDate.ToUnixTimeSeconds() + remainingSeconds}}}}}");
            MockTransport transport = CreateMockTransport(response);

            Response result = await SendGetRequest(
                transport, new CertificatePlaybackTimePolicy(now), uri: new Uri("https://test.vault.azure.net/keys/test/version"));

            using JsonDocument body = JsonDocument.Parse(result.ContentStream);
            Assert.That(body.RootElement.GetProperty("attributes").GetProperty("exp").GetInt64(),
                Is.EqualTo(now.ToUnixTimeSeconds() + remainingSeconds));
            Assert.That(transport.Requests.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task DoesNotChangeCertificateResponses()
        {
            const string json = "{\"attributes\":{\"exp\":1}}";
            MockTransport transport = CreateMockTransport(new MockResponse(200).WithJson(json));

            Response result = await SendGetRequest(
                transport, new CertificatePlaybackTimePolicy(DateTimeOffset.UtcNow), uri: new Uri("https://test.vault.azure.net/certificates/test/version"));

            using StreamReader reader = new(result.ContentStream);
            string content = IsAsync ? await reader.ReadToEndAsync() : reader.ReadToEnd();
            Assert.That(content, Is.EqualTo(json));
        }
    }
}
