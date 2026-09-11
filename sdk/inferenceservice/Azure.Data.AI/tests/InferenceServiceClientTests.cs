// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Data.AI.Tests
{
    public class InferenceServiceClientTests
    {
        [Test]
        public void CanCreateApiKeyClient()
        {
            var client = new InferenceServiceClient(
                new Uri("https://example.inference.azure.com"),
                new AzureKeyCredential("api-key"));

            Assert.That(client.GetDataInferenceClient(), Is.Not.Null);
        }

        [Test]
        public void CanCreateTokenCredentialClient()
        {
            var client = new InferenceServiceClient(
                new Uri("https://example.inference.azure.com"),
                new TestCredential());

            Assert.That(client.GetDataInferenceClient(), Is.Not.Null);
        }

        [Test]
        public void RequestRequiresQuery()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new SemanticRerankingInferenceRequest(null, new[] { "document" }));
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
