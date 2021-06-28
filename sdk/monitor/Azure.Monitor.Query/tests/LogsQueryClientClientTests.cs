// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using Moq;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientClientTests
    {
        [Test]
        public void CanSetServiceTimeout_Mocked()
        {
            string preferHeader = null;
            TimeSpan? networkOverride = default;

            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                Assert.True(message.Request.Headers.TryGetValue("prefer", out preferHeader));
                networkOverride = message.NetworkTimeout;

                return new MockResponse(403);
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            Assert.ThrowsAsync<RequestFailedException>(() => client.QueryAsync("wid", "tid", TimeSpan.FromDays(1), options: new LogsQueryOptions()
            {
                ServerTimeout = TimeSpan.FromMinutes(10)
            }));

            Assert.AreEqual("wait=600", preferHeader);
            // The network timeout is adjusted with 15 sec buffer
            Assert.AreEqual(TimeSpan.FromMinutes(10).Add(TimeSpan.FromSeconds(15)), networkOverride);
        }

        [Test]
        public async Task QueryBatchHandledInvalidResponse()
        {
            var badResponse = @"{
    ""responses"": [
        {
            ""id"": ""0"",
            ""status"": 200,
            ""headers"": {
                ""Age"": ""3"",
                ""request-context"": ""appId=cid-v1:70941e4f-7e8f-40b7-b730-183893db0297""
            },
            ""body"": ""{\""tables\"":[{\""name\"":\""PrimaryResult\"",\""columns\"":[{\""name\"":\""TenantId\"",\""type\"":\""string\""},{\""name\"":\""SourceSystem\"",\""type\"":\""string\""},{\""name\"":\""MG\"",\""type\"":\""string\""},{\""name\"":\""ManagementGroupName\"",\""type\"":\""string\""},{\""name\"":\""TimeGenerated\"",\""type\"":\""datetime\""},{\""name\"":\""Computer\"",\""type\"":\""string\""},{\""name\"":\""RawData\"",\""type\"":\""string\""},{\""name\"":\""IntColumn_d\"",\""type\"":\""real\""},{\""name\"":\""StringColumn_s\"",\""type\"":\""string\""},{\""name\"":\""BoolColumn_b\"",\""type\"":\""bool\""},{\""name\"":\""FloatColumn_d\"",\""type\"":\""real\""},{\""name\"":\""Type\"",\""type\"":\""string\""},{\""name\"":\""_ResourceId\"",\""type\"":\""string\""}],\""rows\"":[[\""e7bf7412-576d-4978-b47c-2edf669e3e2a\"",\""RestAPI\"",\""\"",\""\"",\""2021-05-31T00:00:00Z\"",\""\"",\""\"",1,\""a\"",false,0,\""TableA1_151_CL\"",\""\""],[\""e7bf7412-576d-4978-b47c-2edf669e3e2a\"",\""RestAPI\"",\""\"",\""\"",\""2021-06-02T00:00:00Z\"",\""\"",\""\"",3,\""b\"",true,1.20000005,\""TableA1_151_CL\"",\""\""],[\""e7bf7412-576d-4978-b47c-2edf669e3e2a\"",\""RestAPI\"",\""\"",\""\"",\""2021-06-05T00:00:00Z\"",\""\"",\""\"",1,\""c\"",false,1.10000002,\""TableA1_151_CL\"",\""\""]]}]}""
        }
    ]
}
";
            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent(badResponse);
                return mockResponse;
            });

            var client = new LogsQueryClient(new Uri("https://api.loganalytics.io"), new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            LogsBatchQuery batch = new LogsBatchQuery();
            batch.AddQuery("wid", "query", DateTimeRange.All);

            LogsBatchQueryResult batchResult = await client.QueryBatchAsync(batch);
            Assert.NotNull(batchResult.GetResult("0"));
        }

        [Test]
        public async Task UsesDefaultEndpoint()
        {
            string uri = null;
            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                uri = message.Request.Uri.ToString();
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent("{\"tables\":[]}");
                return mockResponse;
            });

            var client = new LogsQueryClient(new MockCredential(), new LogsQueryClientOptions()
            {
                Transport = mockTransport
            });

            await client.QueryAsync("", "", DateTimeRange.All);
            StringAssert.StartsWith("https://api.loganalytics.io", uri);
        }

        [TestCase(null, "https://api.loganalytics.io//.default")]
        [TestCase("https://api.loganalytics.gov//.default", "https://api.loganalytics.gov//.default")]
        public async Task UsesDefaultAuthScope(string scope, string expectedScope)
        {
            var mockTransport = MockTransport.FromMessageCallback(message =>
            {
                var mockResponse = new MockResponse(200);
                mockResponse.SetContent("{\"tables\":[]}");
                return mockResponse;
            });

            Mock<MockCredential> mock = new() { CallBase = true };

            string[] scopes = null;
            mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Callback<TokenRequestContext, CancellationToken>((c, _) => scopes = c.Scopes)
                .CallBase();

            var client = new LogsQueryClient(mock.Object, new LogsQueryClientOptions()
            {
                Transport = mockTransport,
                AuthenticationScope = scope
            });

            await client.QueryAsync("", "", DateTimeRange.All);
            Assert.AreEqual(new[] { expectedScope }, scopes);
        }
    }
}