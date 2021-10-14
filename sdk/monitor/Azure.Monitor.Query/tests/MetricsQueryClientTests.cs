// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsQueryClientTests
    {
        [Test]
        public async Task UsesDefaultEndpoint()
        {
            var mockTransport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("{}"));

            var client = new MetricsQueryClient(new MockCredential(), new MetricsQueryClientOptions()
            {
                Transport = mockTransport
            });

            await client.QueryAsync("rid", new string[]{});
            StringAssert.StartsWith("https://management.azure.com", mockTransport.SingleRequest.Uri.ToString());
        }

        [TestCase(null, "https://management.azure.com//.default")]
        [TestCase("https://management.azure.gov", "https://management.azure.gov//.default")]
        [TestCase("https://management.azure.cn", "https://management.azure.cn//.default")]
        public async Task UsesDefaultAuthScope(string scope, string expectedScope)
        {
            var mockTransport = MockTransport.FromMessageCallback(_ => new MockResponse(200).SetContent("{}"));

            Mock<MockCredential> mock = new() { CallBase = true };

            string[] scopes = null;
            mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Callback<TokenRequestContext, CancellationToken>((c, _) => scopes = c.Scopes)
                .CallBase();

            var client = new MetricsQueryClient(mock.Object, new MetricsQueryClientOptions()
            {
                Transport = mockTransport,
                Audience = scope == null ? (MetricsQueryClientAudience?)null : new MetricsQueryClientAudience(scope)
            });

            await client.QueryAsync("", new string[]{});
            Assert.AreEqual(new[] { expectedScope }, scopes);
        }

        [Test]
        public void ExposesPublicEndpoint()
        {
            var client = new MetricsQueryClient(new Uri("https://management.azure.gov"), new MockCredential(), new MetricsQueryClientOptions());
            Assert.AreEqual(new Uri("https://management.azure.gov"), client.Endpoint);
        }
    }
}