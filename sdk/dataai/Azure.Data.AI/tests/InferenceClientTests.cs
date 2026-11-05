// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Data.AI.Tests
{
    public class InferenceClientTests
    {
        [Test]
        public void CanCreateApiKeyClient()
        {
            var client = new InferenceClient(
                new Uri("https://example.inference.azure.com"),
                new AzureKeyCredential("api-key"));

            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void CanCreateTokenCredentialClient()
        {
            var client = new InferenceClient(
                new Uri("https://example.inference.azure.com"),
                new TestCredential());

            Assert.That(client, Is.Not.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task RerankingUsesGaApiVersion(bool explicitVersion)
        {
            using var handler = new ApiVersionHandler("2026-10-30");
            using var httpClient = new HttpClient(handler);
            var options = explicitVersion
                ? new InferenceClientOptions(InferenceClientOptions.ServiceVersion.V2026_10_30)
                : new InferenceClientOptions();
            options.Transport = new HttpClientTransport(httpClient);
            var client = new InferenceClient(
                new Uri("https://example.inference.azure.com"),
                new AzureKeyCredential("api-key"),
                options);

            await client.SemanticRerankAsync(
                new SemanticRerankingInferenceContent("query", new[] { "document" }));
        }

        // InferenceClientSettings and the settings-based constructor are gated behind
        // the SCME0002 experimental diagnostic while the configuration binding API stabilizes.
#pragma warning disable SCME0002
        [TestCase(null, "2026-10-30")]
        [TestCase("2026-10-30", "2026-10-30")]
        [TestCase("custom-version", "custom-version")]
        public async Task ConfiguredRerankingUsesExpectedApiVersion(string configuredVersion, string expectedVersion)
        {
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["Inference:Endpoint"] = "https://example.inference.azure.com",
                    ["Inference:Options:Version"] = configuredVersion,
                    ["Inference:Options:NetworkTimeout"] = "00:00:10"
                }).Build();
            var settings = new InferenceClientSettings
            {
                Credential = new CredentialSettings(null)
                {
                    CredentialSource = "ApiKeyCredential",
                    Key = "api-key"
                }
            };
            settings.Bind(configuration.GetSection("Inference"));
            using var handler = new ApiVersionHandler(expectedVersion);
            using var httpClient = new HttpClient(handler);
            settings.Options.Transport = new HttpClientTransport(httpClient);
            var client = new InferenceClient(settings);

            await client.SemanticRerankAsync(
                new SemanticRerankingInferenceContent("query", new[] { "document" }));
        }

        [Test]
        public void CanCreateApiKeyClientFromSettings()
        {
            var settings = new InferenceClientSettings
            {
                Endpoint = new Uri("https://example.inference.azure.com"),
                Credential = new CredentialSettings(null)
                {
                    CredentialSource = "ApiKeyCredential",
                    Key = "api-key"
                }
            };

            var client = new InferenceClient(settings);

            Assert.That(client, Is.Not.Null);
            Assert.That(client.Pipeline, Is.Not.Null);
        }

        [Test]
        public void CanCreateTokenCredentialClientFromSettings()
        {
            var settings = new InferenceClientSettings
            {
                Endpoint = new Uri("https://example.inference.azure.com"),
                Credential = new CredentialSettings(null)
                {
                    TokenProvider = new TestCredential()
                }
            };

            var client = new InferenceClient(settings);

            Assert.That(client, Is.Not.Null);
            Assert.That(client.Pipeline, Is.Not.Null);
        }

        [Test]
        public void SettingsWithoutCredentialThrows()
        {
            var settings = new InferenceClientSettings
            {
                Endpoint = new Uri("https://example.inference.azure.com")
            };

            Assert.Throws<ArgumentException>(() => new InferenceClient(settings));
        }
#pragma warning restore SCME0002

        [Test]
        public void RequestRequiresQuery()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SemanticRerankingInferenceContent(null, new[] { "document" }));
        }

        [Test]
        public void RequestSerializesSentenceScoreOption()
        {
            var request = new SemanticRerankingInferenceContent("query", new[] { "document" })
            {
                ReturnDocuments = true,
                ReturnSentenceScore = true
            };

            BinaryData json = ModelReaderWriter.Write(
                request,
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);

            Assert.That(json.ToString(), Does.Contain("\"returnDocuments\":true"));
            Assert.That(json.ToString(), Does.Contain("\"returnSentenceScore\":true"));
        }

        [Test]
        public void ResponseDeserializesSentenceScores()
        {
            BinaryData json = BinaryData.FromString(
                """
                {
                  "scores": [
                    {
                      "index": 0,
                      "score": 0.98,
                      "sentenceScores": [
                        { "index": 0, "score": 0.98 }
                      ]
                    }
                  ]
                }
                """);

            SemanticRerankingInferenceResult result = ModelReaderWriter.Read<SemanticRerankingInferenceResult>(
                json,
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);

            Assert.That(result.Scores, Has.Count.EqualTo(1));
            Assert.That(result.Scores[0].SentenceScores, Has.Count.EqualTo(1));
            Assert.That(result.Scores[0].SentenceScores[0].Score, Is.EqualTo(0.98f));
        }

        private sealed class ApiVersionHandler : HttpMessageHandler
        {
            private readonly string _expectedVersion;

            public ApiVersionHandler(string expectedVersion) => _expectedVersion = expectedVersion;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
                Assert.That(request.RequestUri.AbsolutePath, Is.EqualTo("/inference/semanticReranking"));
                Assert.That(request.RequestUri.Query, Is.EqualTo($"?api-version={_expectedVersion}"));
                Assert.That(request.Headers.GetValues("Ocp-Apim-Subscription-Key"), Is.EquivalentTo(new[] { "api-key" }));
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"scores\":[]}")
                });
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new AccessToken("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
