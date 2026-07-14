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
        public async Task FetchAsync_SuccessfulResponse_ReturnsUseUrl()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.UseUrl, result.Status);
            Assert.Equal("data.example.invalid", result.Url);
            Assert.Equal(1, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_EnabledFalse_ReturnsDisabledWithoutRetry()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":false,\"url\":\"x.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Disabled, result.Status);
            Assert.Null(result.Url);
            Assert.Equal(1, handler.RequestCount); // No retry on explicit disable.
        }

        [Fact]
        public async Task FetchAsync_UnsupportedVersion_ReturnsFallbackWithoutRetry()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":99,\"enabled\":true,\"url\":\"x.invalid\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(1, handler.RequestCount); // Schema mismatch is not retried.
        }

        [Fact]
        public async Task FetchAsync_MissingUrlField_ReturnsFallback()
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(1, handler.RequestCount);
        }

        [Theory]
        [InlineData("\"\"")]            // empty string
        [InlineData("\"   \"")]        // whitespace
        [InlineData("null")]            // explicit JSON null
        public async Task FetchAsync_EmptyOrWhitespaceUrl_ReturnsFallback(string urlLiteral)
        {
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true,\"url\":" + urlLiteral + "}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
        }

        [Fact]
        public async Task FetchAsync_MalformedJson_ReturnsFallback()
        {
            var handler = new StubHandler(req => OkJson("not json"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(1, handler.RequestCount);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.Unauthorized)]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.NotFound)]
        public async Task FetchAsync_4xx_ReturnsFallbackWithoutRetry(HttpStatusCode statusCode)
        {
            var handler = new StubHandler(req => new HttpResponseMessage(statusCode));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(1, handler.RequestCount); // 4xx is definitive; no retry.
        }

        [Fact]
        public async Task FetchAsync_5xxThenSuccess_RetriesAndReturnsUseUrl()
        {
            var responses = new Queue<HttpResponseMessage>(new[]
            {
                new HttpResponseMessage(HttpStatusCode.InternalServerError),
                OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"data.example.invalid\"}"),
            });
            var handler = new StubHandler(req => responses.Dequeue());

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.UseUrl, result.Status);
            Assert.Equal("data.example.invalid", result.Url);
            Assert.Equal(2, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_Persistent5xx_ExhaustsAttemptsAndReturnsFallback()
        {
            var handler = new StubHandler(req => new HttpResponseMessage(HttpStatusCode.BadGateway));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(SdkStatsConfigFetcher.MaxAttempts, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_PersistentNetworkError_ExhaustsAttempts()
        {
            var handler = new StubHandler(req => throw new HttpRequestException("connection refused"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(SdkStatsConfigFetcher.MaxAttempts, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_IOException_RetriesThenFallback()
        {
            // Validates the IOException branch of the transient-error allowlist.
            var handler = new StubHandler(req => throw new System.IO.IOException("socket closed"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(SdkStatsConfigFetcher.MaxAttempts, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_NonTransientException_ReturnsFallbackWithoutRetry()
        {
            // InvalidOperationException isn't in the transient allowlist; one shot.
            var handler = new StubHandler(req => throw new InvalidOperationException("bad config"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(1, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_PreCancelledToken_ReturnsFallbackWithoutCallingHandler()
        {
            using var cts = new CancellationTokenSource();
            cts.Cancel();
            var handler = new StubHandler(req => OkJson("{\"ver\":1,\"enabled\":true,\"url\":\"x\"}"));

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler, cts.Token);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
            Assert.Equal(0, handler.RequestCount);
        }

        [Fact]
        public async Task FetchAsync_CancellationDuringRetryBackoff_ReturnsFallback()
        {
            using var cts = new CancellationTokenSource();
            var handler = new StubHandler(req =>
            {
                cts.Cancel();
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            });

            var result = await SdkStatsConfigFetcher.FetchAsync(TestConfigUrl, handler, cts.Token);

            Assert.Equal(SdkStatsConfigStatus.Fallback, result.Status);
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
