// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
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

        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task RerankingUsesGaApiVersion(bool explicitVersion, bool isAsync)
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

            var request = new SemanticRerankingOptions("query", new[] { "{\"meta\":{\"content\":\"document\"},\"id\":\"1\"}" })
            {
                DocumentType = SemanticRerankingDocumentType.Json,
                TargetPaths = { "meta.content", "id" }
            };
            Response<SemanticRerankingResult> response = isAsync
                ? await client.SemanticRerankAsync(request)
                : client.SemanticRerank(request);

            Assert.That(response.Value.Metadata.ModelName, Is.EqualTo("reranker"));
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
                new SemanticRerankingOptions("query", new[] { "{\"meta\":{\"content\":\"document\"},\"id\":\"1\"}" })
                {
                    DocumentType = SemanticRerankingDocumentType.Json,
                    TargetPaths = { "meta.content", "id" }
                });
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
                new SemanticRerankingOptions(null, new[] { "document" }));
        }

        [Test]
        public void RequestSerializesSentenceScoreOption()
        {
            var request = new SemanticRerankingOptions("query", new[] { "document" })
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

            SemanticRerankingResult result = ModelReaderWriter.Read<SemanticRerankingResult>(
                json,
                ModelReaderWriterOptions.Json,
                AzureDataAIContext.Default);

            Assert.That(result.Scores, Has.Count.EqualTo(1));
            Assert.That(result.Scores[0].SentenceScores, Has.Count.EqualTo(1));
            Assert.That(result.Scores[0].SentenceScores[0].Score, Is.EqualTo(0.98f));
        }

        [TestCase("J", 1)]
        [TestCase("W", 1)]
        [TestCase("J", 2)]
        [TestCase("W", 2)]
        [TestCase("J", 100)]
        [TestCase("W", 100)]
        public void TargetPathsRoundTripAsCommaDelimitedString(string format, int pathCount)
        {
            var request = new SemanticRerankingOptions("query", new[] { "{\"meta\":{\"content\":\"document\"}}" })
            {
                DocumentType = SemanticRerankingDocumentType.Json
            };
            for (int i = 0; i < pathCount; i++)
            {
                request.TargetPaths.Add($"meta.content{i}");
            }

            var options = new ModelReaderWriterOptions(format);
            BinaryData data = ModelReaderWriter.Write(request, options, AzureDataAIContext.Default);
            using JsonDocument json = JsonDocument.Parse(data);
            Assert.That(json.RootElement.GetProperty("targetPaths").ValueKind, Is.EqualTo(JsonValueKind.String));
            Assert.That(json.RootElement.GetProperty("targetPaths").GetString(), Is.EqualTo(string.Join(",", request.TargetPaths)));
            Assert.That(json.RootElement.GetProperty("documentType").GetString(), Is.EqualTo("json"));

            var roundTrip = ModelReaderWriter.Read<SemanticRerankingOptions>(data, options, AzureDataAIContext.Default);
            Assert.That(roundTrip.TargetPaths, Is.EqualTo(request.TargetPaths));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void UnsetTargetPathsAreOmitted(string format)
        {
            var request = new SemanticRerankingOptions("query", new[] { "document" });
            BinaryData data = ModelReaderWriter.Write(request, new ModelReaderWriterOptions(format), AzureDataAIContext.Default);
            using JsonDocument json = JsonDocument.Parse(data);

            Assert.That(request.TargetPaths, Is.Empty);
            Assert.That(json.RootElement.TryGetProperty("targetPaths", out _), Is.False);
        }

        [TestCase("{}")]
        [TestCase("{\"targetPaths\":null}")]
        [TestCase("{\"targetPaths\":\"\"}")]
        public void MissingOrEmptyTargetPathsDeserializeToEmptyCollection(string json)
        {
            var request = ModelReaderWriter.Read<SemanticRerankingOptions>(
                BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureDataAIContext.Default);

            Assert.That(request.TargetPaths, Is.Empty);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void MetadataKeepsMetaWireName(string format)
        {
            BinaryData data = BinaryData.FromString(
                """
                {
                  "scores": [],
                  "meta": {
                    "tokenUsage": { "totalTokens": 12 },
                    "latency": {
                      "dataPreprocessTime": 1.5,
                      "inferenceTime": 2.5,
                      "postProcessTime": 3.5
                    },
                    "modelName": "reranker",
                    "modelVersion": "1"
                  }
                }
                """);
            var options = new ModelReaderWriterOptions(format);
            var result = ModelReaderWriter.Read<SemanticRerankingResult>(data, options, AzureDataAIContext.Default);

            Assert.That(result.Metadata.ModelName, Is.EqualTo("reranker"));
            Assert.That(result.Metadata.ModelVersion, Is.EqualTo("1"));
            Assert.That(result.Metadata.TokenUsage.TotalTokens, Is.EqualTo(12));
            Assert.That(result.Metadata.Latency.DataPreprocessDuration, Is.EqualTo(TimeSpan.FromMilliseconds(1.5)));
            Assert.That(result.Metadata.Latency.InferenceDuration, Is.EqualTo(TimeSpan.FromMilliseconds(2.5)));
            Assert.That(result.Metadata.Latency.PostProcessDuration, Is.EqualTo(TimeSpan.FromMilliseconds(3.5)));

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(result, options, AzureDataAIContext.Default));
            Assert.That(json.RootElement.GetProperty("meta").GetProperty("modelName").GetString(), Is.EqualTo("reranker"));
            Assert.That(json.RootElement.TryGetProperty("metadata", out _), Is.False);
        }

        [Test]
        public void ModelFactoryUsesReviewedModelNames()
        {
            var request = InferenceModelFactory.SemanticRerankingOptions(
                query: "query", documents: new[] { "document" }, targetPaths: new[] { "meta.content", "id" });
            var metadata = InferenceModelFactory.SemanticRerankingMetadata(modelName: "reranker");
            var result = InferenceModelFactory.SemanticRerankingResult(metadata: metadata);

            Assert.That(request.TargetPaths, Is.EqualTo(new[] { "meta.content", "id" }));
            Assert.That(result.Metadata, Is.SameAs(metadata));
        }

        private sealed class ApiVersionHandler : HttpMessageHandler
        {
            private readonly string _expectedVersion;

            public ApiVersionHandler(string expectedVersion) => _expectedVersion = expectedVersion;

#if NET5_0_OR_GREATER
            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken) =>
                SendAsync(request, cancellationToken).GetAwaiter().GetResult();
#endif

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Assert.That(request.Method, Is.EqualTo(HttpMethod.Post));
                Assert.That(request.RequestUri.AbsolutePath, Is.EqualTo("/inference/semanticReranking"));
                Assert.That(request.RequestUri.Query, Is.EqualTo($"?api-version={_expectedVersion}"));
                Assert.That(request.Headers.GetValues("Ocp-Apim-Subscription-Key"), Is.EquivalentTo(new[] { "api-key" }));
                using JsonDocument body = JsonDocument.Parse(await request.Content.ReadAsStringAsync().ConfigureAwait(false));
                Assert.That(body.RootElement.GetProperty("targetPaths").ValueKind, Is.EqualTo(JsonValueKind.String));
                Assert.That(body.RootElement.GetProperty("targetPaths").GetString(), Is.EqualTo("meta.content,id"));
                Assert.That(body.RootElement.GetProperty("documentType").GetString(), Is.EqualTo("json"));
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"scores\":[],\"meta\":{\"modelName\":\"reranker\"}}")
                };
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
