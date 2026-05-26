// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO.Compression;
using System.Net;
using System.Text;
using Azure.AI.AgentServer.Responses.Internal;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

/// <summary>
/// Tests verifying the Foundry storage pipeline handles gzip-encoded responses
/// from intermediary gateways and load-balancers. Regression suite based on
/// a production crash discovered in the Python SDK where an intermediary
/// returned gzip bytes with Content-Type: application/json.
/// </summary>
public class GzipDecompressionTests
{
    /// <summary>
    /// Verifies the storage pipeline transparently decompresses a gzip-encoded
    /// success response so callers receive valid JSON.
    /// </summary>
    [Test]
    public async Task Pipeline_DecompressesGzipResponse()
    {
        var expectedJson = """{"id":"resp_123","object":"response","status":"completed"}""";

        await using var server = await StartGzipServer(expectedJson, statusCode: 200);
        var pipeline = BuildStoragePipeline();

        using var message = pipeline.CreateMessage();
        message.Request.Uri.Reset(new Uri($"{server.BaseUrl}/test"));
        message.Request.Headers.SetValue("Accept", "application/json");
        await pipeline.SendAsync(message, default);

        var body = message.Response.Content.ToString();
        Assert.That(message.Response.Status, Is.EqualTo(200));
        Assert.That(body, Is.EqualTo(expectedJson));
    }

    /// <summary>
    /// Verifies the pipeline decompresses gzip error responses so
    /// <see cref="StorageErrorMapper"/> can extract structured error details.
    /// </summary>
    [Test]
    public async Task Pipeline_DecompressesGzipErrorResponse_ErrorMapperExtractsDetails()
    {
        var errorJson = """{"error":{"code":"storage_error","message":"Service unavailable.","type":"server_error"}}""";

        await using var server = await StartGzipServer(errorJson, statusCode: 503);
        var pipeline = BuildStoragePipeline();

        using var message = pipeline.CreateMessage();
        message.Request.Uri.Reset(new Uri($"{server.BaseUrl}/test"));
        await pipeline.SendAsync(message, default);

        var ex = Assert.Throws<ResponsesApiException>(() => StorageErrorMapper.ThrowIfError(message.Response));
        Assert.That(ex!.Message, Is.EqualTo("Service unavailable."));
        Assert.That(ex.Error.Code, Is.EqualTo("storage_error"));
    }

    /// <summary>
    /// Verifies the pipeline advertises gzip support via Accept-Encoding so
    /// servers and gateways know compression is safe.
    /// </summary>
    [Test]
    public async Task Pipeline_AdvertisesGzipSupport()
    {
        string receivedAcceptEncoding = string.Empty;

        await using var server = await StartServer(async ctx =>
        {
            receivedAcceptEncoding = ctx.Request.Headers.AcceptEncoding.ToString();
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = "application/json";
            await ctx.Response.WriteAsync("""{"ok":true}""");
        });

        var pipeline = BuildStoragePipeline();
        using var message = pipeline.CreateMessage();
        message.Request.Uri.Reset(new Uri($"{server.BaseUrl}/test"));
        await pipeline.SendAsync(message, default);

        Assert.That(receivedAcceptEncoding, Does.Contain("gzip"));
    }

    /// <summary>
    /// Defensive: if raw gzip bytes somehow reach StorageErrorMapper without
    /// decompression (e.g. an unusual transport), the error mapper must fall
    /// back to a generic message rather than crash.
    /// </summary>
    [Test]
    public void StorageErrorMapper_HandlesRawGzipBytes_FallsBackGracefully()
    {
        var json = """{"error":{"code":"test","message":"real message"}}""";
        var gzipBytes = GzipCompress(Encoding.UTF8.GetBytes(json));

        var response = new RawBytesResponse(500, gzipBytes);
        var ex = Assert.Throws<ResponsesApiException>(() => StorageErrorMapper.ThrowIfError(response));

        // Must not crash — falls back to generic message since gzip bytes aren't valid JSON
        Assert.That(ex!.Message, Is.EqualTo("Foundry storage request failed with HTTP 500."));
    }

    #region Helpers

    private static HttpPipeline BuildStoragePipeline()
    {
        var options = new FoundryStorageClientOptions();
        options.Retry.MaxRetries = 0;
        return HttpPipelineBuilder.Build(options);
    }

    private static byte[] GzipCompress(byte[] data)
    {
        using var output = new MemoryStream();
        using (var gzip = new GZipStream(output, CompressionLevel.Fastest))
        {
            gzip.Write(data);
        }

        return output.ToArray();
    }

    private static async Task<TestKestrelServer> StartGzipServer(string jsonBody, int statusCode)
    {
        var compressed = GzipCompress(Encoding.UTF8.GetBytes(jsonBody));
        return await StartServer(async ctx =>
        {
            ctx.Response.StatusCode = statusCode;
            ctx.Response.ContentType = "application/json";
            ctx.Response.Headers["Content-Encoding"] = "gzip";
            await ctx.Response.Body.WriteAsync(compressed);
        });
    }

    private static async Task<TestKestrelServer> StartServer(RequestDelegate handler)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseUrls("http://127.0.0.1:0");
        builder.Logging.ClearProviders();
        var app = builder.Build();
        app.Run(handler);
        await app.StartAsync();

        var addresses = app.Services.GetRequiredService<IServer>()
            .Features.Get<IServerAddressesFeature>()!;
        return new TestKestrelServer(app, addresses.Addresses.First());
    }

    private sealed class TestKestrelServer : IAsyncDisposable
    {
        private readonly WebApplication _app;

        public TestKestrelServer(WebApplication app, string baseUrl)
        {
            _app = app;
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; }

        public async ValueTask DisposeAsync()
        {
            await _app.StopAsync();
            await _app.DisposeAsync();
        }
    }

    /// <summary>
    /// Minimal mock response that returns raw bytes as Content,
    /// simulating un-decompressed gzip content.
    /// </summary>
    private sealed class RawBytesResponse : Response
    {
        private readonly int _status;
        private readonly BinaryData _content;

        public RawBytesResponse(int status, byte[] rawBytes)
        {
            _status = status;
            _content = BinaryData.FromBytes(rawBytes);
        }

        public override int Status => _status;
        public override string ReasonPhrase => "Error";
        public override BinaryData Content => _content;
        public override bool IsError => _status >= 400;
        public override Stream? ContentStream { get => null; set { } }
        public override string ClientRequestId { get => "test"; set { } }
        public override void Dispose() { }
        protected override bool ContainsHeader(string name) => false;
        protected override IEnumerable<HttpHeader> EnumerateHeaders() => [];

        protected override bool TryGetHeader(string name, out string? value)
        {
            value = null;
            return false;
        }

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
        {
            values = null;
            return false;
        }
    }

    #endregion
}
