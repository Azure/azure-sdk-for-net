// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Internal;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Internal;

[TestFixture]
public class FoundryStorageLoggingPolicyTests
{
    [Test]
    public void MaskStorageUrl_RedactsProjectPathAndKeepsStorageSegment()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123"));
    }

    [Test]
    public void MaskStorageUrl_StripsQueryParamsExceptApiVersion()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123?api-version=2025-01-01&token=secret";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123?api-version=2025-01-01"));
    }

    [Test]
    public void MaskStorageUrl_StripsAllQueryParamsWhenNoApiVersion()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/storage/responses/resp_123?token=secret&other=val";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/responses/resp_123"));
    }

    [Test]
    public void MaskStorageUrl_PreservesApiVersionOnly()
    {
        var url = "https://host/proj/storage/data?other=1&api-version=2024-06-01&extra=2";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/data?api-version=2024-06-01"));
    }

    [Test]
    public void MaskStorageUrl_RedactsWhenNoStorageSegment()
    {
        var url = "https://acct.services.ai.azure.com/api/projects/myproj/other/path";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_ReturnsRedactedForNull()
    {
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(null), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_ReturnsRedactedForEmpty()
    {
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(""), Is.EqualTo("(redacted)"));
    }

    [Test]
    public void MaskStorageUrl_HandlesStorageAtRoot()
    {
        var url = "https://host/storage/items/item_1";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/items/item_1"));
    }

    [Test]
    public void MaskStorageUrl_CaseInsensitiveApiVersionParam()
    {
        var url = "https://host/proj/storage/data?Api-Version=2024-06-01";
        Assert.That(FoundryStorageLoggingPolicy.MaskStorageUrl(url), Is.EqualTo("***/storage/data?Api-Version=2024-06-01"));
    }

    [Test]
    public async Task ProcessAsync_TransportFailure_LogsErrorWithExceptionDetails()
    {
        // Simulates a transport-level failure where no response is set on the HttpMessage.
        var logger = new CapturingLogger();
        var policy = new FoundryStorageLoggingPolicy(logger);

        var request = new MockPipelineRequest();
        request.Uri = "https://host/storage/responses/resp_1";
        request.SetHeader("traceparent", "00-abcdef1234567890abcdef1234567890-1234567890abcdef-01");
        var message = new HttpMessage(request, new ResponseClassifier());

        // Inner policy that throws without setting a response (simulates DNS/connection failure).
        var throwingPolicy = new ThrowingPolicy();
        var pipeline = new ReadOnlyMemory<HttpPipelinePolicy>(new[] { throwingPolicy });

        // The transport exception should propagate, but logging must not throw InvalidOperationException.
        var ex = Assert.ThrowsAsync<HttpRequestException>(async () =>
            await policy.ProcessAsync(message, pipeline));

        Assert.That(ex!.Message, Is.EqualTo("Connection refused"));

        // Verify the transport failure was logged at Error level with the full exception and traceparent.
        var errorLog = logger.Logs.FirstOrDefault(l => l.Level == LogLevel.Error);
        Assert.That(errorLog.Message, Is.Not.Null);
        Assert.That(errorLog.Message, Does.Contain("transport failure"));
        Assert.That(errorLog.Message, Does.Contain("abcdef1234567890abcdef1234567890"));

        // The exception itself is passed to the logger (includes full ToString with stack trace).
        Assert.That(errorLog.Exception, Is.Not.Null);
        Assert.That(errorLog.Exception, Is.InstanceOf<HttpRequestException>());
        Assert.That(errorLog.Exception!.Message, Is.EqualTo("Connection refused"));
    }

    [Test]
    public async Task ProcessAsync_SuccessfulRequest_LogsTraceparent()
    {
        var logger = new CapturingLogger();
        var policy = new FoundryStorageLoggingPolicy(logger);

        var request = new MockPipelineRequest();
        request.Uri = "https://host/api/projects/p/storage/responses/resp_1";
        request.SetHeader("traceparent", "00-aaaa1111bbbb2222cccc3333dddd4444-eeee5555ffff6666-01");
        var message = new HttpMessage(request, new ResponseClassifier());

        // Inner policy that sets a successful response.
        var successPolicy = new SuccessPolicy(200);
        var pipeline = new ReadOnlyMemory<HttpPipelinePolicy>(new[] { successPolicy });

        await policy.ProcessAsync(message, pipeline);

        // Verify start and success logs contain the traceparent.
        var startLog = logger.Logs.First(l => l.Level == LogLevel.Debug);
        Assert.That(startLog.Message, Does.Contain("aaaa1111bbbb2222cccc3333dddd4444"));

        var infoLog = logger.Logs.First(l => l.Level == LogLevel.Information);
        Assert.That(infoLog.Message, Does.Contain("aaaa1111bbbb2222cccc3333dddd4444"));
        Assert.That(infoLog.Message, Does.Contain("traceparent:"));
    }

    /// <summary>
    /// Policy that throws without setting a response, simulating a transport failure.
    /// </summary>
    private sealed class ThrowingPolicy : HttpPipelinePolicy
    {
        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => throw new HttpRequestException("Connection refused");

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            => throw new HttpRequestException("Connection refused");
    }

    /// <summary>
    /// Policy that sets a mock response with the specified status code.
    /// </summary>
    private sealed class SuccessPolicy : HttpPipelinePolicy
    {
        private readonly int _statusCode;

        public SuccessPolicy(int statusCode) => _statusCode = statusCode;

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Response = new MockResponse(_statusCode);
        }

        public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            message.Response = new MockResponse(_statusCode);
            return default;
        }
    }

    /// <summary>
    /// Minimal ILogger that captures log entries for assertion.
    /// </summary>
    private sealed class CapturingLogger : ILogger
    {
        public List<(LogLevel Level, string Message, Exception? Exception)> Logs { get; } = new();

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Logs.Add((logLevel, formatter(state, exception), exception));
        }
    }

    /// <summary>
    /// Minimal Request for pipeline tests.
    /// </summary>
    private sealed class MockPipelineRequest : Request
    {
        private readonly Dictionary<string, string> _headers = new(StringComparer.OrdinalIgnoreCase);
        private string _uri = "";

        public override string ClientRequestId { get; set; } = Guid.NewGuid().ToString();

        public new string Uri
        {
            get => _uri;
            set
            {
                _uri = value;
                base.Uri.Reset(new Uri(value));
            }
        }

        public new void SetHeader(string name, string value) => _headers[name] = value;

        protected override void AddHeader(string name, string value)
        {
            if (_headers.TryGetValue(name, out var existing))
                _headers[name] = existing + "," + value;
            else
                _headers[name] = value;
        }

        protected override bool ContainsHeader(string name) => _headers.ContainsKey(name);

        protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
            _headers.Select(kvp => new HttpHeader(kvp.Key, kvp.Value));

        protected override bool RemoveHeader(string name) => _headers.Remove(name);

        protected override bool TryGetHeader(string name, out string? value)
        {
            if (_headers.TryGetValue(name, out var v))
            { value = v; return true; }
            value = null;
            return false;
        }

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
        {
            if (_headers.TryGetValue(name, out var v))
            { values = new[] { v }; return true; }
            values = null;
            return false;
        }

        public override void Dispose() { }
    }

    /// <summary>
    /// Minimal Response for pipeline tests.
    /// </summary>
    private sealed class MockResponse : Response
    {
        private readonly int _status;
        private readonly Dictionary<string, string> _headers = new(StringComparer.OrdinalIgnoreCase);

        public MockResponse(int status) => _status = status;

        public override int Status => _status;
        public override string ReasonPhrase => "OK";
        public override Stream? ContentStream { get; set; }
        public override string ClientRequestId { get; set; } = "";
        public override void Dispose() { }

        protected override bool ContainsHeader(string name) => _headers.ContainsKey(name);

        protected override IEnumerable<HttpHeader> EnumerateHeaders() =>
            _headers.Select(kvp => new HttpHeader(kvp.Key, kvp.Value));

        protected override bool TryGetHeader(string name, out string? value)
        {
            if (_headers.TryGetValue(name, out var v))
            { value = v; return true; }
            value = null;
            return false;
        }

        protected override bool TryGetHeaderValues(string name, out IEnumerable<string>? values)
        {
            if (_headers.TryGetValue(name, out var v))
            { values = new[] { v }; return true; }
            values = null;
            return false;
        }
    }
}
