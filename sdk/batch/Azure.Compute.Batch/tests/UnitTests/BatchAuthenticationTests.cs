// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Compute.Batch.Tests.UnitTests
{
    public class BatchAuthenticationTests
    {
        private static readonly Uri Endpoint = new Uri("https://account.region.batch.azure.com");

        [TestCase(null, "https://batch.core.windows.net//.default", false)]
        [TestCase(null, "https://batch.core.windows.net//.default", true)]
        [TestCase("https://batch.core.windows.net/", "https://batch.core.windows.net//.default", false)]
        [TestCase("https://batch.core.windows.net/", "https://batch.core.windows.net//.default", true)]
        [TestCase("https://batch.core.usgovcloudapi.net/", "https://batch.core.usgovcloudapi.net//.default", false)]
        [TestCase("https://batch.core.usgovcloudapi.net/", "https://batch.core.usgovcloudapi.net//.default", true)]
        [TestCase("https://batch.chinacloudapi.cn/", "https://batch.chinacloudapi.cn//.default", false)]
        [TestCase("https://batch.chinacloudapi.cn/", "https://batch.chinacloudapi.cn//.default", true)]
        [TestCase("https://custom.example/", "https://custom.example//.default", false)]
        [TestCase("https://custom.example/", "https://custom.example//.default", true)]
        [TestCase("https://custom.example", "https://custom.example/.default", false)]
        [TestCase("https://custom.example", "https://custom.example/.default", true)]
        public async Task RequestsConfiguredAudience(string audience, string expectedScope, bool isAsync)
        {
            string[] requestedScopes = null;
            var credential = new MockCredential
            {
                GetTokenCallback = (context, _) => requestedScopes = context.Scopes
            };
            var options = new BatchClientOptions
            {
                Transport = new MockTransport(new MockResponse(200)),
                Audience = audience == null ? (BatchAudience?)null : new BatchAudience(audience)
            };
            var client = new BatchClient(Endpoint, credential, options);

            await SendRequest(client, isAsync);

            CollectionAssert.AreEqual(new[] { expectedScope }, requestedScopes);
        }

        [Test]
        public async Task ClientsKeepIndependentAudiences([Values(false, true)] bool isAsync)
        {
            var scopes = new List<string>();
            var credential = new MockCredential
            {
                GetTokenCallback = (context, _) => scopes.Add(context.Scopes[0])
            };
            var options = new BatchClientOptions
            {
                Transport = new MockTransport(new MockResponse(200), new MockResponse(200), new MockResponse(200), new MockResponse(200)),
                Audience = BatchAudience.AzureGovernment
            };
            var governmentClient = new BatchClient(Endpoint, credential, options);
            options.Audience = BatchAudience.AzureChina;
            var chinaClient = new BatchClient(Endpoint, credential, options);
            options.Audience = BatchAudience.AzurePublicCloud;
            var publicClient = new BatchClient(Endpoint, credential, options);

            await SendRequest(governmentClient, isAsync);
            await SendRequest(chinaClient, isAsync);
            await SendRequest(publicClient, isAsync);
            await SendRequest(governmentClient, isAsync);

            CollectionAssert.AreEqual(new[]
            {
                "https://batch.core.usgovcloudapi.net//.default",
                "https://batch.chinacloudapi.cn//.default",
                "https://batch.core.windows.net//.default"
            }, scopes);
        }

        [Test]
        public async Task SharedKeyIgnoresAudience([Values(false, true)] bool isAsync)
        {
            var transport = new MockTransport(new MockResponse(200));
            var options = new BatchClientOptions
            {
                Audience = BatchAudience.AzureChina,
                Transport = transport
            };
            var client = new BatchClient(Endpoint, new AzureNamedKeyCredential("account", Convert.ToBase64String(new byte[32])), options);

            await SendRequest(client, isAsync);

            Assert.IsTrue(transport.Requests[0].Headers.TryGetValue("Authorization", out string authorization));
            StringAssert.StartsWith("SharedKey account:", authorization);
        }

        [Test]
        public void AudienceValues()
        {
            Assert.AreEqual("https://batch.core.windows.net/", BatchAudience.AzurePublicCloud.ToString());
            Assert.AreEqual("https://batch.core.usgovcloudapi.net/", BatchAudience.AzureGovernment.ToString());
            Assert.AreEqual("https://batch.chinacloudapi.cn/", BatchAudience.AzureChina.ToString());
            Assert.AreEqual(BatchAudience.AzurePublicCloud, default(BatchAudience));
            Assert.AreEqual(BatchAudience.AzurePublicCloud.GetHashCode(), default(BatchAudience).GetHashCode());
            BatchAudience custom = "https://custom.example/";
            Assert.IsTrue(custom == new BatchAudience("https://custom.example/"));
            Assert.IsTrue(custom != BatchAudience.AzureChina);
            Assert.AreEqual(custom.GetHashCode(), new BatchAudience("https://custom.example/").GetHashCode());
            Assert.Throws<ArgumentNullException>(() => new BatchAudience(null));
            Assert.Throws<ArgumentException>(() => new BatchAudience(""));
        }

        [Test]
        public void AcceptsNullOptions()
        {
            Assert.DoesNotThrow(() => new BatchClient(Endpoint, new MockCredential(), null));
            Assert.DoesNotThrow(() => new BatchClient(Endpoint, new MockCredential()));
        }

        private static async Task SendRequest(BatchClient client, bool isAsync)
        {
            using Response response = isAsync
                ? await client.GetPoolAsync("pool", null, null, null, null, null, new RequestContext())
                : client.GetPool("pool", null, null, null, null, null, new RequestContext());
            Assert.AreEqual(200, response.Status);
        }
    }
}
