// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class SdkStatsConfigFetcherTests
    {
        private const string TestConfigUrl = "https://test.invalid/cfg/v1.json";

        [Fact]
        public async Task FetchAsync_SuccessfulResponse_ReturnsParsedConfig()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.NotNull(result);
            Assert.Equal(1, result!.ver);
            Assert.True(result.enabled);
            Assert.Equal("data.example.invalid", result.url);
            Assert.Equal(1, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_EnabledFalse_ReturnsNull()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":false,\"url\":\"x.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(1, handler.RequestCount); // No retry on explicit disable.
        }

        [Fact]
        public async Task FetchAsync_UnsupportedVersion_ReturnsNull()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":99,\"enabled\":true,\"url\":\"x.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(1, handler.RequestCount); // No retry on schema mismatch.
        }

        [Fact]
        public async Task FetchAsync_MissingUrl_ReturnsNull()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(1, handler.RequestCount); // No retry on missing field.
        }

        [Fact]
        public async Task FetchAsync_MalformedJson_ReturnsNull()
        {
            var handler = new StubHandler(req => OkJson("not json"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(1, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_404_ReturnsNullWithoutRetry()
        {
            var handler = new StubHandler(req => new HttpResponseMessage(HttpStatusCode.NotFound));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(1, handler.RequestCount); // 4xx is definitive; no retry.
        }

        [Fact]
        public async Task FetchAsync_5xxThenSuccess_RetriesAndReturnsConfig()
        {
            var responses = new Queue<HttpResponseMessage>(new[]
            {
                new HttpResponseMessage(HttpStatusCode.InternalServerError),
                OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}"),
            });
            var handler = new StubHandler(req => responses.Dequeue());

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.NotNull(result);
            Assert.Equal("data.example.invalid", result!.url);
            Assert.Equal(2, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_PersistentNetworkError_ExhaustsAttempts()
        {
            var handler = new StubHandler(req => throw new HttpRequestException("connection refused"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Null(result);
            Assert.Equal(SdkStatsConfigFetcher.MaxAttempts, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_CancellationDuringRetryBackoff_ReturnsNull()
        {
            using var cts = new CancellationTokenSource();
            var handler = new StubHandler(req =>
            {
                cts.Cancel();
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            });

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler, cts.Token);

            Assert.Null(result);
        }

        private static HttpResponseMessage OkJson(string body) =>
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, System.Text.Encoding.UTF8, "application/json"),
            };

        private sealed class StubHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, HttpResponseMessage> _responder;
            private int _requestCount;

            public StubHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
            {
                _responder = responder;
            }

            public int RequestCount => _requestCount;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Interlocked.Increment(ref _requestCount);
                cancellationToken.ThrowIfCancellationRequested();
                return Task.FromResult(_responder(request));
            }
        }
    }
}
