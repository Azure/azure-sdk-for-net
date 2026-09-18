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
    public class AzureDataAIClientTests
    {
        [Test]
        public void CanCreateApiKeyClient()
        {
            var client = new AzureDataAIClient(
                new Uri("https://example.inference.azure.com"),
                new AzureKeyCredential("api-key"));

            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void CanCreateTokenCredentialClient()
        {
            var client = new AzureDataAIClient(
                new Uri("https://example.inference.azure.com"),
                new TestCredential());

            Assert.That(client, Is.Not.Null);
        }

        [Test]
        public void RequestRequiresQuery()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SemanticRerankingInferenceRequest(null, new[] { "document" }));
        }

        [Test]
        public void RequestSerializesSentenceScoreOption()
        {
            var request = new SemanticRerankingInferenceRequest("query", new[] { "document" })
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

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new AccessToken("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken) =>
                new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
        }
    }
}
