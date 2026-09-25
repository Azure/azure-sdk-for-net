// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
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

        // InferenceClientSettings and the settings-based constructor are gated behind
        // the SCME0002 experimental diagnostic while the configuration binding API stabilizes.
#pragma warning disable SCME0002
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

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new AccessToken("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
